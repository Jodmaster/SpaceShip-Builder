Shader "Custom/Ship_outline"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (1, 1, 0, 1)
        _OutlineWidth("Outline Width", Range(0.001, 0.1)) = 0.005
    }
    
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float4 _OutlineColor;
            float _OutlineWidth;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 outlineColor = _OutlineColor;
                half4 color = outlineColor;

                float d = length(i.pos.xy - _ScreenParams.xy);
                float outline = saturate(_OutlineWidth / d);
                if (d < _OutlineWidth)
                {
                    return outlineColor;
                }
                else
                {
                    return color;
                }
            }
            ENDCG
        }
    }
}
