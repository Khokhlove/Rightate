// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "PuaseButton"
{
	Properties
	{
		_Roundradius("Round radius", Range( 0 , 1)) = 0.2
		_RectSize("Rect Size", Vector) = (0.95,0.95,0,0)
		_Float7("Float 7", Range( 0 , 1)) = 0.17
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGPROGRAM
		#pragma target 4.6
		#pragma surface surf Standard alpha:fade keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			half filler;
		};

		uniform half2 _RectSize;
		uniform half _Roundradius;
		uniform half _Float7;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
130;115;1529;797;1522.761;-1857.814;1.3;True;True
Node;AmplifyShaderEditor.ColorNode;13;-999.5764,90.20027;Inherit;False;Constant;_Color1;Color 1;3;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;16;-569.3596,235.0472;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.Vector2Node;2;-1616.763,410.4018;Half;False;Property;_RectSize;Rect Size;6;0;Create;True;0;0;0;True;0;False;0.95,0.95;0.95,0.95;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;3;-1690.863,584.6017;Half;False;Property;_Roundradius;Round radius;5;0;Create;True;0;0;0;True;0;False;0.2;0.2;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;7;-1653.162,814.7014;Inherit;False;Constant;_Vector0;Vector 0;4;0;Create;True;0;0;0;False;0;False;0.05,0.05;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleSubtractOpNode;8;-1437.363,701.6014;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BreakToComponentsNode;9;-1286.562,715.9014;Inherit;False;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.FunctionNode;4;-1150.886,689.2799;Inherit;True;Rounded Rectangle;-1;;2;8679f72f5be758f47babb3ba1d5f51d3;0;4;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;18;-398.8498,936.0694;Inherit;False;Constant;_Color2;Color 0;3;0;Create;True;0;0;0;False;0;False;1,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;1;-1382.259,446.3775;Inherit;True;Rounded Rectangle;-1;;1;8679f72f5be758f47babb3ba1d5f51d3;0;4;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-763.2094,232.8855;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;10;-839.5086,663.2401;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-602.0696,707.8861;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;11;-843.6462,929.1796;Inherit;False;Constant;_Color0;Color 0;3;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;17;-397.9651,701.9359;Inherit;True;FLOAT;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleAddOpNode;33;-153.9852,2178.566;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-1437.531,833.8627;Half;False;Property;_Float7;Float 7;7;0;Create;True;0;0;0;True;0;False;0.17;0.2;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-106.0822,664.4462;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-929.6437,1777.734;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;15;108.1208,440.8528;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;20;-644.4498,476.5869;Inherit;False;Constant;_Color3;Color 0;3;0;Create;True;0;0;0;False;0;False;0.764151,0.1838288,0.1838288,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;25;-1231.611,1171.91;Inherit;False;Constant;_Color4;Color 4;4;0;Create;True;0;0;0;False;0;False;0.44805,0,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;22;-1317.815,1401.245;Inherit;True;Property;_TextureSample0;Texture Sample 0;8;0;Create;True;0;0;0;False;0;False;-1;77ecd58d148326e42818d6731ec1b9d2;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;26;-1240.116,1634.37;Inherit;False;Constant;_Color5;Color 4;4;0;Create;True;0;0;0;False;0;False;0.6320754,0,0.1855412,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;27;-1326.32,1863.705;Inherit;True;Property;_TextureSample1;Texture Sample 0;9;0;Create;True;0;0;0;False;0;False;-1;236c6823ff8e22543aa9bb5a1a896fcc;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;39;-761.2507,2516.617;Inherit;False;Constant;_Float8;Float 8;7;0;Create;True;0;0;0;False;0;False;0.52;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-416.7415,257.0112;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;30;-375.9743,1542.977;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;31;-1367.085,2149.167;Inherit;True;Property;_Texture0;Texture 0;10;0;Create;True;0;0;0;False;0;False;138247d773d49e54094cc25729a52d53;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode;32;-1361.585,2388.367;Inherit;True;Property;_Texture1;Texture 0;11;0;Create;True;0;0;0;False;0;False;f81094832d834c64d93b198cb16b6a3e;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;34;-1023.585,2134.867;Inherit;True;Property;_TextureSample2;Texture Sample 2;7;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;35;-1054.176,2370.711;Inherit;True;Property;_TextureSample3;Texture Sample 2;7;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-601.2507,2372.617;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-922.4384,1315.274;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;369.2124,47.1681;Half;False;True;-1;6;ASEMaterialInspector;0;0;Standard;PuaseButton;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;True;0.57;True;2;5;False;-1;10;False;-1;1;1;False;-1;4;False;-1;5;False;-1;1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;16;0;14;0
WireConnection;8;0;2;0
WireConnection;8;1;7;0
WireConnection;9;0;8;0
WireConnection;4;2;9;0
WireConnection;4;3;9;1
WireConnection;4;4;6;0
WireConnection;1;2;2;1
WireConnection;1;3;2;2
WireConnection;1;4;3;0
WireConnection;14;0;13;0
WireConnection;14;1;1;0
WireConnection;10;0;1;0
WireConnection;10;1;4;0
WireConnection;12;0;10;0
WireConnection;12;1;11;0
WireConnection;17;0;12;0
WireConnection;33;0;34;0
WireConnection;33;1;36;0
WireConnection;19;0;17;3
WireConnection;19;1;18;0
WireConnection;28;0;26;0
WireConnection;28;1;27;4
WireConnection;15;0;21;0
WireConnection;15;1;19;0
WireConnection;21;0;16;3
WireConnection;21;1;20;0
WireConnection;30;0;23;0
WireConnection;30;1;28;0
WireConnection;34;0;31;0
WireConnection;35;0;32;0
WireConnection;36;0;35;0
WireConnection;36;1;39;0
WireConnection;23;0;25;0
WireConnection;23;1;22;4
ASEEND*/
//CHKSM=0B2945E8BFA773485DD3ADF48F5491C874EC8AC6