// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

	Shader "Custom/mandelbrot shader" 
	{
		Properties{
			Xcent ("Xcent", Float) = -1.0 
			Ycent ("Ycent", Float) = 0.0
			Zoom ("Zoom", Float) = 1.0 
			Iterations ("Iterations", Float) = 50.0 
		}

		SubShader
		{
			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				
				#include "UnityCG.cginc"


				struct vertInput
				{
					float4 pos : POSITION;
					float2 uv : TEXCOORD0;
				};
			
				struct vertOutput
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				float Xcent;
				float Ycent;
				float Zoom;
				int Iterations;
				vertOutput vert(vertInput input)
				{
					vertOutput o;
					o.pos = UnityObjectToClipPos(input.pos);
					o.uv = input.uv;
					return o;
				}

				half4 frag(vertOutput output) : COLOR
				{
				//	float cx = (float)((int)((Xcent + (output.uv.x - 0.5)/Zoom)*200))/200;
				//	float cy = (float)((int)((Ycent + (output.uv.y - 0.5)*9/16/Zoom)*200))/200;
					float cx = Xcent + (output.uv.x - 0.5)/Zoom;
					float cy = Ycent + (output.uv.y - 0.5)*9/16/Zoom;
					float p = (cx - 0.25)*(cx - 0.25) + cy*cy;
					if ((cx+1)*(cx+1)+cy*cy<0.0625 || p*(p+(cx-0.25))<0.25*cy*cy){
						return half4(0,0,0,1);
					}
					float x = cx;
					float y = cy;
					float temp;

					for (float i = 0; i<Iterations; i++){
						temp = cx + x*x - y*y;
						y = cy + 2*x*y;
						x = temp;
						if (x*x+y*y>4){
							// colouring Scheme
							float n = i/Iterations;
							if (n>0.5){
								return half4(1,n,n,1);
							}
							return half4(n,0,0,1);
						}
					}
					return half4(0,0,0,1);
				}
				ENDCG
			}
		}	
	}