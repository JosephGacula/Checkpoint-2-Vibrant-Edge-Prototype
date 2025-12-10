Shader "Custom/CharacterColor"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _TargetColor ("New Headband Color", Color) = (1, 1, 1, 1)
        _RedTolerance ("Red Tolerance", Range(0,1)) = 0.2
    }

    SubShader
    {
        Tags 
        { 
            "RenderType"="Transparent" 
            "Queue"="Transparent" 
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TargetColor;
            float _RedTolerance;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);

                // Detect red pixels 
                bool isRed =
                    col.r > (col.g + _RedTolerance) &&
                    col.r > (col.b + _RedTolerance);

                if (isRed)
                {
                    // Replace red region with target color, keep alpha
                    return float4(_TargetColor.rgb, col.a);
                }

                // Normal pixel
                return col;
            }
            ENDCG
        }
    }
}