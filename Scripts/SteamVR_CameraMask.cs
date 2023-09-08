using Assets.SteamVR_Standalone.Standalone;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Valve.VR
{

    public class SteamVR_CameraMask : MonoBehaviour
    {
        public SteamVR_CameraMask(IntPtr value)
: base(value) { }

        public MeshRenderer meshRenderer;

        public static Material occlusionMaterial;


        private static Mesh[] hiddenAreaMeshes = new Mesh[2];
        private static Mesh[] visibleAreaMeshes = new Mesh[2];

        public MeshFilter meshFilter;


        private void Awake()
        {
            this.meshFilter = GetComponent<MeshFilter>();
            if (this.meshFilter == null)
            {
                this.meshFilter = base.gameObject.AddComponent<MeshFilter>();
            }
            if (SteamVR_CameraMask.occlusionMaterial == null)
            {
                SteamVR_CameraMask.occlusionMaterial = new Material(VRShaders.GetShader(VRShaders.VRShader.occlusion));
            }
            meshRenderer = base.GetComponent<MeshRenderer>();
            if (meshRenderer == null)
            {
                meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
            }
            meshRenderer.material = SteamVR_CameraMask.occlusionMaterial;
            meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
            meshRenderer.receiveShadows = false;
            meshRenderer.lightProbeUsage = LightProbeUsage.Off;
            meshRenderer.lightProbeUsage = LightProbeUsage.Off;
            meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
        }


        public void Set(SteamVR vr, EVREye eye)
        {
            this.meshFilter.mesh = getHiddenAreaMask(vr, eye);
        }

        public void Clear()
        {
            this.meshFilter.mesh = null;
        }

        public static Mesh getHiddenAreaMask(SteamVR vr, EVREye eye)
        {
            if (SteamVR_CameraMask.hiddenAreaMeshes[(int)eye] == null)
            {
                SteamVR_CameraMask.hiddenAreaMeshes[(int)eye] = SteamVR_CameraMask.CreateHiddenAreaMesh(vr.hmd.GetHiddenAreaMesh(eye, EHiddenAreaMeshType.k_eHiddenAreaMesh_Standard), vr.textureBounds[(int)eye]);
            }

            return SteamVR_CameraMask.hiddenAreaMeshes[(int)eye];
        }

        public static Mesh getVisibleAreaMask(SteamVR vr, EVREye eye)
        {
            if (SteamVR_CameraMask.visibleAreaMeshes[(int)eye] == null)
            {
                SteamVR_CameraMask.visibleAreaMeshes[(int)eye] = CreateVisibleAreaMesh(vr.hmd.GetHiddenAreaMesh(eye, EHiddenAreaMeshType.k_eHiddenAreaMesh_Inverse), vr.textureBounds[(int)eye]);
            }

            return SteamVR_CameraMask.visibleAreaMeshes[(int)eye];
        }

        private static Mesh CreateVisibleAreaMesh(HiddenAreaMesh_t src, VRTextureBounds_t bounds)
        {
            // Modified from CreateHiddenAreaMesh, which adds padding around the mask to fill the screen

            if (src.unTriangleCount == 0u)
            {
                return null;
            }

            // 3 vertices for each triangle, 2 floats ( x/y ) for each vertex ?
            float[] rawVertices = new float[src.unTriangleCount * 3u * 2u];
            Marshal.Copy(src.pVertexData, rawVertices, 0, rawVertices.Length);


            // 3 vertices for each triangle. I guess they don't share vertices.
            Vector3[] vertices = new Vector3[src.unTriangleCount * 3u]; 
            int[] triangles = new int[src.unTriangleCount * 3u];    

            float uMin = 2f * bounds.uMin - 1f;
            float uMax = 2f * bounds.uMax - 1f;
            float vMin = 2f * bounds.vMin - 1f;
            float vMax = 2f * bounds.vMax - 1f;

            int rawFloatIndex = 0;

            for (int i = 0; i < vertices.Length; i++)
            {
                float x = rawVertices[rawFloatIndex++];
                float y = rawVertices[rawFloatIndex++];

                x = SteamVR_Utils.Lerp(uMin, uMax, x);
                y = SteamVR_Utils.Lerp(vMin, vMax, y);

                vertices[i] = new Vector3(x, y, 0);
                triangles[i] = i;
            }

            Mesh m = new()
            {
                vertices = vertices,
                triangles = triangles,
                bounds = new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue))
            };

            m.RecalculateNormals();
            m.bounds = new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));

            ///////////////////
            // UVs
            ///////////////////

            Vector2[] uvs = new Vector2[m.vertices.Length];

            // Screen space is -1 to 1?
            
            float minX = -1;
            float maxX = 1;

            float minY = -1;
            float maxY = 1;
            
            for (int i = 0; i < m.vertices.Length; i++)
            {
                Vector3 vertex = m.vertices[i];

                float u = (vertex.x - minX) / (maxX - minX);
                float v = (vertex.y - minY) / (maxY - minY);

                uvs[i] = new Vector2(u, v);
            }

            m.uv = uvs;

            return m;
        }

        public static Mesh CreateHiddenAreaMesh(HiddenAreaMesh_t src, VRTextureBounds_t bounds)
        {
            if (src.unTriangleCount == 0u)
            {
                return null;
            }
            float[] array = new float[src.unTriangleCount * 3u * 2u];
            Marshal.Copy(src.pVertexData, array, 0, array.Length);
            Vector3[] array2 = new Vector3[src.unTriangleCount * 3u + 12u];
            int[] array3 = new int[src.unTriangleCount * 3u + 24u];
            float num = 2f * bounds.uMin - 1f;
            float num2 = 2f * bounds.uMax - 1f;
            float num3 = 2f * bounds.vMin - 1f;
            float num4 = 2f * bounds.vMax - 1f;
            int num5 = 0;
            int num6 = 0;
            while ((long)num5 < (long)((ulong)(src.unTriangleCount * 3u)))
            {
                float x = SteamVR_Utils.Lerp(num, num2, array[num6++]);
                float y = SteamVR_Utils.Lerp(num3, num4, array[num6++]);
                array2[num5] = new Vector3(x, y, 0f);
                array3[num5] = num5;
                num5++;
            }
            int num7 = (int)(src.unTriangleCount * 3u);
            int num8 = num7;
            array2[num8++] = new Vector3(-1f, -1f, 0f);
            array2[num8++] = new Vector3(num, -1f, 0f);
            array2[num8++] = new Vector3(-1f, 1f, 0f);
            array2[num8++] = new Vector3(num, 1f, 0f);
            array2[num8++] = new Vector3(num2, -1f, 0f);
            array2[num8++] = new Vector3(1f, -1f, 0f);
            array2[num8++] = new Vector3(num2, 1f, 0f);
            array2[num8++] = new Vector3(1f, 1f, 0f);
            array2[num8++] = new Vector3(num, num3, 0f);
            array2[num8++] = new Vector3(num2, num3, 0f);
            array2[num8++] = new Vector3(num, num4, 0f);
            array2[num8++] = new Vector3(num2, num4, 0f);
            int num9 = num7;
            array3[num9++] = num7;
            array3[num9++] = num7 + 1;
            array3[num9++] = num7 + 2;
            array3[num9++] = num7 + 2;
            array3[num9++] = num7 + 1;
            array3[num9++] = num7 + 3;
            array3[num9++] = num7 + 4;
            array3[num9++] = num7 + 5;
            array3[num9++] = num7 + 6;
            array3[num9++] = num7 + 6;
            array3[num9++] = num7 + 5;
            array3[num9++] = num7 + 7;
            array3[num9++] = num7 + 1;
            array3[num9++] = num7 + 4;
            array3[num9++] = num7 + 8;
            array3[num9++] = num7 + 8;
            array3[num9++] = num7 + 4;
            array3[num9++] = num7 + 9;
            array3[num9++] = num7 + 10;
            array3[num9++] = num7 + 11;
            array3[num9++] = num7 + 3;
            array3[num9++] = num7 + 3;
            array3[num9++] = num7 + 11;
            array3[num9++] = num7 + 6;
            Mesh m = new Mesh();
            m.vertices = array2;
            m.triangles = array3;
            m.bounds = new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
            return m;
        }



    }
}
