Shader "UI/BackgroundBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(6,10)) = 8
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        GrabPass { "_GrabTexture" }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            float _BlurSize;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uvgrab = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
           
                #if defined(SHADER_API_METAL) || defined(SHADER_API_GLES)
                    float2 uv = i.uvgrab.xy;
                #else
                    float2 uv = i.uvgrab.xy / i.uvgrab.w;
                #endif

                float2 texel = _GrabTexture_TexelSize.xy * _BlurSize;

                half4 col = tex2D(_GrabTexture, uv) * 0.2;
                col += tex2D(_GrabTexture, uv + texel * float2(1,0)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(-1,0)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(0,1)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(0,-1)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(1,1)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(-1,1)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(1,-1)) * 0.1;
                col += tex2D(_GrabTexture, uv + texel * float2(-1,-1)) * 0.1;

                return col;
            }
            ENDCG
        }
    }

    FallBack "UI/Default"
}
