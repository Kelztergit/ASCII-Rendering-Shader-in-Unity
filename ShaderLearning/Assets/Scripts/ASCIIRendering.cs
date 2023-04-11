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
        [Header("Put in your chartex/charmap")]
        public Texture2D CharTex;
        [Header("The final 'resolution' you want to see, ideally same ratio as screen is")]
        [Tooltip("Horizontal, left-right")]
        public int tilesX = 120;
        [Tooltip("Vertical, up-down")]
        public int tilesY = 60;
        [Header("How many characters are in the map")]
        public int charCount = 8;
        

        [Space]

        [Header("Visual Settings")]
        [Tooltip("A value between 0 and 100 that controls the brightness of the background behind the characters")]
        public float brightnessMultiplier = 0f;

        [Tooltip("you can not mix these, pick one and have the others set to false, these change the colour of the characters")]
        public bool monoGray = false;
        [Tooltip("you can not mix these, pick one and have the others set to false, these change the colour of the characters")]
        public bool monoRed = false;
        [Tooltip("you can not mix these, pick one and have the others set to false, these change the colour of the characters")]
        public bool monoGreen = false;
        [Tooltip("you can not mix these, pick one and have the others set to false, these change the colour of the characters")]
        public bool monoBlue = false;

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
