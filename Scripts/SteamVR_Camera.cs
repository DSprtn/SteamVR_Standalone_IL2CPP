﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Adds SteamVR render support to existing camera objects
//
//=============================================================================

using UnityEngine;
using System.Collections;
using System.Reflection;
using Valve.VR;
using Standalone;
using Assets.SteamVR_Standalone.Standalone;
using System;
using System.IO;

namespace Valve.VR { 

public class SteamVR_Camera : MonoBehaviour
{
    public SteamVR_Camera(IntPtr value)
: base(value) { }
    private Transform _head;
    public Transform head { get { return _head; } }
    public Transform offset { get { return _head; } } // legacy
    public Transform origin { get { return _head.parent; } }

    public Camera camera { get; private set; }


    private Transform _ears;
    public Transform ears { get { return _ears; } }

    public Ray GetRay()
    {
        return new Ray(_head.position, _head.forward);
    }

    public bool wireframe = false;

    private SteamVR_CameraFlip flip;

    #region Materials

    static public Material blitMaterial;

    public static Action<int, int> OnResolutionChanged;

    // Using a single shared offscreen buffer to render the scene.  This needs to be larger
    // than the backbuffer to account for distortion correction.  The default resolution
    // gives us 1:1 sized pixels in the center of view, but quality can be adjusted up or
    // down using the following scale value to balance performance.
    static public float sceneResolutionScale = 1.0f;
    static public float sceneResolutionScaleMultiplier = 1f;

    static private RenderTexture _sceneTexture;

    public static Resolution GetSceneResolution()
        {
            var vr = SteamVR.instance;
            Resolution r = new Resolution();
            int w = (int)(vr.sceneWidth * sceneResolutionScale * sceneResolutionScaleMultiplier);
            int h = (int)(vr.sceneHeight * sceneResolutionScale * sceneResolutionScaleMultiplier);
            r.width = w;
            r.height = h;
            return r;
        }

    public static Resolution GetResolutionForAspect(int aspectW, int aspectH)
        {
            return GetResolutionForAspect(aspectW, aspectH, GetSceneResolution());
        }

        public static Resolution GetResolutionForAspect(int aspectW, int aspectH, int maxWidth)
        {
            // Some games choke on very high resolutions.
            // Resolution for aspect uses width and adjusts height to make it 16:9, so just clamp the width.
            Resolution sceneRes = GetSceneResolution();
            if (sceneRes.width >= maxWidth)
            {
                sceneRes.width = maxWidth;
            }

            return GetResolutionForAspect(aspectW, aspectH, sceneRes);
        }

        public static Resolution GetResolutionForAspect(int aspectW, int aspectH, Resolution hmdResolution)
        {
            // We calcuate an optimal 16:9 resolution to use with the HMD resolution because that's the best aspect for the UI rendering
            Resolution closestToAspect = hmdResolution;
            closestToAspect.height = closestToAspect.width * aspectH / aspectW; // Divide last because decimals
            closestToAspect.width += closestToAspect.width % 2;
            closestToAspect.height += closestToAspect.height % 2;
            return closestToAspect;
        }

    public static Resolution GetUnscaledSceneResolution()
        {
            var vr = SteamVR.instance;
            Resolution r = new Resolution();
            r.width = (int)vr.sceneWidth;
            r.height = (int)vr.sceneHeight;
            r.width += r.width % 2;
            r.height += r.height % 2;
            return r;
        }

    static public RenderTexture GetSceneTexture(bool hdr)
    {
        var vr = SteamVR.instance;
        if (vr == null)
            return null;

        int w = (int)(vr.sceneWidth * sceneResolutionScale * sceneResolutionScaleMultiplier);
        int h = (int)(vr.sceneHeight * sceneResolutionScale * sceneResolutionScaleMultiplier);
        w += w % 2;
        h += h % 2;


               
        int aa = QualitySettings.antiAliasing == 0 ? 1 : QualitySettings.antiAliasing;
        var format = hdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;
        bool recreatedTex = false;
        if (_sceneTexture != null)
        {
            if (_sceneTexture.width != w || _sceneTexture.height != h)
            {
                Debug.Log($"Recreating scene texture.. Old: {_sceneTexture.width}x{_sceneTexture.height } MSAA={_sceneTexture.antiAliasing} [{aa}] New: {w}x{h} MSAA={aa} [{format}]");
                Destroy(_sceneTexture);
                _sceneTexture = null;
                recreatedTex = true;
            }
        }

        if (_sceneTexture == null)
        {
            _sceneTexture = new RenderTexture(w, h, 0, format, 0);
            _sceneTexture.depth = 32;
            _sceneTexture.antiAliasing = aa;

            // OpenVR assumes floating point render targets are linear unless otherwise specified.
            var colorSpace = (hdr && QualitySettings.activeColorSpace == ColorSpace.Gamma) ? EColorSpace.Gamma : EColorSpace.Auto;
            SteamVR.OpenVRMagic.SetColorSpace(colorSpace);
            if(recreatedTex)
            {
                OnResolutionChanged?.Invoke(w,h);
            }
        }
            
        return _sceneTexture;
    }

