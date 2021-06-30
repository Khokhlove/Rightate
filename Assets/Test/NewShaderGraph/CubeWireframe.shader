// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CubeWireframe"
{
	Properties
	{
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "ForceNoShadowCasting" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 2.0
		#pragma surface surf Standard keepalpha noshadow novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			half2 _Vector0 = half2(0.95,0.95);
			half2 appendResult10_g1 = (half2(_Vector0.x , _Vector0.y));
			half2 temp_output_11_0_g1 = ( abs( (i.uv_texcoord*2.0 + -1.0) ) - appendResult10_g1 );
			half2 break16_g1 = ( 1.0 - ( temp_output_11_0_g1 / fwidth( temp_output_11_0_g1 ) ) );
			half temp_output_5_0 = ( 1.0 - saturate( min( break16_g1.x , break16_g1.y ) ) );
			half3 temp_cast_0 = (temp_output_5_0).xxx;
			o.Albedo = temp_cast_0;
			half4 color7 = IsGammaSpace() ? half4(0.8784314,0.3764706,23.96863,1) : half4(0.7454044,0.1169707,1084.464,1);
			o.Emission = ( temp_output_5_0 * color7 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
1923;78;1920;991;1091.382;366.192;1.316315;True;False
Node;AmplifyShaderEditor.Vector2Node;4;-758,108;Inherit;False;Constant;_Vector0;Vector 0;0;0;Create;True;0;0;0;False;1;;False;0.95,0.95;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;3;-538,41;Inherit;True;Rectangle;-1;;1;6b23e0c975270fb4084c354b2c83366a;0;3;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;5;-292,61;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;7;-534,303;Inherit;False;Constant;_Color0;Color 0;0;1;[HDR];Create;True;0;0;0;False;0;False;0.8784314,0.3764706,23.96863,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-30.97153,228.2463;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;19;238.4,120.4;Half;False;True;-1;0;ASEMaterialInspector;0;0;Standard;CubeWireframe;False;False;False;False;False;True;True;True;True;True;True;True;False;False;False;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;2;4;1
WireConnection;3;3;4;2
WireConnection;5;0;3;0
WireConnection;6;0;5;0
WireConnection;6;1;7;0
WireConnection;19;0;5;0
WireConnection;19;2;6;0
ASEEND*/
//CHKSM=3579529AF3591B57A823CEFACDE163127741008B