// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BackgroundShader"
{
	Properties
	{
		_GridSize("GridSize", Vector) = (0.9,0.9,0,0)
		_GridTiling("GridTiling", Vector) = (10,10,0,0)
		_GridOffset("GridOffset", Vector) = (0,0,0,0)
		_NoiseTiling("NoiseTiling", Vector) = (1,1,0,0)
		[HDR]_GridColor("GridColor", Color) = (8,8,8,0)
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

		uniform half4 _GridColor;
		uniform half2 _GridTiling;
		uniform half2 _GridOffset;
		uniform half2 _GridSize;
		uniform half2 _NoiseTiling;


		float2 voronoihash20( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi20( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash20( n + g );
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
			half4 color32 = IsGammaSpace() ? half4(1,1,1,0) : half4(1,1,1,0);
			o.Albedo = color32.rgb;
			half4 temp_output_30_0 = _GridColor;
			o.Emission = temp_output_30_0.rgb;
			float2 uv_TexCoord6 = i.uv_texcoord * _GridTiling + _GridOffset;
			half2 appendResult10_g1 = (half2(_GridSize.x , _GridSize.y));
			half2 temp_output_11_0_g1 = ( abs( (frac( uv_TexCoord6 )*2.0 + -1.0) ) - appendResult10_g1 );
			half2 break16_g1 = ( 1.0 - ( temp_output_11_0_g1 / fwidth( temp_output_11_0_g1 ) ) );
			half time20 = ( _Time.y * 3.0 );
			half4 appendResult15 = (half4(( _Time.y / 5.0 ) , 0.0 , 0.0 , 0.0));
			float2 uv_TexCoord18 = i.uv_texcoord * _NoiseTiling + ( 1.0 - appendResult15 ).xy;
			float2 coords20 = uv_TexCoord18 * 5.0;
			float2 id20 = 0;
			float2 uv20 = 0;
			float voroi20 = voronoi20( coords20, time20, id20, uv20, 0 );
			o.Alpha = ( ( 1.0 - saturate( min( break16_g1.x , break16_g1.y ) ) ) * ( _GridColor * voroi20 ) ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
1942;36;1920;985;2065.829;372.9955;1;True;True
Node;AmplifyShaderEditor.SimpleTimeNode;1;-1729,553.5;Inherit;True;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;24;-1547.117,802.2776;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-1541,670.5;Inherit;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;0;False;0;False;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;25;-968.496,810.629;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;22;-928.6357,851.6829;Inherit;False;Constant;_Float2;Float 2;4;0;Create;True;0;0;0;False;0;False;3;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;2;-1396,554.5;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;16;-1175.595,663.1835;Inherit;False;Constant;_Float1;Float 1;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-644.6938,783.6803;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;11;-1499.947,-69.48254;Inherit;False;Property;_GridOffset;GridOffset;2;0;Create;True;0;0;0;True;0;False;0,0;10,10;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;10;-1482.947,-234.4825;Inherit;False;Property;_GridTiling;GridTiling;1;0;Create;True;0;0;0;True;0;False;10,10;10,10;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.WireNode;27;-448.3347,801.0849;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;15;-1000.219,590.4086;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.WireNode;28;-419.7019,719.9589;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;17;-799.7889,633.3579;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;6;-1191.947,-125.4825;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;19;-781.8927,485.4219;Inherit;False;Property;_NoiseTiling;NoiseTiling;3;0;Create;True;0;0;0;True;0;False;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;23;-360.7525,739.5379;Inherit;False;Constant;_Float3;Float 3;4;0;Create;True;0;0;0;False;0;False;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;18;-536.1287,560.5832;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;26;-302.7848,692.5195;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FractNode;8;-868.9466,-98.48253;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;7;-1056.947,85.51747;Inherit;False;Property;_GridSize;GridSize;0;0;Create;True;0;0;0;True;0;False;0.9,0.9;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;4;-702.5422,-36.72366;Inherit;True;Rectangle;-1;;1;6b23e0c975270fb4084c354b2c83366a;0;3;1;FLOAT2;0,0;False;2;FLOAT;0.5;False;3;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;20;-223.5537,497.3524;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.ColorNode;30;-236.2007,291.7473;Inherit;False;Property;_GridColor;GridColor;4;1;[HDR];Create;True;0;0;0;True;0;False;8,8,8,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;122.1269,466.4319;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;9;-363.9465,-4.482536;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;306.5168,352.7624;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;32;243.3729,-18.6077;Inherit;False;Constant;_Color0;Color 0;5;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;592.7871,85.07601;Half;False;True;-1;0;ASEMaterialInspector;0;0;Standard;BackgroundShader;False;False;False;False;False;True;True;True;True;True;True;True;False;False;True;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;24;0;1;0
WireConnection;25;0;24;0
WireConnection;2;0;1;0
WireConnection;2;1;3;0
WireConnection;21;0;25;0
WireConnection;21;1;22;0
WireConnection;27;0;21;0
WireConnection;15;0;2;0
WireConnection;15;1;16;0
WireConnection;28;0;27;0
WireConnection;17;0;15;0
WireConnection;6;0;10;0
WireConnection;6;1;11;0
WireConnection;18;0;19;0
WireConnection;18;1;17;0
WireConnection;26;0;28;0
WireConnection;8;0;6;0
WireConnection;4;1;8;0
WireConnection;4;2;7;1
WireConnection;4;3;7;2
WireConnection;20;0;18;0
WireConnection;20;1;26;0
WireConnection;20;2;23;0
WireConnection;29;0;30;0
WireConnection;29;1;20;0
WireConnection;9;0;4;0
WireConnection;31;0;9;0
WireConnection;31;1;29;0
WireConnection;0;0;32;0
WireConnection;0;2;30;0
WireConnection;0;9;31;0
ASEEND*/
//CHKSM=C5633CD6C528875C3631CC858F740194565DEE2C