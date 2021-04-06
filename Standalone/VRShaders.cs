using UnityEngine;

namespace Assets.SteamVR_Standalone.Standalone
{
    public static class VRShaders
    {
        public enum VRShader
        {
            blit,
            blitFlip,
            overlay,
            occlusion,
            fade
        }


        static AssetBundle assetBundle;

        static Shader blit;
        static Shader blitFlip;
        static Shader overlay;
        static Shader occlusion;
        static Shader fade;

        public static Shader GetShader(VRShader shader)
        {
            if(blit == null)
            {
                TryLoadShaders();
            }

            switch(shader)
            {
                case (VRShader.blit):
                    return blit;
                case (VRShader.blitFlip):
                    return blitFlip;
                case (VRShader.overlay):
                    return overlay;
                case (VRShader.occlusion):
                    return occlusion;
                case (VRShader.fade):
                    return fade;
            }
            Debug.LogWarning("No valid shader found");
            return null;
        }

        public static void TryLoadShaders()
        {
            if(assetBundle == null)
            {
                assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/vrshaders");
                if (assetBundle == null)
                {
                    Debug.LogError("No assetbundle present!");
                    return;
                }
            }
            Debug.Log("Loading shaders from asset bundle...");

            occlusion = assetBundle.LoadAsset("assets/steamvr/resources/steamvr_hiddenarea.shader").Cast<Shader>();
            blit = assetBundle.LoadAsset("assets/steamvr/resources/steamvr_blit.shader").Cast<Shader>();
            blitFlip = assetBundle.LoadAsset("assets/steamvr/resources/steamvr_blitFlip.shader").Cast<Shader>();
            overlay = assetBundle.LoadAsset("assets/steamvr/resources/steamvr_overlay.shader").Cast<Shader>();
            fade = assetBundle.LoadAsset("assets/steamvr/resources/steamvr_fade.shader").Cast<Shader>();
            string[] allAssetNames = assetBundle.GetAllAssetNames();
            for (int i = 0; i < allAssetNames.Length; i++)
            {
                Debug.Log(allAssetNames[i]);
            }
        }
    }
}
