﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;

namespace Valve.VR
{
    public class SteamVR_Settings
    {
        private static SteamVR_Settings _instance;
        public static SteamVR_Settings instance
        {
            get
            {
                LoadInstance();

                return _instance;
            }
        }

        public bool pauseGameWhenDashboardVisible = true;
        public bool lockPhysicsUpdateRateToRenderFrequency = true;
        public ETrackingUniverseOrigin trackingSpace
        {
            get
            {
                return trackingSpaceOrigin;
            }
            set
            {
                trackingSpaceOrigin = value;
                if (SteamVR_Behaviour.isPlaying)
                    SteamVR_Action_Pose.SetTrackingUniverseOrigin(trackingSpaceOrigin);
            }
        }

        
        private ETrackingUniverseOrigin trackingSpaceOrigin = ETrackingUniverseOrigin.TrackingUniverseStanding;

        public string actionsFilePath = "actions.json";

        public string steamVRInputPath = "SteamVR_Input";

        public SteamVR_UpdateModes inputUpdateMode = SteamVR_UpdateModes.OnUpdate;
        public SteamVR_UpdateModes poseUpdateMode = SteamVR_UpdateModes.OnPreCull;

        public bool activateFirstActionSetOnStart = true;

        public string editorAppKey;

        public bool autoEnableVR = true;

        public bool legacyMixedRealityCamera = true;

        public SteamVR_Action_Pose mixedRealityCameraPose = SteamVR_Input.GetPoseAction("ExternalCamera");

        public SteamVR_Input_Sources mixedRealityCameraInputSource = SteamVR_Input_Sources.Camera;

        public bool mixedRealityActionSetAutoEnable = true;

        public GameObject previewHandLeft;

        public GameObject previewHandRight;


        private const string previewLeftDefaultAssetName = "vr_glove_left_model_slim";
        private const string previewRightDefaultAssetName = "vr_glove_right_model_slim";


        public bool IsInputUpdateMode(SteamVR_UpdateModes tocheck)
        {
            return (inputUpdateMode & tocheck) == tocheck;
        }
        public bool IsPoseUpdateMode(SteamVR_UpdateModes tocheck)
        {
            return (poseUpdateMode & tocheck) == tocheck;
        }

        public static void VerifyScriptableObject()
        {
            LoadInstance();
        }

        private static void LoadInstance()
        {
            if (_instance == null)
            {
                //_instance = Resources.Load<SteamVR_Settings>("SteamVR_Settings");

                if (_instance == null)
                {
                    _instance = new SteamVR_Settings();

#if UNITY_EDITOR
                    string localFolderPath = SteamVR.GetSteamVRResourcesFolderPath(true);
                    string assetPath = System.IO.Path.Combine(localFolderPath, "SteamVR_Settings.asset");

                    UnityEditor.AssetDatabase.CreateAsset(_instance, assetPath);
                    UnityEditor.AssetDatabase.SaveAssets();
#endif
                }

                SetDefaultsIfNeeded();
            }
        }

        public static void Save()
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(instance);
            UnityEditor.AssetDatabase.SaveAssets();
#endif
        }

        private const string defaultSettingsAssetName = "SteamVR_Settings";

        private static void SetDefaultsIfNeeded()
        {
            if (string.IsNullOrEmpty(_instance.editorAppKey))
            {
                _instance.editorAppKey = SteamVR.GenerateAppKey();
                Debug.Log("<b>[SteamVR Setup]</b> Generated you an editor app key of: " + _instance.editorAppKey + ". This lets the editor tell SteamVR what project this is. Has no effect on builds. This can be changed in Assets/SteamVR/Resources/SteamVR_Settings");
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(_instance);
                UnityEditor.AssetDatabase.SaveAssets();
#endif
            }

#if UNITY_EDITOR
            if (_instance.previewHandLeft == null)
                _instance.previewHandLeft = FindDefaultPreviewHand(previewLeftDefaultAssetName);

            if (_instance.previewHandRight == null)
                _instance.previewHandRight = FindDefaultPreviewHand(previewRightDefaultAssetName);
#endif

#if OPENVR_XR_API
            Unity.XR.OpenVR.OpenVRSettings settings = Unity.XR.OpenVR.OpenVRSettings.GetSettings();
            settings.ActionManifestFileRelativeFilePath = SteamVR_Input.GetActionsFilePath();

#if UNITY_EDITOR
            settings.EditorAppKey = _instance.editorAppKey;
#endif
#endif
        }

        private static GameObject FindDefaultPreviewHand(string assetName)
        {
#if UNITY_EDITOR
            string[] defaultPaths = UnityEditor.AssetDatabase.FindAssets(string.Format("t:Prefab {0}", assetName));
            if (defaultPaths != null && defaultPaths.Length > 0)
            {
                string defaultGUID = defaultPaths[0];
                string defaultPath = UnityEditor.AssetDatabase.GUIDToAssetPath(defaultGUID);
                GameObject defaultAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(defaultPath);

                if (defaultAsset == null)
                    Debug.LogError("[SteamVR] Could not load default hand preview prefab: " + assetName + ". Found path: " + defaultPath);

                return defaultAsset;
            }
            //else //todo: this will generally fail on the first try but will try again before its an issue.
                //Debug.LogError("[SteamVR] Could not load default hand preview prefab: " + assetName);
#endif

            return null;

        }
    }
}