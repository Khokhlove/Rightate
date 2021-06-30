// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SelectionShader"
{
	Properties
	{
		[HDR]_BorderColor("BorderColor", Color) = (1,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "ForceNoShadowCasting" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 2.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform half4 _BorderColor;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TexCoord9 = i.uv_texcoord * half2( 1,1 ) + half2( -0.25,0.25 );
			half2 _Vector0 = half2(0.45,0.45);
			half temp_output_2_0_g1 = (float)3;
			half cosSides12_g1 = cos( ( UNITY_PI / temp_output_2_0_g1 ) );
			half2 appendResult18_g1 = (half2(( _Vector0.x * cosSides12_g1 ) , ( _Vector0.y * cosSides12_g1 )));
			half2 break23_g1 = ( (uv_TexCoord9*2.0 + -1.0) / appendResult18_g1 );
			half polarCoords30_g1 = atan2( break23_g1.x , -break23_g1.y );
			half temp_output_52_0_g1 = ( 6.28318548202515 / temp_output_2_0_g1 );
			half2 appendResult25_g1 = (half2(break23_g1.x , -break23_g1.y));
			half2 finalUVs29_g1 = appendResult25_g1;
			half temp_output_44_0_g1 = ( cos( ( ( floor( ( 0.5 + ( polarCoords30_g1 / temp_output_52_0_g1 ) ) ) * temp_output_52_0_g1 ) - polarCoords30_g1 ) ) * length( finalUVs29_g1 ) );
			half4 temp_output_1_0 = ( _BorderColor * ( 1.0 - saturate( ( ( 1.0 - temp_output_44_0_g1 ) / fwidth( temp_output_44_0_g1 ) ) ) ) );
			o.Emission = temp_output_1_0.rgb;
			o.Alpha = temp_output_1_0.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
1913;41;1920;973;1888;206.5;1;True;True
Node;AmplifyShaderEditor.Vector2Node;10;-1536,22.5;Inherit;False;Constant;_Vector1;Vector 1;1;0;Create;True;0;0;0;False;0;False;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;11;-1548,205.5;Inherit;False;Constant;_Vector2;Vector 2;1;0;Create;True;0;0;0;False;0;False;-0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.IntNode;5;-1017,211.5;Inherit;False;Constant;_Int0;Int 0;1;0;Create;True;0;0;0;False;0;False;3;0;False;0;1;INT;0
Node;AmplifyShaderEditor.Vector2Node;6;-1026,299.5;Inherit;False;Constant;_Vector0;Vector 0;1;0;Create;True;0;0;0;False;0;False;0.45,0.45;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;9;-1269,70.5;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;4;-797,200.5;Inherit;False;Polygon;-1;;1;6906ef7087298c94c853d6753e182169;0;4;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;3;-472,25.5;Inherit;False;Property;_BorderColor;BorderColor;0;1;[HDR];Create;True;0;0;0;True;0;False;1,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;2;-448,247.5;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1;-227,224.5;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Half;False;True;-1;0;ASEMaterialInspector;0;0;Standard;SelectionShader;False;False;False;False;False;True;True;True;True;True;True;True;False;False;True;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;9;0;10;0
WireConnection;9;1;11;0
WireConnection;4;1;9;0
WireConnection;4;2;5;0
WireConnection;4;3;6;1
WireConnection;4;4;6;2
WireConnection;2;0;4;0
WireConnection;1;0;3;0
WireConnection;1;1;2;0
WireConnection;0;2;1;0
WireConnection;0;9;1;0
ASEEND*/
//CHKSM=10068D90679F39200452255590393944F08A1225