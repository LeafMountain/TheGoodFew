// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Outline Shader"{

	//Variables
	Properties {
		_MainTexture("Main Color (RGB) Hello!", 2D) = "white" {}
		_Color("Coloror", Color) = (1, 1, 1, 1)

		_ExtrudeAmount("Extrude Amount", Range(0, .2)) = .2
	}

	SubShader{

		Pass{
			//Nvidia CG
			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			//Vertex to fragment = v2f
			struct v2f {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			//Adding the variables
			float4 _Color;
			sampler2D _MainTexture;
			float _ExtrudeAmount;

			v2f vertexFunction(appdata IN){
				v2f OUT;

				IN.vertex.xyz += IN.normal.xyz * _ExtrudeAmount;

				//For the camera ??
				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			//Color it in
			fixed4 fragmentFunction(v2f IN) : SV_Target {
				// float4 textureColor = tex2D(_MainTexture, IN.uv);
				
				return _Color;
			}


			ENDCG
		}
		
		Pass{
			//Nvidia CG
			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			//Vertex to fragment = v2f
			struct v2f {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			//Adding the variables
			// float4 _Color;
			sampler2D _MainTexture;
			float _ExtrudeAmount;

			v2f vertexFunction(appdata IN){
				v2f OUT;
				
				//For the camera ??
				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			//Color it in
			fixed4 fragmentFunction(v2f IN) : SV_Target {
				float4 textureColor = tex2D(_MainTexture, IN.uv);
				
				return textureColor;
			}


			ENDCG
		}
	}
}