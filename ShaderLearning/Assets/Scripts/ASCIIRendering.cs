//Made By Stefan Jovanović
//Twitter: https://twitter.com/SJovGD
//Reddit: https://www.reddit.com/user/sjovanovic3107
//Unity Asset Store: https://assetstore.unity.com/publishers/32235
//Itch.io: https://stefanjo.itch.io/

using System;
using UnityEngine;
namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    public class ASCIIRendering : MonoBehaviour
    {

        //Variables required for the ImageEffect
        public Shader ASCIIShader;
        private Material m_ASCII;

        //Values for the Shader
        public Texture2D CharTex;
        public int tilesX = 96;
        public int tilesY = 54;
        public int charWidth = 20;
        public int charHeight = 20;
        public int charCount = 8;
        public float brightness = .8f;
        public bool monochromatic = false;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            m_ASCII = new Material(ASCIIShader);
            m_ASCII.SetTexture("_CharTex", CharTex);

            m_ASCII.SetFloat("_tilesX", tilesX);
            m_ASCII.SetFloat("_tilesY", tilesY);
            m_ASCII.SetFloat("_charCount", charCount);



            m_ASCII.SetFloat("_monoGray", (float)Convert.ToDouble(monoGray));
            m_ASCII.SetFloat("_monoRed", (float)Convert.ToDouble(monoRed));
            m_ASCII.SetFloat("_monoGreen", (float)Convert.ToDouble(monoGreen));
            m_ASCII.SetFloat("_monoBlue", (float)Convert.ToDouble(monoBlue));

            brightnessMultiplier = Mathf.Clamp(brightnessMultiplier, 0f, 100f);
            m_ASCII.SetFloat("_brightnessMultiplier", brightnessMultiplier);
            Graphics.Blit(source, destination, m_ASCII);
        }
    }
}
