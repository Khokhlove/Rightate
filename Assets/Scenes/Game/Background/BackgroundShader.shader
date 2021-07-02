// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BackgroundShader"
{
	Properties
	{
		_GridSize("GridSize", Vector) = (0.9,0.9,0,0)
		_GridTiling("GridTiling", Vector) = (10,10,0,0)
		_GridOffset("GridOffset", Vector) = (0,0,0,0)
		[HDR]_GridColor("GridColor", Color) = (8,8,8,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "ForceNoShadowCasting" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 2.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform half4 _GridColor;
		uniform half2 _GridTiling;
		uniform half2 _GridOffset;
		uniform half2 _GridSize;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			half4 temp_output_30_0 = _GridColor;
			o.Emission = temp_output_30_0.rgb;
			float2 uv_TexCoord6 = i.uv_texcoord * _GridTiling + _GridOffset;
			half2 appendResult10_g1 = (half2(_GridSize.x , _GridSize.y));
			half2 temp_output_11_0_g1 = ( abs( (frac( uv_TexCoord6 )*2.0 + -1.0) ) - appendResult10_g1 );
			half2 break16_g1 = ( 1.0 - ( temp_output_11_0_g1 / fwidth( temp_output_11_0_g1 ) ) );
			o.Alpha = ( ( 1.0 - saturate( min( break16_g1.x , break16_g1.y ) ) ) * _GridColor ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
209;151;1920;946;687.5465;54.13171;1;True;True
Node;AmplifyShaderEditor.Vector2Node;11;-1499.947,-69.48254;Inherit;False;Property;_GridOffset;GridOffset;2;0;Create;True;0;0;0;True;0;False;0,0;0.5,0.75;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;10;-1482.947,-234.4825;Inherit;False;Property;_GridTiling;GridTiling;1;0;Create;True;0;0;0;True;0;False;10,10;22,22;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;6;-1191.947,-125.4825;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FractNode;8;-868.9466,-98.48253;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;7;-1056.947,85.51747;Inherit;False;Property;_GridSize;GridSize;0;0;Create;True;0;0;0;True;0;False;0.9,0.9;0.95,0.95;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;4;-702.5422,-36.72366;Inherit;True;Rectangle;-1;;1;6b23e0c975270fb4084c354b2c83366a;0;3;1;FLOAT2;0,0;False;2;FLOAT;0.5;False;3;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;30;-236.2007,291.7473;Inherit;False;Property;_GridColor;GridColor;3;1;[HDR];Create;True;0;0;0;True;0;False;8,8,8,0;0.5823233,0.03882155,1.059274,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;9;-363.9465,-4.482536;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;306.5168,352.7624;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;582.7871,90.07601;Half;False;True;-1;0;ASEMaterialInspector;0;0;Unlit;BackgroundShader;False;False;False;False;False;True;True;True;True;True;True;True;False;False;True;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;6;0;10;0
WireConnection;6;1;11;0
WireConnection;8;0;6;0
WireConnection;4;1;8;0
WireConnection;4;2;7;1
WireConnection;4;3;7;2
WireConnection;9;0;4;0
WireConnection;31;0;9;0
WireConnection;31;1;30;0
WireConnection;0;2;30;0
WireConnection;0;9;31;0
ASEEND*/
//CHKSM=020F5F9AE9B8CC2A0B82393E040FFF66998AA017