﻿Shader "GUI/Text Shader Custom" {
    Properties {
        _MainTex ("Font Texture", 2D) = "white" {}
    }
 
    SubShader {
 
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Lighting Off Cull Off ZTest Always ZWrite Off Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass { 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
 
            #include "UnityCG.cginc"
 
            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
 
            struct v2f {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
 
            sampler2D _MainTex;
            uniform float4 _MainTex_ST;
           
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
                return o;
            }
 
            half4 frag (v2f i) : COLOR
            {
                float4 col = tex2D(_MainTex, i.texcoord);
                return col;
            }
            ENDCG
        }
    }  
}