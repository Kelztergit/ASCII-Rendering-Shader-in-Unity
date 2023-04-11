Shader "Custom/ASCIIShader" {
    Properties{
        _MainTex("Base", 2D) = "white" {}
        _CharTex("Character Map", 2D) = "white" {}
        _tilesX("X Characters", int) = 120
        _tilesY("Y Characters", int) = 60
        _monoGray("Monogray", int) = 0
        _monoRed("Monored", int) = 0
        _monoGreen("Monogreen",int)=0
        _monoBlue("Monoblue",int)=0
        _charCount("Number of Characters", int) = 8
        _brightnessMultiplier("Darkness", Float) = 0.0
    }

    SubShader{
        Pass{
            CGPROGRAM
            #pragma fragment frag
            #pragma vertex vert_img
            #pragma target 3.0
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv  : TEXCOORD0;
            };

            sampler2D _MainTex;
            sampler2D _CharTex;
            float _tilesX;
            float _tilesY;
            float _tileW;
            float _tileH;
            float _brightnessMultiplier;

            int _monoGray;
            int _monoRed;
            int _monoGreen;
            int _monoBlue;

            int _charCount;

            float4 frag(v2f i) : COLOR{
                _tileW = _ScreenParams.x / _tilesX;
                _tileH = _ScreenParams.y / _tilesY;

                float2 newCoord = float2(saturate(floor(_tilesX * i.uv.x) / (_tilesX)), saturate(floor(_tilesY * i.uv.y) / (_tilesY)));
                float4 col = tex2D(_MainTex,newCoord);
                float gray = saturate((col.r + col.g + col.b)/3.0f); 

                int charIndex = round(gray * (_charCount-1));
                float2 charCoord = float2(((_ScreenParams.x * i.uv.x) % _tileW + (_tileW-1)*charIndex)/ ((_tileW - 1)* _charCount), saturate(((int)(_ScreenParams.y * i.uv.y) % _tileH) / (_tileH-1)));
                float4 charCol = tex2D(_CharTex, charCoord);

                float4 result;
                if(_monoGray == 1) {
                    result = float4(gray, gray, gray, 1);
                } else if(_monoBlue == 1) {
                    result = float4(0, 0, gray, 1);                
                } else if(_monoGreen == 1) {
                    result = float4(0, gray, 0, 1);
                } else if(_monoRed == 1) {
                    result = float4(gray, 0, 0, 1);
                } else {
                    result = col;
                }

                float4 finalColor;
                if (((charCol.r+charCol.g+charCol.g)/3)  > .8f) {
                    finalColor = result * charCol;
                } else {
                    finalColor = col * _brightnessMultiplier;
                }

                return finalColor;
            }
            ENDCG
        }
    }
    FallBack off
}
