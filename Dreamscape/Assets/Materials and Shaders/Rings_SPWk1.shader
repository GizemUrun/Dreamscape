Shader "Unlit/Rings_SPWk1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            //cosine based palette, 4 vec3 params
            struct ExampleStruct {
                float3 palette(float t)
                {


                    float3 a = float3(0.5, 0.5, 0.5);
                    float3 b = float3(0.5, 0.5, 0.5);
                    float3 c = float3(1.0, 1.0, 1.0);
                    float3 d = float3(0.0, 0.1, 0.2);


                    return a + b * cos(6.28318 * (c * t + d));

                }
            };

            fixed4 frag(v2f i) : SV_Target
            {
                ExampleStruct f;

                // Normalized pixel coordinates (from 0 to 1)
                float2 uv = i.uv;//(fragCoord * 2.0 - resolution.xy) / resolution.y;

                // Time varying pixel color
                float3 col = 0.5 + 0.5 * cos(_Time + uv.xyx + float3(0, 2, 4));

                float d = length(uv * 8.0);

                d = sin(d + _Time);

                float3 colour = f.palette(d + _Time.y);


                // Output to screen
                return float4(colour, 1.0);
            }

            
            ENDCG
        }
    }
}
