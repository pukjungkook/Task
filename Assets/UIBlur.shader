Shader "UIBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 10)) = 2
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "Blur"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float _BlurSize;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.uv = IN.uv;
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                float2 uv = IN.uv;
                float blur = _BlurSize / 1024.0; // scale for screen size

                float4 col = float4(0,0,0,0);
                col += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + float2(-blur, -blur));
                col += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + float2(-blur,  blur));
                col += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + float2( blur, -blur));
                col += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + float2( blur,  blur));
                col *= 0.25;

                return col;
            }
            ENDHLSL
        }
    }
}