    #endregion

    #region Enable / Disable

    void OnDisable()
    {
        SteamVR_Render.Remove(this);
    }

        public static bool doomp = false;
        void Update()
        {
            doomp = false;
            if(Input.GetKeyDown(KeyCode.F4))
            {
                Debug.Log("Doomping rendertextures...");
                doomp = true;
            }
        }

        void LateUpdate()
        {

            doomp = false;
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Debug.Log("Doomping rendertextures...");
                doomp = true;
            }
        }


    void OnEnable()
    {
        // Bail if no hmd is connected
        var vr = SteamVR.instance;
        if (vr == null)
        {
            if (head != null)
            {
                head.GetComponent<SteamVR_GameView>().enabled = false;
                head.GetComponent<SteamVR_TrackedObject>().enabled = false;
            }

            if (flip != null)
                flip.enabled = false;

            enabled = false;
            return;
        }
        // Ensure rig is properly set up
        Expand();

        if (blitMaterial == null)
        {
            blitMaterial = new Material(VRShaders.GetShader(VRShaders.VRShader.blit));
        }

        // Set remaining hmd specific settings
        var camera = GetComponent<Camera>();
        camera.fieldOfView = vr.fieldOfView;
        camera.aspect = vr.aspect;
        camera.eventMask = 0;           // disable mouse events
        camera.orthographic = false;    // force perspective
        camera.enabled = false;         // manually rendered by SteamVR_Render

        if (camera.actualRenderingPath != RenderingPath.Forward && QualitySettings.antiAliasing > 1)
        {
            Debug.LogWarning("MSAA only supported in Forward rendering path. (disabling MSAA)");
            QualitySettings.antiAliasing = 0;
        }

        // Ensure game view camera hdr setting matches
        var headCam = head.GetComponent<Camera>();
        if (headCam != null)
        {
            headCam.renderingPath = camera.renderingPath;
        }

        if (ears == null)
        {
            var e = transform.GetComponentInChildren<SteamVR_Ears>();
            if (e != null)
                _ears = e.transform;
        }

        if (ears != null)
            ears.GetComponent<SteamVR_Ears>().vrcam = this;

        SteamVR_Render.Add(this);
    }

        #endregion

        #region Functionality to ensure SteamVR_Camera component is always the last component on an object

        void Awake()
        {
            camera = GetComponent<Camera>();
            ForceLast();
        }

        public void ForceLast()
        {
            if (isLast)
            {
                if (this.flip == null)
                {
                    this.flip = base.gameObject.GetComponent<SteamVR_CameraFlip>();
                }
             return;
            }
            Component[] components = base.GetComponents<Component>();
            if (this != components[components.Length - 1] || this.flip == null)
            {
                if (this.flip == null)
                {
                    this.flip = base.gameObject.AddComponent<SteamVR_CameraFlip>();
                }
                GameObject g = gameObject;
                DestroyImmediate(this);
                isLast = true;
                g.AddComponent<SteamVR_Camera>().ForceLast();
            }
        }
        static bool isLast;

        #endregion

        #region Expand / Collapse object hierarchy

        const string eyeSuffix = " (eye)";
    const string earsSuffix = " (ears)";
    const string headSuffix = " (head)";
    const string originSuffix = " (origin)";
    public string baseName { get { return name.EndsWith(eyeSuffix) ? name.Substring(0, name.Length - eyeSuffix.Length) : name; } }

