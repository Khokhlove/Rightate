// Compiled shader for Android

//////////////////////////////////////////////////////////////////////////
// 
// NOTE: This is *not* a valid shader file, the contents are provided just
// for information and for debugging purposes only.
// 
//////////////////////////////////////////////////////////////////////////
// Skipping shader variants that would not be included into build of current scene.

Shader "VR/SpatialMapping/Wireframe" {
Properties {
 _WireThickness ("Wire Thickness", Range(0.000000,800.000000)) = 100.000000
}
SubShader { 
 Tags { "RenderType"="Opaque" }
 Pass {
  Tags { "RenderType"="Opaque" }
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: <none>
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "gles3":
Constant Buffer "$Globals" (12 bytes) {
  Vector3 _WorldSpaceCameraPos at 0
}
Constant Buffer "$Globals" (32 bytes) {
  Vector4 unity_ObjectToWorld at 0
  Vector4 unity_MatrixVP at 16
}
Constant Buffer "$Globals" (4 bytes) {
  Float _WireThickness at 0
}

Shader Disassembly:
#ifdef VERTEX
#version 310 es

#define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
#if HLSLCC_ENABLE_UNIFORM_BUFFERS
#define UNITY_UNIFORM
#else
#define UNITY_UNIFORM uniform
#endif
#define UNITY_SUPPORTS_UNIFORM_LOCATION 1
#if UNITY_SUPPORTS_UNIFORM_LOCATION
#define UNITY_LOCATION(x) layout(location = x)
#define UNITY_BINDING(x) layout(binding = x, std140)
#else
#define UNITY_LOCATION(x)
#define UNITY_BINDING(x) layout(std140)
#endif
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
in highp vec4 in_POSITION0;
layout(location = 0) out highp vec4 vs_TEXCOORD1;
vec4 u_xlat0;
vec4 u_xlat1;
void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat1 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    vs_TEXCOORD1 = hlslcc_mtx4x4unity_ObjectToWorld[3] * in_POSITION0.wwww + u_xlat0;
    u_xlat0 = u_xlat1.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat1.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat1.zzzz + u_xlat0;
    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat1.wwww + u_xlat0;
    return;
}

#endif
#ifdef FRAGMENT
#version 310 es

precision highp float;
precision highp int;
#define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
#if HLSLCC_ENABLE_UNIFORM_BUFFERS
#define UNITY_UNIFORM
#else
#define UNITY_UNIFORM uniform
#endif
#define UNITY_SUPPORTS_UNIFORM_LOCATION 1
#if UNITY_SUPPORTS_UNIFORM_LOCATION
#define UNITY_LOCATION(x) layout(location = x)
#define UNITY_BINDING(x) layout(binding = x, std140)
#else
#define UNITY_LOCATION(x)
#define UNITY_BINDING(x) layout(std140)
#endif
vec4 ImmCB_0[11];
uniform 	vec3 _WorldSpaceCameraPos;
layout(location = 0) in highp vec4 gs_TEXCOORD0;
layout(location = 1) in highp vec4 gs_TEXCOORD1;
layout(location = 0) out mediump vec4 SV_Target0;
vec4 u_xlat0;
vec3 u_xlat1;
int u_xlati1;
bool u_xlatb2;
void main()
{
ImmCB_0[0] = vec4(1.0,1.0,1.0,1.0);
ImmCB_0[1] = vec4(1.0,0.0,0.0,1.0);
ImmCB_0[2] = vec4(0.0,1.0,0.0,1.0);
ImmCB_0[3] = vec4(0.0,0.0,1.0,1.0);
ImmCB_0[4] = vec4(1.0,1.0,0.0,1.0);
ImmCB_0[5] = vec4(0.0,1.0,1.0,1.0);
ImmCB_0[6] = vec4(1.0,0.0,1.0,1.0);
ImmCB_0[7] = vec4(0.5,0.0,0.0,1.0);
ImmCB_0[8] = vec4(0.0,0.5,0.5,1.0);
ImmCB_0[9] = vec4(1.0,0.649999976,0.0,1.0);
ImmCB_0[10] = vec4(1.0,1.0,1.0,1.0);
    u_xlat0.x = min(gs_TEXCOORD1.z, gs_TEXCOORD1.y);
    u_xlat0.x = min(u_xlat0.x, gs_TEXCOORD1.x);
    u_xlat0.x = u_xlat0.x * gs_TEXCOORD1.w;
    u_xlatb2 = 0.899999976<u_xlat0.x;
    if(u_xlatb2){
        SV_Target0 = vec4(0.0, 0.0, 0.0, 0.0);
        return;
    }
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * -2.0;
    u_xlat0.w = exp2(u_xlat0.x);
    u_xlat1.xyz = (-gs_TEXCOORD0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat1.x = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat1.x = floor(u_xlat1.x);
    u_xlat1.x = min(u_xlat1.x, 10.0);
    u_xlati1 = int(u_xlat1.x);
    u_xlat0.xyz = u_xlat0.www * ImmCB_0[u_xlati1].xyz;
    SV_Target0 = u_xlat0;
    return;
}

#endif
#ifdef GEOMETRY
#version 310 es
#ifdef GL_ARB_geometry_shader
#extension GL_ARB_geometry_shader : enable
#endif
#ifdef GL_OES_geometry_shader
#extension GL_OES_geometry_shader : enable
#endif
#ifdef GL_EXT_geometry_shader
#extension GL_EXT_geometry_shader : enable
#endif

#define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
#if HLSLCC_ENABLE_UNIFORM_BUFFERS
#define UNITY_UNIFORM
#else
#define UNITY_UNIFORM uniform
#endif
#define UNITY_SUPPORTS_UNIFORM_LOCATION 1
#if UNITY_SUPPORTS_UNIFORM_LOCATION
#define UNITY_LOCATION(x) layout(location = x)
#define UNITY_BINDING(x) layout(binding = x, std140)
#else
#define UNITY_LOCATION(x)
#define UNITY_BINDING(x) layout(std140)
#endif
uniform 	float _WireThickness;
layout(location = 0) in highp vec4 vs_TEXCOORD1 [3];
vec4 u_xlat0;
vec3 u_xlat1;
float u_xlat2;
vec2 u_xlat3;
float u_xlat4;
float u_xlat6;
layout(triangles) in;
layout(triangle_strip) out;
layout(location = 0) out highp vec4 gs_TEXCOORD0;
layout(location = 1) out highp vec4 gs_TEXCOORD1;
layout(max_vertices = 3) out;
void main()
{
    gl_Position = gl_in[0].gl_Position;
    gs_TEXCOORD0 = vs_TEXCOORD1[0];
    u_xlat0.xy = gl_in[1].gl_Position.xy / gl_in[1].gl_Position.ww;
    u_xlat0.zw = gl_in[2].gl_Position.xy / gl_in[2].gl_Position.ww;
    u_xlat1.xy = (-u_xlat0.xy) + u_xlat0.zw;
    u_xlat1.x = dot(u_xlat1.xy, u_xlat1.xy);
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat3.xy = gl_in[0].gl_Position.xy / gl_in[0].gl_Position.ww;
    u_xlat0 = u_xlat0 + (-u_xlat3.xyxy);
    u_xlat3.x = u_xlat0.x * u_xlat0.w;
    u_xlat3.x = u_xlat0.z * u_xlat0.y + (-u_xlat3.x);
    u_xlat4 = dot(u_xlat0.zw, u_xlat0.zw);
    u_xlat4 = sqrt(u_xlat4);
    u_xlat4 = abs(u_xlat3.x) / u_xlat4;
    u_xlat4 = u_xlat4 * gl_in[1].gl_Position.w;
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = sqrt(u_xlat0.x);
    u_xlat0.x = abs(u_xlat3.x) / u_xlat0.x;
    u_xlat2 = abs(u_xlat3.x) / u_xlat1.x;
    u_xlat2 = u_xlat2 * gl_in[0].gl_Position.w;
    u_xlat0.x = u_xlat0.x * gl_in[2].gl_Position.w;
    u_xlat6 = (-_WireThickness) + 800.0;
    u_xlat1.x = u_xlat6 * u_xlat2;
    u_xlat1.y = float(0.0);
    u_xlat1.z = float(0.0);
    gs_TEXCOORD1.xyz = u_xlat1.xyz;
    u_xlat2 = float(1.0) / gl_in[0].gl_Position.w;
    gs_TEXCOORD1.w = u_xlat2;
    EmitVertex();
    gl_Position = gl_in[1].gl_Position;
    gs_TEXCOORD0 = vs_TEXCOORD1[1];
    u_xlat1.y = u_xlat6 * u_xlat4;
    u_xlat0.z = u_xlat6 * u_xlat0.x;
    u_xlat1.x = float(0.0);
    u_xlat1.z = float(0.0);
    gs_TEXCOORD1.xyz = u_xlat1.xyz;
    u_xlat6 = float(1.0) / gl_in[1].gl_Position.w;
    gs_TEXCOORD1.w = u_xlat6;
    EmitVertex();
    gl_Position = gl_in[2].gl_Position;
    gs_TEXCOORD0 = vs_TEXCOORD1[2];
    u_xlat0.x = float(0.0);
    u_xlat0.y = float(0.0);
    gs_TEXCOORD1.xyz = u_xlat0.xyz;
    u_xlat0.x = float(1.0) / gl_in[2].gl_Position.w;
    gs_TEXCOORD1.w = u_xlat0.x;
    EmitVertex();
    return;
}

#endif


//////////////////////////////////////////////////////
Global Keywords: <none>
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "vulkan":
Uses vertex data channel "Vertex"

Constant Buffer "GGlobals4176688375" (4 bytes) on set: 1, binding: 2, used in: Geometry  {
  Float _WireThickness at 0
}
Constant Buffer "PGlobals4176688375" (12 bytes) on set: 1, binding: 0, used in: Fragment  {
  Vector3 _WorldSpaceCameraPos at 0
}
Constant Buffer "VGlobals4176688375" (128 bytes) on set: 1, binding: 1, used in: Vertex  {
  Matrix4x4 unity_MatrixVP at 64
  Matrix4x4 unity_ObjectToWorld at 0
}

Shader Disassembly:
Disassembly for Vertex:
// Module Version 10000
// Generated by (magic number): 80006
// Id's are bound by 103

                              Capability Shader
               1:             ExtInstImport  "GLSL.std.450"
                              MemoryModel Logical GLSL450
                              EntryPoint Vertex 4  "main" 11 50 81
                              Name 50  "vs_TEXCOORD1"
                              Decorate 11 Location 0
                              Decorate 16 ArrayStride 16
                              Decorate 17 ArrayStride 16
                              MemberDecorate 18 0 Offset 0
                              MemberDecorate 18 1 Offset 64
                              Decorate 18 Block
                              Decorate 20 DescriptorSet 1
                              Decorate 20 Binding 1
                              Decorate 50(vs_TEXCOORD1) Location 0
                              MemberDecorate 79 0 BuiltIn Position
                              MemberDecorate 79 1 BuiltIn PointSize
                              MemberDecorate 79 2 BuiltIn ClipDistance
                              Decorate 79 Block
               2:             TypeVoid
               3:             TypeFunction 2
               6:             TypeFloat 32
               7:             TypeVector 6(float) 4
               8:             TypePointer Private 7(fvec4)
               9:      8(ptr) Variable Private
              10:             TypePointer Input 7(fvec4)
              11:     10(ptr) Variable Input
              14:             TypeInt 32 0
              15:     14(int) Constant 4
              16:             TypeArray 7(fvec4) 15
              17:             TypeArray 7(fvec4) 15
              18:             TypeStruct 16 17
              19:             TypePointer Uniform 18(struct)
              20:     19(ptr) Variable Uniform
              21:             TypeInt 32 1
              22:     21(int) Constant 0
              23:     21(int) Constant 1
              24:             TypePointer Uniform 7(fvec4)
              35:     21(int) Constant 2
              43:      8(ptr) Variable Private
              45:     21(int) Constant 3
              49:             TypePointer Output 7(fvec4)
50(vs_TEXCOORD1):     49(ptr) Variable Output
              77:     14(int) Constant 1
              78:             TypeArray 6(float) 77
              79:             TypeStruct 7(fvec4) 6(float) 78
              80:             TypePointer Output 79(struct)
              81:     80(ptr) Variable Output
              91:             TypePointer Function 7(fvec4)
              93:             TypeVector 21(int) 4
              94:             TypePointer Function 93(ivec4)
              96:             TypeBool
              97:             TypeVector 96(bool) 4
              98:             TypePointer Function 97(bvec4)
             100:             TypeVector 14(int) 4
             101:             TypePointer Function 100(ivec4)
               4:           2 Function None 3
               5:             Label
              92:     91(ptr) Variable Function
              95:     94(ptr) Variable Function
              99:     98(ptr) Variable Function
             102:    101(ptr) Variable Function
              12:    7(fvec4) Load 11
              13:    7(fvec4) VectorShuffle 12 12 1 1 1 1
              25:     24(ptr) AccessChain 20 22 23
              26:    7(fvec4) Load 25
              27:    7(fvec4) FMul 13 26
                              Store 9 27
              28:     24(ptr) AccessChain 20 22 22
              29:    7(fvec4) Load 28
              30:    7(fvec4) Load 11
              31:    7(fvec4) VectorShuffle 30 30 0 0 0 0
              32:    7(fvec4) FMul 29 31
              33:    7(fvec4) Load 9
              34:    7(fvec4) FAdd 32 33
                              Store 9 34
              36:     24(ptr) AccessChain 20 22 35
              37:    7(fvec4) Load 36
              38:    7(fvec4) Load 11
              39:    7(fvec4) VectorShuffle 38 38 2 2 2 2
              40:    7(fvec4) FMul 37 39
              41:    7(fvec4) Load 9
              42:    7(fvec4) FAdd 40 41
                              Store 9 42
              44:    7(fvec4) Load 9
              46:     24(ptr) AccessChain 20 22 45
              47:    7(fvec4) Load 46
              48:    7(fvec4) FAdd 44 47
                              Store 43 48
              51:     24(ptr) AccessChain 20 22 45
              52:    7(fvec4) Load 51
              53:    7(fvec4) Load 11
              54:    7(fvec4) VectorShuffle 53 53 3 3 3 3
              55:    7(fvec4) FMul 52 54
              56:    7(fvec4) Load 9
              57:    7(fvec4) FAdd 55 56
                              Store 50(vs_TEXCOORD1) 57
              58:    7(fvec4) Load 43
              59:    7(fvec4) VectorShuffle 58 58 1 1 1 1
              60:     24(ptr) AccessChain 20 23 23
              61:    7(fvec4) Load 60
              62:    7(fvec4) FMul 59 61
                              Store 9 62
              63:     24(ptr) AccessChain 20 23 22
              64:    7(fvec4) Load 63
              65:    7(fvec4) Load 43
              66:    7(fvec4) VectorShuffle 65 65 0 0 0 0
              67:    7(fvec4) FMul 64 66
              68:    7(fvec4) Load 9
              69:    7(fvec4) FAdd 67 68
                              Store 9 69
              70:     24(ptr) AccessChain 20 23 35
              71:    7(fvec4) Load 70
              72:    7(fvec4) Load 43
              73:    7(fvec4) VectorShuffle 72 72 2 2 2 2
              74:    7(fvec4) FMul 71 73
              75:    7(fvec4) Load 9
              76:    7(fvec4) FAdd 74 75
                              Store 9 76
              82:     24(ptr) AccessChain 20 23 45
              83:    7(fvec4) Load 82
              84:    7(fvec4) Load 43
              85:    7(fvec4) VectorShuffle 84 84 3 3 3 3
              86:    7(fvec4) FMul 83 85
              87:    7(fvec4) Load 9
              88:    7(fvec4) FAdd 86 87
              89:     49(ptr) AccessChain 81 22
                              Store 89 88
                              Return
                              FunctionEnd

Disassembly for Fragment:
// Module Version 10000
// Generated by (magic number): 80006
// Id's are bound by 147

                              Capability Shader
               1:             ExtInstImport  "GLSL.std.450"
                              MemoryModel Logical GLSL450
                              EntryPoint Fragment 4  "main" 11 48 70
                              ExecutionMode 4 OriginUpperLeft
                              Decorate 11 Location 1
                              Decorate 48 RelaxedPrecision
                              Decorate 48 Location 0
                              Decorate 70 Location 0
                              MemberDecorate 74 0 Offset 0
                              Decorate 74 Block
                              Decorate 76 DescriptorSet 1
                              Decorate 76 Binding 0
               2:             TypeVoid
               3:             TypeFunction 2
               6:             TypeFloat 32
               7:             TypeVector 6(float) 4
               8:             TypePointer Private 7(fvec4)
               9:      8(ptr) Variable Private
              10:             TypePointer Input 7(fvec4)
              11:     10(ptr) Variable Input
              12:             TypeInt 32 0
              13:     12(int) Constant 2
              14:             TypePointer Input 6(float)
              17:     12(int) Constant 1
              21:     12(int) Constant 0
              22:             TypePointer Private 6(float)
              32:     12(int) Constant 3
              37:             TypeBool
              38:             TypePointer Private 37(bool)
              39:     38(ptr) Variable Private
              40:    6(float) Constant 1063675494
              47:             TypePointer Output 7(fvec4)
              48:     47(ptr) Variable Output
              49:    6(float) Constant 0
              50:    7(fvec4) ConstantComposite 49 49 49 49
              60:    6(float) Constant 3221225472
              67:             TypeVector 6(float) 3
              68:             TypePointer Private 67(fvec3)
              69:     68(ptr) Variable Private
              70:     10(ptr) Variable Input
              74:             TypeStruct 67(fvec3)
              75:             TypePointer Uniform 74(struct)
              76:     75(ptr) Variable Uniform
              77:             TypeInt 32 1
              78:     77(int) Constant 0
              79:             TypePointer Uniform 67(fvec3)
              97:    6(float) Constant 1092616192
             100:             TypePointer Private 77(int)
             101:    100(ptr) Variable Private
             107:             TypeVector 12(int) 4
             108:     12(int) Constant 11
             109:             TypeArray 107(ivec4) 108
             110:     12(int) Constant 1065353216
             111:  107(ivec4) ConstantComposite 110 110 110 110
             112:  107(ivec4) ConstantComposite 110 21 21 110
             113:  107(ivec4) ConstantComposite 21 110 21 110
             114:  107(ivec4) ConstantComposite 21 21 110 110
             115:  107(ivec4) ConstantComposite 110 110 21 110
             116:  107(ivec4) ConstantComposite 21 110 110 110
             117:  107(ivec4) ConstantComposite 110 21 110 110
             118:     12(int) Constant 1056964608
             119:  107(ivec4) ConstantComposite 118 21 21 110
             120:  107(ivec4) ConstantComposite 21 118 118 110
             121:     12(int) Constant 1059481190
             122:  107(ivec4) ConstantComposite 110 121 21 110
             123:         109 ConstantComposite 111 112 113 114 115 116 117 119 120 122 111
             125:             TypeVector 12(int) 3
             126:             TypePointer Function 109
             128:             TypePointer Function 107(ivec4)
             138:             TypePointer Function 7(fvec4)
             140:             TypeVector 77(int) 4
             141:             TypePointer Function 140(ivec4)
             143:             TypeVector 37(bool) 4
             144:             TypePointer Function 143(bvec4)
               4:           2 Function None 3
               5:             Label
             127:    126(ptr) Variable Function
             139:    138(ptr) Variable Function
             142:    141(ptr) Variable Function
             145:    144(ptr) Variable Function
             146:    128(ptr) Variable Function
              15:     14(ptr) AccessChain 11 13
              16:    6(float) Load 15
              18:     14(ptr) AccessChain 11 17
              19:    6(float) Load 18
              20:    6(float) ExtInst 1(GLSL.std.450) 37(FMin) 16 19
              23:     22(ptr) AccessChain 9 21
                              Store 23 20
              24:     22(ptr) AccessChain 9 21
              25:    6(float) Load 24
              26:     14(ptr) AccessChain 11 21
              27:    6(float) Load 26
              28:    6(float) ExtInst 1(GLSL.std.450) 37(FMin) 25 27
              29:     22(ptr) AccessChain 9 21
                              Store 29 28
              30:     22(ptr) AccessChain 9 21
              31:    6(float) Load 30
              33:     14(ptr) AccessChain 11 32
              34:    6(float) Load 33
              35:    6(float) FMul 31 34
              36:     22(ptr) AccessChain 9 21
                              Store 36 35
              41:     22(ptr) AccessChain 9 21
              42:    6(float) Load 41
              43:    37(bool) FOrdLessThan 40 42
                              Store 39 43
              44:    37(bool) Load 39
                              SelectionMerge 46 None
                              BranchConditional 44 45 46
              45:               Label
                                Store 48 50
                                Return
              46:             Label
              52:     22(ptr) AccessChain 9 21
              53:    6(float) Load 52
              54:     22(ptr) AccessChain 9 21
              55:    6(float) Load 54
              56:    6(float) FMul 53 55
              57:     22(ptr) AccessChain 9 21
                              Store 57 56
              58:     22(ptr) AccessChain 9 21
              59:    6(float) Load 58
              61:    6(float) FMul 59 60
              62:     22(ptr) AccessChain 9 21
                              Store 62 61
              63:     22(ptr) AccessChain 9 21
              64:    6(float) Load 63
              65:    6(float) ExtInst 1(GLSL.std.450) 29(Exp2) 64
              66:     22(ptr) AccessChain 9 32
                              Store 66 65
              71:    7(fvec4) Load 70
              72:   67(fvec3) VectorShuffle 71 71 0 1 2
              73:   67(fvec3) FNegate 72
              80:     79(ptr) AccessChain 76 78
              81:   67(fvec3) Load 80
              82:   67(fvec3) FAdd 73 81
                              Store 69 82
              83:   67(fvec3) Load 69
              84:   67(fvec3) Load 69
              85:    6(float) Dot 83 84
              86:     22(ptr) AccessChain 69 21
                              Store 86 85
              87:     22(ptr) AccessChain 69 21
              88:    6(float) Load 87
              89:    6(float) ExtInst 1(GLSL.std.450) 31(Sqrt) 88
              90:     22(ptr) AccessChain 69 21
                              Store 90 89
              91:     22(ptr) AccessChain 69 21
              92:    6(float) Load 91
              93:    6(float) ExtInst 1(GLSL.std.450) 8(Floor) 92
              94:     22(ptr) AccessChain 69 21
                              Store 94 93
              95:     22(ptr) AccessChain 69 21
              96:    6(float) Load 95
              98:    6(float) ExtInst 1(GLSL.std.450) 37(FMin) 96 97
              99:     22(ptr) AccessChain 69 21
                              Store 99 98
             102:     22(ptr) AccessChain 69 21
             103:    6(float) Load 102
             104:     77(int) ConvertFToS 103
                              Store 101 104
             105:    7(fvec4) Load 9
             106:   67(fvec3) VectorShuffle 105 105 3 3 3
             124:     77(int) Load 101
                              Store 127 123
             129:    128(ptr) AccessChain 127 124
             130:  107(ivec4) Load 129
             131:  125(ivec3) VectorShuffle 130 130 0 1 2
             132:   67(fvec3) Bitcast 131
             133:   67(fvec3) FMul 106 132
             134:    7(fvec4) Load 9
             135:    7(fvec4) VectorShuffle 134 133 4 5 6 3
                              Store 9 135
             136:    7(fvec4) Load 9
                              Store 48 136
                              Return
                              FunctionEnd

Disassembly for Hull:
Not present.



 }
}
}