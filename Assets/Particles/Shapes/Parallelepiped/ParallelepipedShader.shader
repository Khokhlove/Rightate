// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ParallelepipedShader"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (5.000555,0.4651679,22.21177,1)
		_Texture("Texture", 2D) = "white" {}
		_IsCorrect("_IsCorrect", Int) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "ForceNoShadowCasting" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 2.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform int _IsCorrect;
		uniform half4 _Color0;
		uniform sampler2D _Texture;
		uniform half4 _Texture_ST;


		float2 voronoihash18_g7( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi18_g7( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash18_g7( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			half4 color14_g7 = IsGammaSpace() ? half4(8.339426,10.20646,0,1) : half4(106.2918,165.7774,0,1);
			half4 temp_output_9_0 = ( (float)_IsCorrect == 1.0 ? _Color0 : color14_g7 );
			o.Albedo = temp_output_9_0.rgb;
			o.Emission = temp_output_9_0.rgb;
			half time18_g7 = ( _Time.y * 3.0 );
			float2 coords18_g7 = i.uv_texcoord * 1.0;
			float2 id18_g7 = 0;
			float2 uv18_g7 = 0;
			float voroi18_g7 = voronoi18_g7( coords18_g7, time18_g7, id18_g7, uv18_g7, 0 );
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			o.Alpha = ( voroi18_g7 * tex2D( _Texture, uv_Texture ).a );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
1983;29;1920;973;1297;272.5;1;True;True
Node;AmplifyShaderEditor.SamplerNode;5;-856,220.5;Inherit;True;Property;_Texture;Texture;2;0;Create;True;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.IntNode;6;-790,88.5;Inherit;False;Property;_IsCorrect;_IsCorrect;3;0;Create;True;0;0;0;True;0;False;0;0;False;0;1;INT;0
Node;AmplifyShaderEditor.FunctionNode;9;-506,118.5;Inherit;False;SelectionShader;0;;7;1894054bc5ffc824890fd74252bf6f53;0;2;21;INT;0;False;22;FLOAT;0;False;2;FLOAT;15;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1,0;Half;False;True;-1;0;ASEMaterialInspector;0;0;Standard;ParallelepipedShader;False;False;False;False;False;True;True;True;True;True;True;True;False;False;True;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;9;21;6;0
WireConnection;9;22;5;4
WireConnection;0;0;9;0
WireConnection;0;2;9;0
WireConnection;0;9;9;15
ASEEND*/
//CHKSM=EBF920B848BB8689D721F4A18370D1E38F00CDB5