        // Object hierarchy creation to make it easy to parent other objects appropriately,
        // otherwise this gets called on demand at runtime. Remaining initialization is
        // performed at startup, once the hmd has been identified.
        public void Expand()
        {
            Transform transform = base.transform.parent;
            if (transform == null)
            {
                transform = new GameObject(base.name + " (origin)").transform;
                transform.localPosition = base.transform.localPosition;
                transform.localRotation = base.transform.localRotation;
                transform.localScale = base.transform.localScale;
            }
            if (this.head == null)
            {
                this._head = new GameObject(base.name + " (head)").transform;
                if (SteamVR_Camera.useHeadTracking)
                {
                    _head.gameObject.AddComponent<SteamVR_TrackedObject>();
                }

                _head.gameObject.AddComponent<SteamVR_GameView>();



                this.head.position = base.transform.position;
                this.head.rotation = base.transform.rotation;
                this.head.localScale = Vector3.one;
                this.head.tag = base.tag;
            }
            this.head.parent = transform;
            Camera component = this.head.GetComponent<Camera>();
            component.clearFlags = CameraClearFlags.Nothing;
            component.cullingMask = 0;
            component.eventMask = 0;
            component.orthographic = true;
            component.orthographicSize = 1f;
            component.nearClipPlane = 0f;
            component.farClipPlane = 1f;
            component.useOcclusionCulling = false;
            if (transform.parent != this.head)
            {
                transform.parent = this.head;
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
                while (base.transform.childCount > 0)
                {
                    base.transform.GetChild(0).parent = this.head;
                }

                AudioListener component3 = base.GetComponent<AudioListener>();
                if (component3 != null)
                {
                    UnityEngine.Object.DestroyImmediate(component3);
                    this._ears = new GameObject(base.name + " (ears)").transform;
                    _ears.gameObject.AddComponent<SteamVR_Ears>();
                    this.ears.parent = this._head;
                    this.ears.localPosition = Vector3.zero;
                    this.ears.localRotation = Quaternion.identity;
                    this.ears.localScale = Vector3.one;
                }
            }
            if (!base.name.EndsWith(" (eye)"))
            {
                base.name += " (eye)";
            }
        }

        public void Collapse()
    {
        transform.parent = null;

        // Move children and components from head back to camera.
        while (head.childCount > 0)
            head.GetChild(0).parent = transform;

        if (ears != null)
        {
            while (ears.childCount > 0)
                ears.GetChild(0).parent = transform;

            DestroyImmediate(ears.gameObject);
            _ears = null;

            gameObject.AddComponent<AudioListener>();
        }

        if (origin != null)
        {
            // If we created the origin originally, destroy it now.
            if (origin.name.EndsWith(originSuffix))
            {
                // Reparent any children so we don't accidentally delete them.
                var _origin = origin;
                while (_origin.childCount > 0)
                    _origin.GetChild(0).parent = _origin.parent;

                DestroyImmediate(_origin.gameObject);
            }
            else
            {
                transform.parent = origin;
            }
        }

        DestroyImmediate(head.gameObject);
        _head = null;

        if (name.EndsWith(eyeSuffix))
            name = name.Substring(0, name.Length - eyeSuffix.Length);
    }

    #endregion

    #region Render callbacks

    void OnPreRender()
    {
        if (flip)
            flip.enabled = (SteamVR_Render.Top() == this && SteamVR.instance.textureType == ETextureType.DirectX);

        var headCam = head.GetComponent<Camera>();
        if (headCam != null)
            headCam.enabled = (SteamVR_Render.Top() == this);

        if (wireframe)
            GL.wireframe = true;
    }

    void OnPostRender()
    {
        if (wireframe)
            GL.wireframe = false;
    }



    public static void DumpRenderTexture(RenderTexture rt, string pngOutPath)
    {
        Texture2D tex = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        byte[] textureBytes = ImageConversion.EncodeToPNG(tex);
            Debug.Log($"Writing texture to {pngOutPath}");
        File.WriteAllBytes(pngOutPath, textureBytes);
    }


        void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
            if (SteamVR_Render.Top() == this)
            {
                int eventID;
                if (SteamVR_Render.eye == EVREye.Eye_Left)
                {
                    // Get gpu started on work early to avoid bubbles at the top of the frame.
                    SteamVR_Utils.QueueEventOnRenderThread(SteamVR.OpenVRMagic.k_nRenderEventID_Flush);

                    eventID = SteamVR.OpenVRMagic.k_nRenderEventID_SubmitL;
                }
                else
                {
                    eventID = SteamVR.OpenVRMagic.k_nRenderEventID_SubmitR;
                }

                // Queue up a call on the render thread to Submit our render target to the compositor.
                SteamVR_Utils.QueueEventOnRenderThread(eventID);
            }
            if (SteamVR_Camera.doomp)
            {
                Debug.Log(Time.frameCount.ToString() + "/Camera_OnRenderImage");
                DumpRenderTexture(src, Application.streamingAssetsPath + "/Camera_OnRenderImage_src.png");
            }

            RenderTexture.active = dest;
            SteamVR_Camera.blitMaterial.mainTexture = src;

            GL.PushMatrix();
            GL.LoadOrtho();
            SteamVR_Camera.blitMaterial.SetPass(0);
            GL.Begin(7);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-1, 1, 0);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, -1, 0);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-1, -1, 0);
            GL.End();
            GL.PopMatrix();


            if (SteamVR_Camera.doomp)
            {
                DumpRenderTexture(dest, Application.streamingAssetsPath + "/Camera_OnRenderImage_dst.png");
            }

            RenderTexture.active = null; 
        }

        void OnDestroy()
        {
            /// Reset Forcelast() so we get CameraFlip initialization working ---
            isLast = false;
        }

    public static bool useHeadTracking = true;
    #endregion

}
}