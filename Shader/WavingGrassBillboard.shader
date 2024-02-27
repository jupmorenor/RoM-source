//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/TerrainEngine/Details/BillboardWavingDoublePass" {
Properties {
 _WavingTint ("Fade Color", Color) = (0.7,0.6,0.5,0)
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _WaveAndDistance ("Wave and distance", Vector) = (12,3.6,1,1)
 _Cutoff ("Cutoff", Float) = 0.5
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  Cull Off
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _WorldSpaceLightPos0;
uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp vec4 c_4;
  c_4.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz)
  ) * 2.0));
  c_4.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_4.w;
  c_1.xyz = (c_4.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _WorldSpaceLightPos0;
uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp vec4 c_4;
  c_4.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz)
  ) * 2.0));
  c_4.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_4.w;
  c_1.xyz = (c_4.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  c_1.xyz = (tmpvar_2.xyz * (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz));
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  c_1.xyz = (tmpvar_2.xyz * (2.0 * texture (unity_Lightmap, xlv_TEXCOORD1).xyz));
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  mediump vec3 lm_4;
  lowp vec3 tmpvar_5;
  tmpvar_5 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz);
  lm_4 = tmpvar_5;
  mediump vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_2.xyz * lm_4);
  c_1.xyz = tmpvar_6;
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  mediump vec3 lm_4;
  lowp vec3 tmpvar_5;
  tmpvar_5 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD1).xyz);
  lm_4 = tmpvar_5;
  mediump vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_2.xyz * lm_4);
  c_1.xyz = tmpvar_6;
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float tmpvar_4;
  mediump float lightShadowDataX_5;
  highp float dist_6;
  lowp float tmpvar_7;
  tmpvar_7 = texture2DProj (_ShadowMapTexture, xlv_TEXCOORD3).x;
  dist_6 = tmpvar_7;
  highp float tmpvar_8;
  tmpvar_8 = _LightShadowData.x;
  lightShadowDataX_5 = tmpvar_8;
  highp float tmpvar_9;
  tmpvar_9 = max (float((dist_6 > 
    (xlv_TEXCOORD3.z / xlv_TEXCOORD3.w)
  )), lightShadowDataX_5);
  tmpvar_4 = tmpvar_9;
  lowp vec4 c_10;
  c_10.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * tmpvar_4) * 2.0));
  c_10.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_10.w;
  c_1.xyz = (c_10.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT

uniform highp vec4 _LightShadowData;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float tmpvar_4;
  mediump float lightShadowDataX_5;
  highp float dist_6;
  lowp float tmpvar_7;
  tmpvar_7 = texture2DProj (_ShadowMapTexture, xlv_TEXCOORD2).x;
  dist_6 = tmpvar_7;
  highp float tmpvar_8;
  tmpvar_8 = _LightShadowData.x;
  lightShadowDataX_5 = tmpvar_8;
  highp float tmpvar_9;
  tmpvar_9 = max (float((dist_6 > 
    (xlv_TEXCOORD2.z / xlv_TEXCOORD2.w)
  )), lightShadowDataX_5);
  tmpvar_4 = tmpvar_9;
  c_1.xyz = (tmpvar_2.xyz * min ((2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz), vec3((tmpvar_4 * 2.0))));
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT

uniform highp vec4 _LightShadowData;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float tmpvar_4;
  mediump float lightShadowDataX_5;
  highp float dist_6;
  lowp float tmpvar_7;
  tmpvar_7 = texture2DProj (_ShadowMapTexture, xlv_TEXCOORD2).x;
  dist_6 = tmpvar_7;
  highp float tmpvar_8;
  tmpvar_8 = _LightShadowData.x;
  lightShadowDataX_5 = tmpvar_8;
  highp float tmpvar_9;
  tmpvar_9 = max (float((dist_6 > 
    (xlv_TEXCOORD2.z / xlv_TEXCOORD2.w)
  )), lightShadowDataX_5);
  tmpvar_4 = tmpvar_9;
  mediump vec3 lm_10;
  lowp vec3 tmpvar_11;
  tmpvar_11 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz);
  lm_10 = tmpvar_11;
  lowp vec3 tmpvar_12;
  tmpvar_12 = vec3((tmpvar_4 * 2.0));
  mediump vec3 tmpvar_13;
  tmpvar_13 = (tmpvar_2.xyz * min (lm_10, tmpvar_12));
  c_1.xyz = tmpvar_13;
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  highp vec3 tmpvar_43;
  tmpvar_43 = (_Object2World * vertex_9).xyz;
  highp vec4 tmpvar_44;
  tmpvar_44 = (unity_4LightPosX0 - tmpvar_43.x);
  highp vec4 tmpvar_45;
  tmpvar_45 = (unity_4LightPosY0 - tmpvar_43.y);
  highp vec4 tmpvar_46;
  tmpvar_46 = (unity_4LightPosZ0 - tmpvar_43.z);
  highp vec4 tmpvar_47;
  tmpvar_47 = (((tmpvar_44 * tmpvar_44) + (tmpvar_45 * tmpvar_45)) + (tmpvar_46 * tmpvar_46));
  highp vec4 tmpvar_48;
  tmpvar_48 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_44 * tmpvar_26.x) + (tmpvar_45 * tmpvar_26.y)) + (tmpvar_46 * tmpvar_26.z))
   * 
    inversesqrt(tmpvar_47)
  )) * (1.0/((1.0 + 
    (tmpvar_47 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_49;
  tmpvar_49 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_48.x) + (unity_LightColor[1].xyz * tmpvar_48.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_48.z)
  ) + (unity_LightColor[3].xyz * tmpvar_48.w)));
  tmpvar_4 = tmpvar_49;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _WorldSpaceLightPos0;
uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp vec4 c_4;
  c_4.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz)
  ) * 2.0));
  c_4.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_4.w;
  c_1.xyz = (c_4.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  highp vec3 tmpvar_43;
  tmpvar_43 = (_Object2World * vertex_9).xyz;
  highp vec4 tmpvar_44;
  tmpvar_44 = (unity_4LightPosX0 - tmpvar_43.x);
  highp vec4 tmpvar_45;
  tmpvar_45 = (unity_4LightPosY0 - tmpvar_43.y);
  highp vec4 tmpvar_46;
  tmpvar_46 = (unity_4LightPosZ0 - tmpvar_43.z);
  highp vec4 tmpvar_47;
  tmpvar_47 = (((tmpvar_44 * tmpvar_44) + (tmpvar_45 * tmpvar_45)) + (tmpvar_46 * tmpvar_46));
  highp vec4 tmpvar_48;
  tmpvar_48 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_44 * tmpvar_26.x) + (tmpvar_45 * tmpvar_26.y)) + (tmpvar_46 * tmpvar_26.z))
   * 
    inversesqrt(tmpvar_47)
  )) * (1.0/((1.0 + 
    (tmpvar_47 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_49;
  tmpvar_49 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_48.x) + (unity_LightColor[1].xyz * tmpvar_48.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_48.z)
  ) + (unity_LightColor[3].xyz * tmpvar_48.w)));
  tmpvar_4 = tmpvar_49;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _WorldSpaceLightPos0;
uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp vec4 c_4;
  c_4.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz)
  ) * 2.0));
  c_4.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_4.w;
  c_1.xyz = (c_4.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  highp vec3 tmpvar_43;
  tmpvar_43 = (_Object2World * vertex_9).xyz;
  highp vec4 tmpvar_44;
  tmpvar_44 = (unity_4LightPosX0 - tmpvar_43.x);
  highp vec4 tmpvar_45;
  tmpvar_45 = (unity_4LightPosY0 - tmpvar_43.y);
  highp vec4 tmpvar_46;
  tmpvar_46 = (unity_4LightPosZ0 - tmpvar_43.z);
  highp vec4 tmpvar_47;
  tmpvar_47 = (((tmpvar_44 * tmpvar_44) + (tmpvar_45 * tmpvar_45)) + (tmpvar_46 * tmpvar_46));
  highp vec4 tmpvar_48;
  tmpvar_48 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_44 * tmpvar_26.x) + (tmpvar_45 * tmpvar_26.y)) + (tmpvar_46 * tmpvar_26.z))
   * 
    inversesqrt(tmpvar_47)
  )) * (1.0/((1.0 + 
    (tmpvar_47 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_49;
  tmpvar_49 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_48.x) + (unity_LightColor[1].xyz * tmpvar_48.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_48.z)
  ) + (unity_LightColor[3].xyz * tmpvar_48.w)));
  tmpvar_4 = tmpvar_49;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float tmpvar_4;
  mediump float lightShadowDataX_5;
  highp float dist_6;
  lowp float tmpvar_7;
  tmpvar_7 = texture2DProj (_ShadowMapTexture, xlv_TEXCOORD3).x;
  dist_6 = tmpvar_7;
  highp float tmpvar_8;
  tmpvar_8 = _LightShadowData.x;
  lightShadowDataX_5 = tmpvar_8;
  highp float tmpvar_9;
  tmpvar_9 = max (float((dist_6 > 
    (xlv_TEXCOORD3.z / xlv_TEXCOORD3.w)
  )), lightShadowDataX_5);
  tmpvar_4 = tmpvar_9;
  lowp vec4 c_10;
  c_10.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * tmpvar_4) * 2.0));
  c_10.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_10.w;
  c_1.xyz = (c_10.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  lowp float tmpvar_5;
  tmpvar_5 = shadow2DEXT (_ShadowMapTexture, xlv_TEXCOORD3.xyz);
  highp float tmpvar_6;
  tmpvar_6 = (_LightShadowData.x + (tmpvar_5 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * shadow_4) * 2.0));
  c_7.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_7.w;
  c_1.xyz = (c_7.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
in highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  mediump float tmpvar_5;
  tmpvar_5 = texture (_ShadowMapTexture, xlv_TEXCOORD3.xyz);
  lowp float tmpvar_6;
  tmpvar_6 = tmpvar_5;
  highp float tmpvar_7;
  tmpvar_7 = (_LightShadowData.x + (tmpvar_6 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_7;
  lowp vec4 c_8;
  c_8.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * shadow_4) * 2.0));
  c_8.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_8.w;
  c_1.xyz = (c_8.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  lowp float tmpvar_5;
  tmpvar_5 = shadow2DEXT (_ShadowMapTexture, xlv_TEXCOORD2.xyz);
  highp float tmpvar_6;
  tmpvar_6 = (_LightShadowData.x + (tmpvar_5 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_6;
  c_1.xyz = (tmpvar_2.xyz * min ((2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz), vec3((shadow_4 * 2.0))));
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec2 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec2 xlv_TEXCOORD1;
in highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  mediump float tmpvar_5;
  tmpvar_5 = texture (_ShadowMapTexture, xlv_TEXCOORD2.xyz);
  lowp float tmpvar_6;
  tmpvar_6 = tmpvar_5;
  highp float tmpvar_7;
  tmpvar_7 = (_LightShadowData.x + (tmpvar_6 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_7;
  c_1.xyz = (tmpvar_2.xyz * min ((2.0 * texture (unity_Lightmap, xlv_TEXCOORD1).xyz), vec3((shadow_4 * 2.0))));
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  lowp float tmpvar_5;
  tmpvar_5 = shadow2DEXT (_ShadowMapTexture, xlv_TEXCOORD2.xyz);
  highp float tmpvar_6;
  tmpvar_6 = (_LightShadowData.x + (tmpvar_5 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_6;
  mediump vec3 lm_7;
  lowp vec3 tmpvar_8;
  tmpvar_8 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD1).xyz);
  lm_7 = tmpvar_8;
  lowp vec3 tmpvar_9;
  tmpvar_9 = vec3((shadow_4 * 2.0));
  mediump vec3 tmpvar_10;
  tmpvar_10 = (tmpvar_2.xyz * min (lm_7, tmpvar_9));
  c_1.xyz = tmpvar_10;
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec2 xlv_TEXCOORD1;
out highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD2 = (unity_World2Shadow[0] * (_Object2World * vertex_6));
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec2 xlv_TEXCOORD1;
in highp vec4 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  mediump float tmpvar_5;
  tmpvar_5 = texture (_ShadowMapTexture, xlv_TEXCOORD2.xyz);
  lowp float tmpvar_6;
  tmpvar_6 = tmpvar_5;
  highp float tmpvar_7;
  tmpvar_7 = (_LightShadowData.x + (tmpvar_6 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_7;
  mediump vec3 lm_8;
  lowp vec3 tmpvar_9;
  tmpvar_9 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD1).xyz);
  lm_8 = tmpvar_9;
  lowp vec3 tmpvar_10;
  tmpvar_10 = vec3((shadow_4 * 2.0));
  mediump vec3 tmpvar_11;
  tmpvar_11 = (tmpvar_2.xyz * min (lm_8, tmpvar_10));
  c_1.xyz = tmpvar_11;
  c_1.w = (tmpvar_2.w * xlv_COLOR0.w);
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  highp vec3 tmpvar_43;
  tmpvar_43 = (_Object2World * vertex_9).xyz;
  highp vec4 tmpvar_44;
  tmpvar_44 = (unity_4LightPosX0 - tmpvar_43.x);
  highp vec4 tmpvar_45;
  tmpvar_45 = (unity_4LightPosY0 - tmpvar_43.y);
  highp vec4 tmpvar_46;
  tmpvar_46 = (unity_4LightPosZ0 - tmpvar_43.z);
  highp vec4 tmpvar_47;
  tmpvar_47 = (((tmpvar_44 * tmpvar_44) + (tmpvar_45 * tmpvar_45)) + (tmpvar_46 * tmpvar_46));
  highp vec4 tmpvar_48;
  tmpvar_48 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_44 * tmpvar_26.x) + (tmpvar_45 * tmpvar_26.y)) + (tmpvar_46 * tmpvar_26.z))
   * 
    inversesqrt(tmpvar_47)
  )) * (1.0/((1.0 + 
    (tmpvar_47 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_49;
  tmpvar_49 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_48.x) + (unity_LightColor[1].xyz * tmpvar_48.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_48.z)
  ) + (unity_LightColor[3].xyz * tmpvar_48.w)));
  tmpvar_4 = tmpvar_49;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  lowp float tmpvar_5;
  tmpvar_5 = shadow2DEXT (_ShadowMapTexture, xlv_TEXCOORD3.xyz);
  highp float tmpvar_6;
  tmpvar_6 = (_LightShadowData.x + (tmpvar_5 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * shadow_4) * 2.0));
  c_7.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_7.w;
  c_1.xyz = (c_7.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 shlight_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec4 pos_5;
  pos_5 = _glesVertex;
  highp vec2 offset_6;
  offset_6 = _glesTANGENT.xy;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _WaveAndDistance.w)) {
    offset_6 = vec2(0.0, 0.0);
  };
  pos_5.xyz = (_glesVertex.xyz + (offset_6.x * _CameraRight));
  pos_5.xyz = (pos_5.xyz + (offset_6.y * _CameraUp));
  highp vec4 vertex_9;
  vertex_9.yw = pos_5.yw;
  lowp vec4 color_10;
  color_10.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_11;
  highp vec3 waveMove_12;
  highp vec4 tmpvar_13;
  tmpvar_13 = ((fract(
    (((pos_5.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_5.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_13);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_14);
  highp vec4 tmpvar_17;
  tmpvar_17 = (((tmpvar_13 + 
    (tmpvar_15 * -0.161616)
  ) + (tmpvar_16 * 0.0083333)) + ((tmpvar_16 * tmpvar_14) * -0.00019841));
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * tmpvar_18);
  highp vec4 tmpvar_20;
  tmpvar_20 = (tmpvar_19 * _glesTANGENT.y);
  waveMove_12.y = 0.0;
  waveMove_12.x = dot (tmpvar_20, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_12.z = dot (tmpvar_20, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_9.xz = (pos_5.xz - (waveMove_12.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_21;
  tmpvar_21 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_19, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_11 = tmpvar_21;
  highp vec3 tmpvar_22;
  tmpvar_22 = (vertex_9.xyz - _CameraPosition.xyz);
  highp float tmpvar_23;
  tmpvar_23 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_22, tmpvar_22))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_10.w = tmpvar_23;
  lowp vec4 tmpvar_24;
  tmpvar_24.xyz = ((2.0 * waveColor_11) * _glesColor.xyz);
  tmpvar_24.w = color_10.w;
  highp mat3 tmpvar_25;
  tmpvar_25[0] = _Object2World[0].xyz;
  tmpvar_25[1] = _Object2World[1].xyz;
  tmpvar_25[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_26;
  tmpvar_26 = (tmpvar_25 * (_glesNormal * unity_Scale.w));
  tmpvar_3 = tmpvar_26;
  highp vec4 tmpvar_27;
  tmpvar_27.w = 1.0;
  tmpvar_27.xyz = tmpvar_26;
  mediump vec3 tmpvar_28;
  mediump vec4 normal_29;
  normal_29 = tmpvar_27;
  highp float vC_30;
  mediump vec3 x3_31;
  mediump vec3 x2_32;
  mediump vec3 x1_33;
  highp float tmpvar_34;
  tmpvar_34 = dot (unity_SHAr, normal_29);
  x1_33.x = tmpvar_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAg, normal_29);
  x1_33.y = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAb, normal_29);
  x1_33.z = tmpvar_36;
  mediump vec4 tmpvar_37;
  tmpvar_37 = (normal_29.xyzz * normal_29.yzzx);
  highp float tmpvar_38;
  tmpvar_38 = dot (unity_SHBr, tmpvar_37);
  x2_32.x = tmpvar_38;
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBg, tmpvar_37);
  x2_32.y = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBb, tmpvar_37);
  x2_32.z = tmpvar_40;
  mediump float tmpvar_41;
  tmpvar_41 = ((normal_29.x * normal_29.x) - (normal_29.y * normal_29.y));
  vC_30 = tmpvar_41;
  highp vec3 tmpvar_42;
  tmpvar_42 = (unity_SHC.xyz * vC_30);
  x3_31 = tmpvar_42;
  tmpvar_28 = ((x1_33 + x2_32) + x3_31);
  shlight_2 = tmpvar_28;
  tmpvar_4 = shlight_2;
  highp vec3 tmpvar_43;
  tmpvar_43 = (_Object2World * vertex_9).xyz;
  highp vec4 tmpvar_44;
  tmpvar_44 = (unity_4LightPosX0 - tmpvar_43.x);
  highp vec4 tmpvar_45;
  tmpvar_45 = (unity_4LightPosY0 - tmpvar_43.y);
  highp vec4 tmpvar_46;
  tmpvar_46 = (unity_4LightPosZ0 - tmpvar_43.z);
  highp vec4 tmpvar_47;
  tmpvar_47 = (((tmpvar_44 * tmpvar_44) + (tmpvar_45 * tmpvar_45)) + (tmpvar_46 * tmpvar_46));
  highp vec4 tmpvar_48;
  tmpvar_48 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_44 * tmpvar_26.x) + (tmpvar_45 * tmpvar_26.y)) + (tmpvar_46 * tmpvar_26.z))
   * 
    inversesqrt(tmpvar_47)
  )) * (1.0/((1.0 + 
    (tmpvar_47 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_49;
  tmpvar_49 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_48.x) + (unity_LightColor[1].xyz * tmpvar_48.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_48.z)
  ) + (unity_LightColor[3].xyz * tmpvar_48.w)));
  tmpvar_4 = tmpvar_49;
  gl_Position = (glstate_matrix_mvp * vertex_9);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_24;
  xlv_TEXCOORD1 = tmpvar_3;
  xlv_TEXCOORD2 = tmpvar_4;
  xlv_TEXCOORD3 = (unity_World2Shadow[0] * (_Object2World * vertex_9));
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp vec4 _LightShadowData;
uniform lowp vec4 _LightColor0;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
in highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  lowp float shadow_4;
  mediump float tmpvar_5;
  tmpvar_5 = texture (_ShadowMapTexture, xlv_TEXCOORD3.xyz);
  lowp float tmpvar_6;
  tmpvar_6 = tmpvar_5;
  highp float tmpvar_7;
  tmpvar_7 = (_LightShadowData.x + (tmpvar_6 * (1.0 - _LightShadowData.x)));
  shadow_4 = tmpvar_7;
  lowp vec4 c_8;
  c_8.xyz = ((tmpvar_2.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, _WorldSpaceLightPos0.xyz))
   * shadow_4) * 2.0));
  c_8.w = (tmpvar_2.w * xlv_COLOR0.w);
  c_1.w = c_8.w;
  c_1.xyz = (c_8.xyz + (tmpvar_2.xyz * xlv_TEXCOORD2));
  _glesFragData[0] = c_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "SHADOWS_NATIVE" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "POINT" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xyz;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp float tmpvar_6;
  tmpvar_6 = dot (xlv_TEXCOORD3, xlv_TEXCOORD3);
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * texture2D (_LightTexture0, vec2(tmpvar_6)).w) * 2.0));
  c_7.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_7.xyz;
  c_1.w = 0.0;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "POINT" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out mediump vec3 xlv_TEXCOORD2;
out highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in mediump vec3 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp float tmpvar_6;
  tmpvar_6 = dot (xlv_TEXCOORD3, xlv_TEXCOORD3);
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * texture (_LightTexture0, vec2(tmpvar_6)).w) * 2.0));
  c_7.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_7.xyz;
  c_1.w = 0.0;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  lightDir_2 = xlv_TEXCOORD2;
  lowp vec4 c_5;
  c_5.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, lightDir_2)
  ) * 2.0));
  c_5.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_5.xyz;
  c_1.w = 0.0;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out mediump vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _LightColor0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in mediump vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  lightDir_2 = xlv_TEXCOORD2;
  lowp vec4 c_5;
  c_5.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * (max (0.0, 
    dot (xlv_TEXCOORD1, lightDir_2)
  ) * 2.0));
  c_5.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_5.xyz;
  c_1.w = 0.0;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "SPOT" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8));
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _LightTextureB0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp vec2 P_6;
  P_6 = ((xlv_TEXCOORD3.xy / xlv_TEXCOORD3.w) + 0.5);
  highp float tmpvar_7;
  tmpvar_7 = dot (xlv_TEXCOORD3.xyz, xlv_TEXCOORD3.xyz);
  lowp float atten_8;
  atten_8 = ((float(
    (xlv_TEXCOORD3.z > 0.0)
  ) * texture2D (_LightTexture0, P_6).w) * texture2D (_LightTextureB0, vec2(tmpvar_7)).w);
  lowp vec4 c_9;
  c_9.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * atten_8) * 2.0));
  c_9.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_9.xyz;
  c_1.w = 0.0;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SPOT" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out mediump vec3 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8));
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _LightTextureB0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in mediump vec3 xlv_TEXCOORD2;
in highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp vec2 P_6;
  P_6 = ((xlv_TEXCOORD3.xy / xlv_TEXCOORD3.w) + 0.5);
  highp float tmpvar_7;
  tmpvar_7 = dot (xlv_TEXCOORD3.xyz, xlv_TEXCOORD3.xyz);
  lowp float atten_8;
  atten_8 = ((float(
    (xlv_TEXCOORD3.z > 0.0)
  ) * texture (_LightTexture0, P_6).w) * texture (_LightTextureB0, vec2(tmpvar_7)).w);
  lowp vec4 c_9;
  c_9.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * atten_8) * 2.0));
  c_9.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_9.xyz;
  c_1.w = 0.0;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "POINT_COOKIE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xyz;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _LightColor0;
uniform lowp samplerCube _LightTexture0;
uniform sampler2D _LightTextureB0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp float tmpvar_6;
  tmpvar_6 = dot (xlv_TEXCOORD3, xlv_TEXCOORD3);
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * 
    (texture2D (_LightTextureB0, vec2(tmpvar_6)).w * textureCube (_LightTexture0, xlv_TEXCOORD3).w)
  ) * 2.0));
  c_7.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_7.xyz;
  c_1.w = 0.0;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "POINT_COOKIE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out mediump vec3 xlv_TEXCOORD2;
out highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = (_WorldSpaceLightPos0.xyz - (_Object2World * vertex_8).xyz);
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _LightColor0;
uniform lowp samplerCube _LightTexture0;
uniform sampler2D _LightTextureB0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in mediump vec3 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  mediump vec3 tmpvar_5;
  tmpvar_5 = normalize(xlv_TEXCOORD2);
  lightDir_2 = tmpvar_5;
  highp float tmpvar_6;
  tmpvar_6 = dot (xlv_TEXCOORD3, xlv_TEXCOORD3);
  lowp vec4 c_7;
  c_7.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * 
    (texture (_LightTextureB0, vec2(tmpvar_6)).w * texture (_LightTexture0, xlv_TEXCOORD3).w)
  ) * 2.0));
  c_7.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_7.xyz;
  c_1.w = 0.0;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec2 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xy;
}



#endif
#ifdef FRAGMENT

uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
varying mediump vec3 xlv_TEXCOORD2;
varying highp vec2 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  lightDir_2 = xlv_TEXCOORD2;
  lowp vec4 c_5;
  c_5.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * texture2D (_LightTexture0, xlv_TEXCOORD3).w) * 2.0));
  c_5.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_5.xyz;
  c_1.w = 0.0;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
out mediump vec3 xlv_TEXCOORD2;
out highp vec2 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesTANGENT.xy;
  highp vec3 tmpvar_6;
  tmpvar_6 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_7;
  tmpvar_7 = dot (tmpvar_6, tmpvar_6);
  if ((tmpvar_7 > _WaveAndDistance.w)) {
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (offset_5.x * _CameraRight));
  pos_4.xyz = (pos_4.xyz + (offset_5.y * _CameraUp));
  highp vec4 vertex_8;
  vertex_8.yw = pos_4.yw;
  lowp vec4 color_9;
  color_9.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_10;
  highp vec3 waveMove_11;
  highp vec4 tmpvar_12;
  tmpvar_12 = ((fract(
    (((pos_4.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_4.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_12);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_13);
  highp vec4 tmpvar_16;
  tmpvar_16 = (((tmpvar_12 + 
    (tmpvar_14 * -0.161616)
  ) + (tmpvar_15 * 0.0083333)) + ((tmpvar_15 * tmpvar_13) * -0.00019841));
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * tmpvar_17);
  highp vec4 tmpvar_19;
  tmpvar_19 = (tmpvar_18 * _glesTANGENT.y);
  waveMove_11.y = 0.0;
  waveMove_11.x = dot (tmpvar_19, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_11.z = dot (tmpvar_19, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_8.xz = (pos_4.xz - (waveMove_11.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_20;
  tmpvar_20 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_18, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_10 = tmpvar_20;
  highp vec3 tmpvar_21;
  tmpvar_21 = (vertex_8.xyz - _CameraPosition.xyz);
  highp float tmpvar_22;
  tmpvar_22 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_21, tmpvar_21))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_9.w = tmpvar_22;
  lowp vec4 tmpvar_23;
  tmpvar_23.xyz = ((2.0 * waveColor_10) * _glesColor.xyz);
  tmpvar_23.w = color_9.w;
  highp mat3 tmpvar_24;
  tmpvar_24[0] = _Object2World[0].xyz;
  tmpvar_24[1] = _Object2World[1].xyz;
  tmpvar_24[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_25;
  tmpvar_25 = (tmpvar_24 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_25;
  highp vec3 tmpvar_26;
  tmpvar_26 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_26;
  gl_Position = (glstate_matrix_mvp * vertex_8);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_23;
  xlv_TEXCOORD1 = tmpvar_2;
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = (_LightMatrix0 * (_Object2World * vertex_8)).xy;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform lowp vec4 _LightColor0;
uniform sampler2D _LightTexture0;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
in mediump vec3 xlv_TEXCOORD2;
in highp vec2 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 c_1;
  lowp vec3 lightDir_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_4;
  x_4 = (tmpvar_3.w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  lightDir_2 = xlv_TEXCOORD2;
  lowp vec4 c_5;
  c_5.xyz = ((tmpvar_3.xyz * _LightColor0.xyz) * ((
    max (0.0, dot (xlv_TEXCOORD1, lightDir_2))
   * texture (_LightTexture0, xlv_TEXCOORD3).w) * 2.0));
  c_5.w = (tmpvar_3.w * xlv_COLOR0.w);
  c_1.xyz = c_5.xyz;
  c_1.w = 0.0;
  _glesFragData[0] = c_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "POINT" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "POINT" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "SPOT" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "SPOT" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "POINT_COOKIE" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "POINT_COOKIE" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES3"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  Cull Off
  Fog { Mode Off }
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp mat3 tmpvar_23;
  tmpvar_23[0] = _Object2World[0].xyz;
  tmpvar_23[1] = _Object2World[1].xyz;
  tmpvar_23[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_24;
  tmpvar_24 = (tmpvar_23 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_24;
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying lowp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 res_1;
  lowp float x_2;
  x_2 = ((texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0).w - _Cutoff);
  if ((x_2 < 0.0)) {
    discard;
  };
  res_1.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  res_1.w = 0.0;
  gl_FragData[0] = res_1;
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out lowp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  lowp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp mat3 tmpvar_23;
  tmpvar_23[0] = _Object2World[0].xyz;
  tmpvar_23[1] = _Object2World[1].xyz;
  tmpvar_23[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_24;
  tmpvar_24 = (tmpvar_23 * (_glesNormal * unity_Scale.w));
  tmpvar_2 = tmpvar_24;
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in lowp vec3 xlv_TEXCOORD1;
void main ()
{
  lowp vec4 res_1;
  lowp float x_2;
  x_2 = ((texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0).w - _Cutoff);
  if ((x_2 < 0.0)) {
    discard;
  };
  res_1.xyz = ((xlv_TEXCOORD1 * 0.5) + 0.5);
  res_1.w = 0.0;
  _glesFragData[0] = res_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  ZWrite Off
  Cull Off
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  highp mat3 tmpvar_27;
  tmpvar_27[0] = _Object2World[0].xyz;
  tmpvar_27[1] = _Object2World[1].xyz;
  tmpvar_27[2] = _Object2World[2].xyz;
  highp vec4 tmpvar_28;
  tmpvar_28.w = 1.0;
  tmpvar_28.xyz = (tmpvar_27 * (_glesNormal * unity_Scale.w));
  mediump vec3 tmpvar_29;
  mediump vec4 normal_30;
  normal_30 = tmpvar_28;
  highp float vC_31;
  mediump vec3 x3_32;
  mediump vec3 x2_33;
  mediump vec3 x1_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAr, normal_30);
  x1_34.x = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAg, normal_30);
  x1_34.y = tmpvar_36;
  highp float tmpvar_37;
  tmpvar_37 = dot (unity_SHAb, normal_30);
  x1_34.z = tmpvar_37;
  mediump vec4 tmpvar_38;
  tmpvar_38 = (normal_30.xyzz * normal_30.yzzx);
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBr, tmpvar_38);
  x2_33.x = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBg, tmpvar_38);
  x2_33.y = tmpvar_40;
  highp float tmpvar_41;
  tmpvar_41 = dot (unity_SHBb, tmpvar_38);
  x2_33.z = tmpvar_41;
  mediump float tmpvar_42;
  tmpvar_42 = ((normal_30.x * normal_30.x) - (normal_30.y * normal_30.y));
  vC_31 = tmpvar_42;
  highp vec3 tmpvar_43;
  tmpvar_43 = (unity_SHC.xyz * vC_31);
  x3_32 = tmpvar_43;
  tmpvar_29 = ((x1_34 + x2_33) + x3_32);
  tmpvar_2 = tmpvar_29;
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD2);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  mediump vec3 tmpvar_10;
  tmpvar_10 = (tmpvar_4.xyz * light_3.xyz);
  c_9.xyz = tmpvar_10;
  c_9.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_9;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  highp mat3 tmpvar_27;
  tmpvar_27[0] = _Object2World[0].xyz;
  tmpvar_27[1] = _Object2World[1].xyz;
  tmpvar_27[2] = _Object2World[2].xyz;
  highp vec4 tmpvar_28;
  tmpvar_28.w = 1.0;
  tmpvar_28.xyz = (tmpvar_27 * (_glesNormal * unity_Scale.w));
  mediump vec3 tmpvar_29;
  mediump vec4 normal_30;
  normal_30 = tmpvar_28;
  highp float vC_31;
  mediump vec3 x3_32;
  mediump vec3 x2_33;
  mediump vec3 x1_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAr, normal_30);
  x1_34.x = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAg, normal_30);
  x1_34.y = tmpvar_36;
  highp float tmpvar_37;
  tmpvar_37 = dot (unity_SHAb, normal_30);
  x1_34.z = tmpvar_37;
  mediump vec4 tmpvar_38;
  tmpvar_38 = (normal_30.xyzz * normal_30.yzzx);
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBr, tmpvar_38);
  x2_33.x = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBg, tmpvar_38);
  x2_33.y = tmpvar_40;
  highp float tmpvar_41;
  tmpvar_41 = dot (unity_SHBb, tmpvar_38);
  x2_33.z = tmpvar_41;
  mediump float tmpvar_42;
  tmpvar_42 = ((normal_30.x * normal_30.x) - (normal_30.y * normal_30.y));
  vC_31 = tmpvar_42;
  highp vec3 tmpvar_43;
  tmpvar_43 = (unity_SHC.xyz * vC_31);
  x3_32 = tmpvar_43;
  tmpvar_29 = ((x1_34 + x2_33) + x3_32);
  tmpvar_2 = tmpvar_29;
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = -(log2(max (light_3, vec4(0.001, 0.001, 0.001, 0.001))));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD2);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  mediump vec3 tmpvar_10;
  tmpvar_10 = (tmpvar_4.xyz * light_3.xyz);
  c_9.xyz = tmpvar_10;
  c_9.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_9;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  tmpvar_2.xyz = (((_Object2World * vertex_7).xyz - unity_ShadowFadeCenterAndType.xyz) * unity_ShadowFadeCenterAndType.w);
  tmpvar_2.w = (-((glstate_matrix_modelview0 * vertex_7).z) * (1.0 - unity_ShadowFadeCenterAndType.w));
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD3 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
uniform sampler2D unity_LightmapInd;
uniform highp vec4 unity_LightmapFade;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec3 lmIndirect_3;
  mediump vec3 lmFull_4;
  mediump float lmFade_5;
  mediump vec4 light_6;
  lowp vec4 tmpvar_7;
  tmpvar_7 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_8;
  x_8 = (tmpvar_7.w - _Cutoff);
  if ((x_8 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_9;
  tmpvar_9 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_6 = tmpvar_9;
  mediump vec4 tmpvar_10;
  tmpvar_10 = -(log2(max (light_6, vec4(0.001, 0.001, 0.001, 0.001))));
  light_6.w = tmpvar_10.w;
  highp float tmpvar_11;
  tmpvar_11 = ((sqrt(
    dot (xlv_TEXCOORD3, xlv_TEXCOORD3)
  ) * unity_LightmapFade.z) + unity_LightmapFade.w);
  lmFade_5 = tmpvar_11;
  lowp vec3 tmpvar_12;
  tmpvar_12 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lmFull_4 = tmpvar_12;
  lowp vec3 tmpvar_13;
  tmpvar_13 = (2.0 * texture2D (unity_LightmapInd, xlv_TEXCOORD2).xyz);
  lmIndirect_3 = tmpvar_13;
  light_6.xyz = (tmpvar_10.xyz + mix (lmIndirect_3, lmFull_4, vec3(clamp (lmFade_5, 0.0, 1.0))));
  lowp vec4 c_14;
  mediump vec3 tmpvar_15;
  tmpvar_15 = (tmpvar_7.xyz * light_6.xyz);
  c_14.xyz = tmpvar_15;
  c_14.w = (tmpvar_7.w * xlv_COLOR0.w);
  c_2 = c_14;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec2 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  tmpvar_2.xyz = (((_Object2World * vertex_7).xyz - unity_ShadowFadeCenterAndType.xyz) * unity_ShadowFadeCenterAndType.w);
  tmpvar_2.w = (-((glstate_matrix_modelview0 * vertex_7).z) * (1.0 - unity_ShadowFadeCenterAndType.w));
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD3 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
uniform sampler2D unity_LightmapInd;
uniform highp vec4 unity_LightmapFade;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec2 xlv_TEXCOORD2;
in highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec3 lmIndirect_3;
  mediump vec3 lmFull_4;
  mediump float lmFade_5;
  mediump vec4 light_6;
  lowp vec4 tmpvar_7;
  tmpvar_7 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_8;
  x_8 = (tmpvar_7.w - _Cutoff);
  if ((x_8 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_9;
  tmpvar_9 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_6 = tmpvar_9;
  mediump vec4 tmpvar_10;
  tmpvar_10 = -(log2(max (light_6, vec4(0.001, 0.001, 0.001, 0.001))));
  light_6.w = tmpvar_10.w;
  highp float tmpvar_11;
  tmpvar_11 = ((sqrt(
    dot (xlv_TEXCOORD3, xlv_TEXCOORD3)
  ) * unity_LightmapFade.z) + unity_LightmapFade.w);
  lmFade_5 = tmpvar_11;
  lowp vec3 tmpvar_12;
  tmpvar_12 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lmFull_4 = tmpvar_12;
  lowp vec3 tmpvar_13;
  tmpvar_13 = (2.0 * texture (unity_LightmapInd, xlv_TEXCOORD2).xyz);
  lmIndirect_3 = tmpvar_13;
  light_6.xyz = (tmpvar_10.xyz + mix (lmIndirect_3, lmFull_4, vec3(clamp (lmFade_5, 0.0, 1.0))));
  lowp vec4 c_14;
  mediump vec3 tmpvar_15;
  tmpvar_15 = (tmpvar_7.xyz * light_6.xyz);
  c_14.xyz = tmpvar_15;
  c_14.w = (tmpvar_7.w * xlv_COLOR0.w);
  c_2 = c_14;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  highp vec4 tmpvar_22;
  tmpvar_22 = (glstate_matrix_mvp * vertex_6);
  highp vec4 o_23;
  highp vec4 tmpvar_24;
  tmpvar_24 = (tmpvar_22 * 0.5);
  highp vec2 tmpvar_25;
  tmpvar_25.x = tmpvar_24.x;
  tmpvar_25.y = (tmpvar_24.y * _ProjectionParams.x);
  o_23.xy = (tmpvar_25 + tmpvar_24.w);
  o_23.zw = tmpvar_22.zw;
  gl_Position = tmpvar_22;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = o_23;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec3 lm_7;
  lowp vec3 tmpvar_8;
  tmpvar_8 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lm_7 = tmpvar_8;
  mediump vec4 tmpvar_9;
  tmpvar_9.w = 0.0;
  tmpvar_9.xyz = lm_7;
  mediump vec4 tmpvar_10;
  tmpvar_10 = (-(log2(
    max (light_3, vec4(0.001, 0.001, 0.001, 0.001))
  )) + tmpvar_9);
  light_3 = tmpvar_10;
  lowp vec4 c_11;
  mediump vec3 tmpvar_12;
  tmpvar_12 = (tmpvar_4.xyz * tmpvar_10.xyz);
  c_11.xyz = tmpvar_12;
  c_11.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_11;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  highp vec4 tmpvar_22;
  tmpvar_22 = (glstate_matrix_mvp * vertex_6);
  highp vec4 o_23;
  highp vec4 tmpvar_24;
  tmpvar_24 = (tmpvar_22 * 0.5);
  highp vec2 tmpvar_25;
  tmpvar_25.x = tmpvar_24.x;
  tmpvar_25.y = (tmpvar_24.y * _ProjectionParams.x);
  o_23.xy = (tmpvar_25 + tmpvar_24.w);
  o_23.zw = tmpvar_22.zw;
  gl_Position = tmpvar_22;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = o_23;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec3 lm_7;
  lowp vec3 tmpvar_8;
  tmpvar_8 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lm_7 = tmpvar_8;
  mediump vec4 tmpvar_9;
  tmpvar_9.w = 0.0;
  tmpvar_9.xyz = lm_7;
  mediump vec4 tmpvar_10;
  tmpvar_10 = (-(log2(
    max (light_3, vec4(0.001, 0.001, 0.001, 0.001))
  )) + tmpvar_9);
  light_3 = tmpvar_10;
  lowp vec4 c_11;
  mediump vec3 tmpvar_12;
  tmpvar_12 = (tmpvar_4.xyz * tmpvar_10.xyz);
  c_11.xyz = tmpvar_12;
  c_11.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_11;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  highp mat3 tmpvar_27;
  tmpvar_27[0] = _Object2World[0].xyz;
  tmpvar_27[1] = _Object2World[1].xyz;
  tmpvar_27[2] = _Object2World[2].xyz;
  highp vec4 tmpvar_28;
  tmpvar_28.w = 1.0;
  tmpvar_28.xyz = (tmpvar_27 * (_glesNormal * unity_Scale.w));
  mediump vec3 tmpvar_29;
  mediump vec4 normal_30;
  normal_30 = tmpvar_28;
  highp float vC_31;
  mediump vec3 x3_32;
  mediump vec3 x2_33;
  mediump vec3 x1_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAr, normal_30);
  x1_34.x = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAg, normal_30);
  x1_34.y = tmpvar_36;
  highp float tmpvar_37;
  tmpvar_37 = dot (unity_SHAb, normal_30);
  x1_34.z = tmpvar_37;
  mediump vec4 tmpvar_38;
  tmpvar_38 = (normal_30.xyzz * normal_30.yzzx);
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBr, tmpvar_38);
  x2_33.x = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBg, tmpvar_38);
  x2_33.y = tmpvar_40;
  highp float tmpvar_41;
  tmpvar_41 = dot (unity_SHBb, tmpvar_38);
  x2_33.z = tmpvar_41;
  mediump float tmpvar_42;
  tmpvar_42 = ((normal_30.x * normal_30.x) - (normal_30.y * normal_30.y));
  vC_31 = tmpvar_42;
  highp vec3 tmpvar_43;
  tmpvar_43 = (unity_SHC.xyz * vC_31);
  x3_32 = tmpvar_43;
  tmpvar_29 = ((x1_34 + x2_33) + x3_32);
  tmpvar_2 = tmpvar_29;
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD2);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  mediump vec3 tmpvar_10;
  tmpvar_10 = (tmpvar_4.xyz * light_3.xyz);
  c_9.xyz = tmpvar_10;
  c_9.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_9;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec3 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  highp mat3 tmpvar_27;
  tmpvar_27[0] = _Object2World[0].xyz;
  tmpvar_27[1] = _Object2World[1].xyz;
  tmpvar_27[2] = _Object2World[2].xyz;
  highp vec4 tmpvar_28;
  tmpvar_28.w = 1.0;
  tmpvar_28.xyz = (tmpvar_27 * (_glesNormal * unity_Scale.w));
  mediump vec3 tmpvar_29;
  mediump vec4 normal_30;
  normal_30 = tmpvar_28;
  highp float vC_31;
  mediump vec3 x3_32;
  mediump vec3 x2_33;
  mediump vec3 x1_34;
  highp float tmpvar_35;
  tmpvar_35 = dot (unity_SHAr, normal_30);
  x1_34.x = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = dot (unity_SHAg, normal_30);
  x1_34.y = tmpvar_36;
  highp float tmpvar_37;
  tmpvar_37 = dot (unity_SHAb, normal_30);
  x1_34.z = tmpvar_37;
  mediump vec4 tmpvar_38;
  tmpvar_38 = (normal_30.xyzz * normal_30.yzzx);
  highp float tmpvar_39;
  tmpvar_39 = dot (unity_SHBr, tmpvar_38);
  x2_33.x = tmpvar_39;
  highp float tmpvar_40;
  tmpvar_40 = dot (unity_SHBg, tmpvar_38);
  x2_33.y = tmpvar_40;
  highp float tmpvar_41;
  tmpvar_41 = dot (unity_SHBb, tmpvar_38);
  x2_33.z = tmpvar_41;
  mediump float tmpvar_42;
  tmpvar_42 = ((normal_30.x * normal_30.x) - (normal_30.y * normal_30.y));
  vC_31 = tmpvar_42;
  highp vec3 tmpvar_43;
  tmpvar_43 = (unity_SHC.xyz * vC_31);
  x3_32 = tmpvar_43;
  tmpvar_29 = ((x1_34 + x2_33) + x3_32);
  tmpvar_2 = tmpvar_29;
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec4 tmpvar_7;
  tmpvar_7 = max (light_3, vec4(0.001, 0.001, 0.001, 0.001));
  light_3.w = tmpvar_7.w;
  highp vec3 tmpvar_8;
  tmpvar_8 = (tmpvar_7.xyz + xlv_TEXCOORD2);
  light_3.xyz = tmpvar_8;
  lowp vec4 c_9;
  mediump vec3 tmpvar_10;
  tmpvar_10 = (tmpvar_4.xyz * light_3.xyz);
  c_9.xyz = tmpvar_10;
  c_9.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_9;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  tmpvar_2.xyz = (((_Object2World * vertex_7).xyz - unity_ShadowFadeCenterAndType.xyz) * unity_ShadowFadeCenterAndType.w);
  tmpvar_2.w = (-((glstate_matrix_modelview0 * vertex_7).z) * (1.0 - unity_ShadowFadeCenterAndType.w));
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD3 = tmpvar_2;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
uniform sampler2D unity_LightmapInd;
uniform highp vec4 unity_LightmapFade;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
varying highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec3 lmIndirect_3;
  mediump vec3 lmFull_4;
  mediump float lmFade_5;
  mediump vec4 light_6;
  lowp vec4 tmpvar_7;
  tmpvar_7 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_8;
  x_8 = (tmpvar_7.w - _Cutoff);
  if ((x_8 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_9;
  tmpvar_9 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_6 = tmpvar_9;
  mediump vec4 tmpvar_10;
  tmpvar_10 = max (light_6, vec4(0.001, 0.001, 0.001, 0.001));
  light_6.w = tmpvar_10.w;
  highp float tmpvar_11;
  tmpvar_11 = ((sqrt(
    dot (xlv_TEXCOORD3, xlv_TEXCOORD3)
  ) * unity_LightmapFade.z) + unity_LightmapFade.w);
  lmFade_5 = tmpvar_11;
  lowp vec3 tmpvar_12;
  tmpvar_12 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lmFull_4 = tmpvar_12;
  lowp vec3 tmpvar_13;
  tmpvar_13 = (2.0 * texture2D (unity_LightmapInd, xlv_TEXCOORD2).xyz);
  lmIndirect_3 = tmpvar_13;
  light_6.xyz = (tmpvar_10.xyz + mix (lmIndirect_3, lmFull_4, vec3(clamp (lmFade_5, 0.0, 1.0))));
  lowp vec4 c_14;
  mediump vec3 tmpvar_15;
  tmpvar_15 = (tmpvar_7.xyz * light_6.xyz);
  c_14.xyz = tmpvar_15;
  c_14.w = (tmpvar_7.w * xlv_COLOR0.w);
  c_2 = c_14;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec2 xlv_TEXCOORD2;
out highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  highp vec4 o_24;
  highp vec4 tmpvar_25;
  tmpvar_25 = (tmpvar_23 * 0.5);
  highp vec2 tmpvar_26;
  tmpvar_26.x = tmpvar_25.x;
  tmpvar_26.y = (tmpvar_25.y * _ProjectionParams.x);
  o_24.xy = (tmpvar_26 + tmpvar_25.w);
  o_24.zw = tmpvar_23.zw;
  tmpvar_2.xyz = (((_Object2World * vertex_7).xyz - unity_ShadowFadeCenterAndType.xyz) * unity_ShadowFadeCenterAndType.w);
  tmpvar_2.w = (-((glstate_matrix_modelview0 * vertex_7).z) * (1.0 - unity_ShadowFadeCenterAndType.w));
  gl_Position = tmpvar_23;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
  xlv_TEXCOORD1 = o_24;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
  xlv_TEXCOORD3 = tmpvar_2;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
uniform sampler2D unity_LightmapInd;
uniform highp vec4 unity_LightmapFade;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec2 xlv_TEXCOORD2;
in highp vec4 xlv_TEXCOORD3;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec3 lmIndirect_3;
  mediump vec3 lmFull_4;
  mediump float lmFade_5;
  mediump vec4 light_6;
  lowp vec4 tmpvar_7;
  tmpvar_7 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_8;
  x_8 = (tmpvar_7.w - _Cutoff);
  if ((x_8 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_9;
  tmpvar_9 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_6 = tmpvar_9;
  mediump vec4 tmpvar_10;
  tmpvar_10 = max (light_6, vec4(0.001, 0.001, 0.001, 0.001));
  light_6.w = tmpvar_10.w;
  highp float tmpvar_11;
  tmpvar_11 = ((sqrt(
    dot (xlv_TEXCOORD3, xlv_TEXCOORD3)
  ) * unity_LightmapFade.z) + unity_LightmapFade.w);
  lmFade_5 = tmpvar_11;
  lowp vec3 tmpvar_12;
  tmpvar_12 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lmFull_4 = tmpvar_12;
  lowp vec3 tmpvar_13;
  tmpvar_13 = (2.0 * texture (unity_LightmapInd, xlv_TEXCOORD2).xyz);
  lmIndirect_3 = tmpvar_13;
  light_6.xyz = (tmpvar_10.xyz + mix (lmIndirect_3, lmFull_4, vec3(clamp (lmFade_5, 0.0, 1.0))));
  lowp vec4 c_14;
  mediump vec3 tmpvar_15;
  tmpvar_15 = (tmpvar_7.xyz * light_6.xyz);
  c_14.xyz = tmpvar_15;
  c_14.w = (tmpvar_7.w * xlv_COLOR0.w);
  c_2 = c_14;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
attribute vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  highp vec4 tmpvar_22;
  tmpvar_22 = (glstate_matrix_mvp * vertex_6);
  highp vec4 o_23;
  highp vec4 tmpvar_24;
  tmpvar_24 = (tmpvar_22 * 0.5);
  highp vec2 tmpvar_25;
  tmpvar_25.x = tmpvar_24.x;
  tmpvar_25.y = (tmpvar_24.y * _ProjectionParams.x);
  o_23.xy = (tmpvar_25 + tmpvar_24.w);
  o_23.zw = tmpvar_22.zw;
  gl_Position = tmpvar_22;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = o_23;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
varying highp vec2 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
varying highp vec4 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec3 lm_7;
  lowp vec3 tmpvar_8;
  tmpvar_8 = (2.0 * texture2D (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lm_7 = tmpvar_8;
  mediump vec4 tmpvar_9;
  tmpvar_9.w = 0.0;
  tmpvar_9.xyz = lm_7;
  mediump vec4 tmpvar_10;
  tmpvar_10 = (max (light_3, vec4(0.001, 0.001, 0.001, 0.001)) + tmpvar_9);
  light_3 = tmpvar_10;
  lowp vec4 c_11;
  mediump vec3 tmpvar_12;
  tmpvar_12 = (tmpvar_4.xyz * tmpvar_10.xyz);
  c_11.xyz = tmpvar_12;
  c_11.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_11;
  tmpvar_1 = c_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
in vec4 _glesTANGENT;
uniform highp vec4 _ProjectionParams;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
out highp vec4 xlv_TEXCOORD1;
out highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  highp vec4 tmpvar_22;
  tmpvar_22 = (glstate_matrix_mvp * vertex_6);
  highp vec4 o_23;
  highp vec4 tmpvar_24;
  tmpvar_24 = (tmpvar_22 * 0.5);
  highp vec2 tmpvar_25;
  tmpvar_25.x = tmpvar_24.x;
  tmpvar_25.y = (tmpvar_24.y * _ProjectionParams.x);
  o_23.xy = (tmpvar_25 + tmpvar_24.w);
  o_23.zw = tmpvar_22.zw;
  gl_Position = tmpvar_22;
  xlv_TEXCOORD0 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
  xlv_TEXCOORD1 = o_23;
  xlv_TEXCOORD2 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
uniform sampler2D _LightBuffer;
uniform sampler2D unity_Lightmap;
in highp vec2 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
in highp vec4 xlv_TEXCOORD1;
in highp vec2 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 tmpvar_1;
  mediump vec4 c_2;
  mediump vec4 light_3;
  lowp vec4 tmpvar_4;
  tmpvar_4 = (texture (_MainTex, xlv_TEXCOORD0) * xlv_COLOR0);
  lowp float x_5;
  x_5 = (tmpvar_4.w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  lowp vec4 tmpvar_6;
  tmpvar_6 = textureProj (_LightBuffer, xlv_TEXCOORD1);
  light_3 = tmpvar_6;
  mediump vec3 lm_7;
  lowp vec3 tmpvar_8;
  tmpvar_8 = (2.0 * texture (unity_Lightmap, xlv_TEXCOORD2).xyz);
  lm_7 = tmpvar_8;
  mediump vec4 tmpvar_9;
  tmpvar_9.w = 0.0;
  tmpvar_9.xyz = lm_7;
  mediump vec4 tmpvar_10;
  tmpvar_10 = (max (light_3, vec4(0.001, 0.001, 0.001, 0.001)) + tmpvar_9);
  light_3 = tmpvar_10;
  lowp vec4 c_11;
  mediump vec3 tmpvar_12;
  tmpvar_12 = (tmpvar_4.xyz * tmpvar_10.xyz);
  c_11.xyz = tmpvar_12;
  c_11.w = (tmpvar_4.w * xlv_COLOR0.w);
  c_2 = c_11;
  tmpvar_1 = c_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"!!GLES3"
}
}
 }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "SHADOWSUPPORT"="true" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  Cull Off
  Fog { Mode Off }
  ColorMask RGB
  Offset 1, 1
Program "vp" {
SubProgram "gles " {
Keywords { "SHADOWS_DEPTH" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec2 xlv_TEXCOORD1;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  tmpvar_2.xyw = tmpvar_23.xyw;
  tmpvar_2.z = (tmpvar_23.z + unity_LightShadowBias.x);
  tmpvar_2.z = mix (tmpvar_2.z, max (tmpvar_2.z, -(tmpvar_23.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD1;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp float x_1;
  x_1 = ((texture2D (_MainTex, xlv_TEXCOORD1) * xlv_COLOR0).w - _Cutoff);
  if ((x_1 < 0.0)) {
    discard;
  };
  gl_FragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_DEPTH" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec2 xlv_TEXCOORD1;
out lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (glstate_matrix_mvp * vertex_7);
  tmpvar_2.xyw = tmpvar_23.xyw;
  tmpvar_2.z = (tmpvar_23.z + unity_LightShadowBias.x);
  tmpvar_2.z = mix (tmpvar_2.z, max (tmpvar_2.z, -(tmpvar_23.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_2;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD1;
in lowp vec4 xlv_COLOR0;
void main ()
{
  lowp float x_1;
  x_1 = ((texture (_MainTex, xlv_TEXCOORD1) * xlv_COLOR0).w - _Cutoff);
  if ((x_1 < 0.0)) {
    discard;
  };
  _glesFragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif"
}
SubProgram "gles " {
Keywords { "SHADOWS_CUBE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp vec4 _LightPositionRange;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_Object2World * vertex_6).xyz - _LightPositionRange.xyz);
  xlv_TEXCOORD1 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
}



#endif
#ifdef FRAGMENT

uniform highp vec4 _LightPositionRange;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  lowp float x_2;
  x_2 = ((texture2D (_MainTex, xlv_TEXCOORD1) * xlv_COLOR0).w - _Cutoff);
  if ((x_2 < 0.0)) {
    discard;
  };
  highp vec4 tmpvar_3;
  tmpvar_3 = fract((vec4(1.0, 255.0, 65025.0, 1.65814e+07) * min (
    (sqrt(dot (xlv_TEXCOORD0, xlv_TEXCOORD0)) * _LightPositionRange.w)
  , 0.999)));
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_3 - (tmpvar_3.yzww * 0.00392157));
  tmpvar_1 = tmpvar_4;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_CUBE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp vec4 _LightPositionRange;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec3 xlv_TEXCOORD0;
out highp vec2 xlv_TEXCOORD1;
out lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 pos_2;
  pos_2 = _glesVertex;
  highp vec2 offset_3;
  offset_3 = _glesTANGENT.xy;
  highp vec3 tmpvar_4;
  tmpvar_4 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_5;
  tmpvar_5 = dot (tmpvar_4, tmpvar_4);
  if ((tmpvar_5 > _WaveAndDistance.w)) {
    offset_3 = vec2(0.0, 0.0);
  };
  pos_2.xyz = (_glesVertex.xyz + (offset_3.x * _CameraRight));
  pos_2.xyz = (pos_2.xyz + (offset_3.y * _CameraUp));
  highp vec4 vertex_6;
  vertex_6.yw = pos_2.yw;
  lowp vec4 color_7;
  color_7.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_8;
  highp vec3 waveMove_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = ((fract(
    (((pos_2.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_2.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_11;
  tmpvar_11 = (tmpvar_10 * tmpvar_10);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_10);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (((tmpvar_10 + 
    (tmpvar_12 * -0.161616)
  ) + (tmpvar_13 * 0.0083333)) + ((tmpvar_13 * tmpvar_11) * -0.00019841));
  highp vec4 tmpvar_15;
  tmpvar_15 = (tmpvar_14 * tmpvar_14);
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * _glesTANGENT.y);
  waveMove_9.y = 0.0;
  waveMove_9.x = dot (tmpvar_17, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_9.z = dot (tmpvar_17, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_6.xz = (pos_2.xz - (waveMove_9.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_18;
  tmpvar_18 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_16, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_8 = tmpvar_18;
  highp vec3 tmpvar_19;
  tmpvar_19 = (vertex_6.xyz - _CameraPosition.xyz);
  highp float tmpvar_20;
  tmpvar_20 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_19, tmpvar_19))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_7.w = tmpvar_20;
  lowp vec4 tmpvar_21;
  tmpvar_21.xyz = ((2.0 * waveColor_8) * _glesColor.xyz);
  tmpvar_21.w = color_7.w;
  gl_Position = (glstate_matrix_mvp * vertex_6);
  xlv_TEXCOORD0 = ((_Object2World * vertex_6).xyz - _LightPositionRange.xyz);
  xlv_TEXCOORD1 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_21;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp vec4 _LightPositionRange;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec3 xlv_TEXCOORD0;
in highp vec2 xlv_TEXCOORD1;
in lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  lowp float x_2;
  x_2 = ((texture (_MainTex, xlv_TEXCOORD1) * xlv_COLOR0).w - _Cutoff);
  if ((x_2 < 0.0)) {
    discard;
  };
  highp vec4 tmpvar_3;
  tmpvar_3 = fract((vec4(1.0, 255.0, 65025.0, 1.65814e+07) * min (
    (sqrt(dot (xlv_TEXCOORD0, xlv_TEXCOORD0)) * _LightPositionRange.w)
  , 0.999)));
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_3 - (tmpvar_3.yzww * 0.00392157));
  tmpvar_1 = tmpvar_4;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "SHADOWS_DEPTH" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_DEPTH" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "SHADOWS_CUBE" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_CUBE" }
"!!GLES3"
}
}
 }
 Pass {
  Name "SHADOWCOLLECTOR"
  Tags { "LIGHTMODE"="SHADOWCOLLECTOR" "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  Cull Off
  Fog { Mode Off }
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "SHADOWS_NONATIVE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT

uniform highp vec4 _ProjectionParams;
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp vec4 _LightShadowData;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  highp vec4 zFar_3;
  highp vec4 zNear_4;
  lowp float x_5;
  x_5 = ((texture2D (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  bvec4 tmpvar_6;
  tmpvar_6 = greaterThanEqual (xlv_TEXCOORD4.wwww, _LightSplitsNear);
  lowp vec4 tmpvar_7;
  tmpvar_7 = vec4(tmpvar_6);
  zNear_4 = tmpvar_7;
  bvec4 tmpvar_8;
  tmpvar_8 = lessThan (xlv_TEXCOORD4.wwww, _LightSplitsFar);
  lowp vec4 tmpvar_9;
  tmpvar_9 = vec4(tmpvar_8);
  zFar_3 = tmpvar_9;
  highp vec4 tmpvar_10;
  tmpvar_10 = (zNear_4 * zFar_3);
  highp float tmpvar_11;
  tmpvar_11 = clamp (((xlv_TEXCOORD4.w * _LightShadowData.z) + _LightShadowData.w), 0.0, 1.0);
  highp vec4 tmpvar_12;
  tmpvar_12.w = 1.0;
  tmpvar_12.xyz = (((
    (xlv_TEXCOORD0 * tmpvar_10.x)
   + 
    (xlv_TEXCOORD1 * tmpvar_10.y)
  ) + (xlv_TEXCOORD2 * tmpvar_10.z)) + (xlv_TEXCOORD3 * tmpvar_10.w));
  lowp vec4 tmpvar_13;
  tmpvar_13 = texture2D (_ShadowMapTexture, tmpvar_12.xy);
  highp float tmpvar_14;
  if ((tmpvar_13.x < tmpvar_12.z)) {
    tmpvar_14 = _LightShadowData.x;
  } else {
    tmpvar_14 = 1.0;
  };
  res_2.x = clamp ((tmpvar_14 + tmpvar_11), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_15;
  highp vec2 tmpvar_16;
  tmpvar_16 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_15.y = tmpvar_16.y;
  enc_15.x = (tmpvar_16.x - (tmpvar_16.y * 0.00392157));
  res_2.zw = enc_15;
  tmpvar_1 = res_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "SHADOWS_NATIVE" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform highp vec4 _ProjectionParams;
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  mediump float shadow_3;
  highp vec4 zFar_4;
  highp vec4 zNear_5;
  lowp float x_6;
  x_6 = ((texture2D (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_6 < 0.0)) {
    discard;
  };
  bvec4 tmpvar_7;
  tmpvar_7 = greaterThanEqual (xlv_TEXCOORD4.wwww, _LightSplitsNear);
  lowp vec4 tmpvar_8;
  tmpvar_8 = vec4(tmpvar_7);
  zNear_5 = tmpvar_8;
  bvec4 tmpvar_9;
  tmpvar_9 = lessThan (xlv_TEXCOORD4.wwww, _LightSplitsFar);
  lowp vec4 tmpvar_10;
  tmpvar_10 = vec4(tmpvar_9);
  zFar_4 = tmpvar_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = (zNear_5 * zFar_4);
  highp vec4 tmpvar_12;
  tmpvar_12.w = 1.0;
  tmpvar_12.xyz = (((
    (xlv_TEXCOORD0 * tmpvar_11.x)
   + 
    (xlv_TEXCOORD1 * tmpvar_11.y)
  ) + (xlv_TEXCOORD2 * tmpvar_11.z)) + (xlv_TEXCOORD3 * tmpvar_11.w));
  lowp float tmpvar_13;
  tmpvar_13 = shadow2DEXT (_ShadowMapTexture, tmpvar_12.xyz);
  mediump float tmpvar_14;
  tmpvar_14 = tmpvar_13;
  highp float tmpvar_15;
  tmpvar_15 = (_LightShadowData.x + (tmpvar_14 * (1.0 - _LightShadowData.x)));
  shadow_3 = tmpvar_15;
  res_2.x = clamp ((shadow_3 + clamp (
    ((xlv_TEXCOORD4.w * _LightShadowData.z) + _LightShadowData.w)
  , 0.0, 1.0)), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_16;
  highp vec2 tmpvar_17;
  tmpvar_17 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_16.y = tmpvar_17.y;
  enc_16.x = (tmpvar_17.x - (tmpvar_17.y * 0.00392157));
  res_2.zw = enc_16;
  tmpvar_1 = res_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_NATIVE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec3 xlv_TEXCOORD3;
out highp vec4 xlv_TEXCOORD4;
out highp vec2 xlv_TEXCOORD5;
out lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp vec4 _ProjectionParams;
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp vec4 _LightShadowData;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec3 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in highp vec3 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD3;
in highp vec4 xlv_TEXCOORD4;
in highp vec2 xlv_TEXCOORD5;
in lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  mediump float shadow_3;
  highp vec4 zFar_4;
  highp vec4 zNear_5;
  lowp float x_6;
  x_6 = ((texture (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_6 < 0.0)) {
    discard;
  };
  bvec4 tmpvar_7;
  tmpvar_7 = greaterThanEqual (xlv_TEXCOORD4.wwww, _LightSplitsNear);
  lowp vec4 tmpvar_8;
  tmpvar_8 = vec4(tmpvar_7);
  zNear_5 = tmpvar_8;
  bvec4 tmpvar_9;
  tmpvar_9 = lessThan (xlv_TEXCOORD4.wwww, _LightSplitsFar);
  lowp vec4 tmpvar_10;
  tmpvar_10 = vec4(tmpvar_9);
  zFar_4 = tmpvar_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = (zNear_5 * zFar_4);
  highp vec4 tmpvar_12;
  tmpvar_12.w = 1.0;
  tmpvar_12.xyz = (((
    (xlv_TEXCOORD0 * tmpvar_11.x)
   + 
    (xlv_TEXCOORD1 * tmpvar_11.y)
  ) + (xlv_TEXCOORD2 * tmpvar_11.z)) + (xlv_TEXCOORD3 * tmpvar_11.w));
  mediump float tmpvar_13;
  tmpvar_13 = texture (_ShadowMapTexture, tmpvar_12.xyz);
  highp float tmpvar_14;
  tmpvar_14 = (_LightShadowData.x + (tmpvar_13 * (1.0 - _LightShadowData.x)));
  shadow_3 = tmpvar_14;
  res_2.x = clamp ((shadow_3 + clamp (
    ((xlv_TEXCOORD4.w * _LightShadowData.z) + _LightShadowData.w)
  , 0.0, 1.0)), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_15;
  highp vec2 tmpvar_16;
  tmpvar_16 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_15.y = tmpvar_16.y;
  enc_15.x = (tmpvar_16.x - (tmpvar_16.y * 0.00392157));
  res_2.zw = enc_15;
  tmpvar_1 = res_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT

uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 _LightShadowData;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform sampler2D _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  highp vec4 cascadeWeights_3;
  lowp float x_4;
  x_4 = ((texture2D (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_4 < 0.0)) {
    discard;
  };
  highp vec3 tmpvar_5;
  tmpvar_5 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[0].xyz);
  highp vec3 tmpvar_6;
  tmpvar_6 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[1].xyz);
  highp vec3 tmpvar_7;
  tmpvar_7 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[2].xyz);
  highp vec3 tmpvar_8;
  tmpvar_8 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[3].xyz);
  highp vec4 tmpvar_9;
  tmpvar_9.x = dot (tmpvar_5, tmpvar_5);
  tmpvar_9.y = dot (tmpvar_6, tmpvar_6);
  tmpvar_9.z = dot (tmpvar_7, tmpvar_7);
  tmpvar_9.w = dot (tmpvar_8, tmpvar_8);
  bvec4 tmpvar_10;
  tmpvar_10 = lessThan (tmpvar_9, unity_ShadowSplitSqRadii);
  lowp vec4 tmpvar_11;
  tmpvar_11 = vec4(tmpvar_10);
  cascadeWeights_3 = tmpvar_11;
  cascadeWeights_3.yzw = clamp ((cascadeWeights_3.yzw - cascadeWeights_3.xyz), 0.0, 1.0);
  highp vec3 tmpvar_12;
  tmpvar_12 = (xlv_TEXCOORD4.xyz - unity_ShadowFadeCenterAndType.xyz);
  highp float tmpvar_13;
  tmpvar_13 = clamp (((
    sqrt(dot (tmpvar_12, tmpvar_12))
   * _LightShadowData.z) + _LightShadowData.w), 0.0, 1.0);
  highp vec4 tmpvar_14;
  tmpvar_14.w = 1.0;
  tmpvar_14.xyz = (((
    (xlv_TEXCOORD0 * cascadeWeights_3.x)
   + 
    (xlv_TEXCOORD1 * cascadeWeights_3.y)
  ) + (xlv_TEXCOORD2 * cascadeWeights_3.z)) + (xlv_TEXCOORD3 * cascadeWeights_3.w));
  lowp vec4 tmpvar_15;
  tmpvar_15 = texture2D (_ShadowMapTexture, tmpvar_14.xy);
  highp float tmpvar_16;
  if ((tmpvar_15.x < tmpvar_14.z)) {
    tmpvar_16 = _LightShadowData.x;
  } else {
    tmpvar_16 = 1.0;
  };
  res_2.x = clamp ((tmpvar_16 + tmpvar_13), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_17;
  highp vec2 tmpvar_18;
  tmpvar_18 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_17.y = tmpvar_18.y;
  enc_17.x = (tmpvar_18.x - (tmpvar_18.y * 0.00392157));
  res_2.zw = enc_17;
  tmpvar_1 = res_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
"!!GLES


#ifdef VERTEX

#extension GL_EXT_shadow_samplers : enable
attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT

#extension GL_EXT_shadow_samplers : enable
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 _LightShadowData;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec3 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
varying highp vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
varying highp vec2 xlv_TEXCOORD5;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  mediump float shadow_3;
  highp vec4 cascadeWeights_4;
  lowp float x_5;
  x_5 = ((texture2D (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  highp vec3 tmpvar_6;
  tmpvar_6 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[0].xyz);
  highp vec3 tmpvar_7;
  tmpvar_7 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[1].xyz);
  highp vec3 tmpvar_8;
  tmpvar_8 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[2].xyz);
  highp vec3 tmpvar_9;
  tmpvar_9 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[3].xyz);
  highp vec4 tmpvar_10;
  tmpvar_10.x = dot (tmpvar_6, tmpvar_6);
  tmpvar_10.y = dot (tmpvar_7, tmpvar_7);
  tmpvar_10.z = dot (tmpvar_8, tmpvar_8);
  tmpvar_10.w = dot (tmpvar_9, tmpvar_9);
  bvec4 tmpvar_11;
  tmpvar_11 = lessThan (tmpvar_10, unity_ShadowSplitSqRadii);
  lowp vec4 tmpvar_12;
  tmpvar_12 = vec4(tmpvar_11);
  cascadeWeights_4 = tmpvar_12;
  cascadeWeights_4.yzw = clamp ((cascadeWeights_4.yzw - cascadeWeights_4.xyz), 0.0, 1.0);
  highp vec3 tmpvar_13;
  tmpvar_13 = (xlv_TEXCOORD4.xyz - unity_ShadowFadeCenterAndType.xyz);
  highp vec4 tmpvar_14;
  tmpvar_14.w = 1.0;
  tmpvar_14.xyz = (((
    (xlv_TEXCOORD0 * cascadeWeights_4.x)
   + 
    (xlv_TEXCOORD1 * cascadeWeights_4.y)
  ) + (xlv_TEXCOORD2 * cascadeWeights_4.z)) + (xlv_TEXCOORD3 * cascadeWeights_4.w));
  lowp float tmpvar_15;
  tmpvar_15 = shadow2DEXT (_ShadowMapTexture, tmpvar_14.xyz);
  mediump float tmpvar_16;
  tmpvar_16 = tmpvar_15;
  highp float tmpvar_17;
  tmpvar_17 = (_LightShadowData.x + (tmpvar_16 * (1.0 - _LightShadowData.x)));
  shadow_3 = tmpvar_17;
  res_2.x = clamp ((shadow_3 + clamp (
    ((sqrt(dot (tmpvar_13, tmpvar_13)) * _LightShadowData.z) + _LightShadowData.w)
  , 0.0, 1.0)), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_18;
  highp vec2 tmpvar_19;
  tmpvar_19 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_18.y = tmpvar_19.y;
  enc_18.x = (tmpvar_19.x - (tmpvar_19.y * 0.00392157));
  res_2.zw = enc_18;
  tmpvar_1 = res_2;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesTANGENT;
uniform highp mat4 unity_World2Shadow[4];
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 _Object2World;
uniform lowp vec4 _WavingTint;
uniform highp vec4 _WaveAndDistance;
uniform highp vec4 _CameraPosition;
uniform highp vec3 _CameraRight;
uniform highp vec3 _CameraUp;
uniform highp vec4 _MainTex_ST;
out highp vec3 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
out highp vec3 xlv_TEXCOORD3;
out highp vec4 xlv_TEXCOORD4;
out highp vec2 xlv_TEXCOORD5;
out lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  highp vec4 pos_3;
  pos_3 = _glesVertex;
  highp vec2 offset_4;
  offset_4 = _glesTANGENT.xy;
  highp vec3 tmpvar_5;
  tmpvar_5 = (_glesVertex.xyz - _CameraPosition.xyz);
  highp float tmpvar_6;
  tmpvar_6 = dot (tmpvar_5, tmpvar_5);
  if ((tmpvar_6 > _WaveAndDistance.w)) {
    offset_4 = vec2(0.0, 0.0);
  };
  pos_3.xyz = (_glesVertex.xyz + (offset_4.x * _CameraRight));
  pos_3.xyz = (pos_3.xyz + (offset_4.y * _CameraUp));
  highp vec4 vertex_7;
  vertex_7.yw = pos_3.yw;
  lowp vec4 color_8;
  color_8.xyz = tmpvar_1.xyz;
  lowp vec3 waveColor_9;
  highp vec3 waveMove_10;
  highp vec4 tmpvar_11;
  tmpvar_11 = ((fract(
    (((pos_3.x * (vec4(0.012, 0.02, 0.06, 0.024) * _WaveAndDistance.y)) + (pos_3.z * (vec4(0.006, 0.02, 0.02, 0.05) * _WaveAndDistance.y))) + (_WaveAndDistance.x * vec4(1.2, 2.0, 1.6, 4.8)))
  ) * 6.40885) - 3.14159);
  highp vec4 tmpvar_12;
  tmpvar_12 = (tmpvar_11 * tmpvar_11);
  highp vec4 tmpvar_13;
  tmpvar_13 = (tmpvar_12 * tmpvar_11);
  highp vec4 tmpvar_14;
  tmpvar_14 = (tmpvar_13 * tmpvar_12);
  highp vec4 tmpvar_15;
  tmpvar_15 = (((tmpvar_11 + 
    (tmpvar_13 * -0.161616)
  ) + (tmpvar_14 * 0.0083333)) + ((tmpvar_14 * tmpvar_12) * -0.00019841));
  highp vec4 tmpvar_16;
  tmpvar_16 = (tmpvar_15 * tmpvar_15);
  highp vec4 tmpvar_17;
  tmpvar_17 = (tmpvar_16 * tmpvar_16);
  highp vec4 tmpvar_18;
  tmpvar_18 = (tmpvar_17 * _glesTANGENT.y);
  waveMove_10.y = 0.0;
  waveMove_10.x = dot (tmpvar_18, vec4(0.024, 0.04, -0.12, 0.096));
  waveMove_10.z = dot (tmpvar_18, vec4(0.006, 0.02, -0.02, 0.1));
  vertex_7.xz = (pos_3.xz - (waveMove_10.xz * _WaveAndDistance.z));
  highp vec3 tmpvar_19;
  tmpvar_19 = mix (vec3(0.5, 0.5, 0.5), _WavingTint.xyz, vec3((dot (tmpvar_17, vec4(0.6742, 0.6742, 0.26968, 0.13484)) * 0.7)));
  waveColor_9 = tmpvar_19;
  highp vec3 tmpvar_20;
  tmpvar_20 = (vertex_7.xyz - _CameraPosition.xyz);
  highp float tmpvar_21;
  tmpvar_21 = clamp (((2.0 * 
    (_WaveAndDistance.w - dot (tmpvar_20, tmpvar_20))
  ) * _CameraPosition.w), 0.0, 1.0);
  color_8.w = tmpvar_21;
  lowp vec4 tmpvar_22;
  tmpvar_22.xyz = ((2.0 * waveColor_9) * _glesColor.xyz);
  tmpvar_22.w = color_8.w;
  highp vec4 tmpvar_23;
  tmpvar_23 = (_Object2World * vertex_7);
  tmpvar_2.xyz = tmpvar_23.xyz;
  tmpvar_2.w = -((glstate_matrix_modelview0 * vertex_7).z);
  gl_Position = (glstate_matrix_mvp * vertex_7);
  xlv_TEXCOORD0 = (unity_World2Shadow[0] * tmpvar_23).xyz;
  xlv_TEXCOORD1 = (unity_World2Shadow[1] * tmpvar_23).xyz;
  xlv_TEXCOORD2 = (unity_World2Shadow[2] * tmpvar_23).xyz;
  xlv_TEXCOORD3 = (unity_World2Shadow[3] * tmpvar_23).xyz;
  xlv_TEXCOORD4 = tmpvar_2;
  xlv_TEXCOORD5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_COLOR0 = tmpvar_22;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp vec4 _ProjectionParams;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 _LightShadowData;
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform lowp sampler2DShadow _ShadowMapTexture;
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec3 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in highp vec3 xlv_TEXCOORD2;
in highp vec3 xlv_TEXCOORD3;
in highp vec4 xlv_TEXCOORD4;
in highp vec2 xlv_TEXCOORD5;
in lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 res_2;
  mediump float shadow_3;
  highp vec4 cascadeWeights_4;
  lowp float x_5;
  x_5 = ((texture (_MainTex, xlv_TEXCOORD5) * xlv_COLOR0).w - _Cutoff);
  if ((x_5 < 0.0)) {
    discard;
  };
  highp vec3 tmpvar_6;
  tmpvar_6 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[0].xyz);
  highp vec3 tmpvar_7;
  tmpvar_7 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[1].xyz);
  highp vec3 tmpvar_8;
  tmpvar_8 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[2].xyz);
  highp vec3 tmpvar_9;
  tmpvar_9 = (xlv_TEXCOORD4.xyz - unity_ShadowSplitSpheres[3].xyz);
  highp vec4 tmpvar_10;
  tmpvar_10.x = dot (tmpvar_6, tmpvar_6);
  tmpvar_10.y = dot (tmpvar_7, tmpvar_7);
  tmpvar_10.z = dot (tmpvar_8, tmpvar_8);
  tmpvar_10.w = dot (tmpvar_9, tmpvar_9);
  bvec4 tmpvar_11;
  tmpvar_11 = lessThan (tmpvar_10, unity_ShadowSplitSqRadii);
  lowp vec4 tmpvar_12;
  tmpvar_12 = vec4(tmpvar_11);
  cascadeWeights_4 = tmpvar_12;
  cascadeWeights_4.yzw = clamp ((cascadeWeights_4.yzw - cascadeWeights_4.xyz), 0.0, 1.0);
  highp vec3 tmpvar_13;
  tmpvar_13 = (xlv_TEXCOORD4.xyz - unity_ShadowFadeCenterAndType.xyz);
  highp vec4 tmpvar_14;
  tmpvar_14.w = 1.0;
  tmpvar_14.xyz = (((
    (xlv_TEXCOORD0 * cascadeWeights_4.x)
   + 
    (xlv_TEXCOORD1 * cascadeWeights_4.y)
  ) + (xlv_TEXCOORD2 * cascadeWeights_4.z)) + (xlv_TEXCOORD3 * cascadeWeights_4.w));
  mediump float tmpvar_15;
  tmpvar_15 = texture (_ShadowMapTexture, tmpvar_14.xyz);
  highp float tmpvar_16;
  tmpvar_16 = (_LightShadowData.x + (tmpvar_15 * (1.0 - _LightShadowData.x)));
  shadow_3 = tmpvar_16;
  res_2.x = clamp ((shadow_3 + clamp (
    ((sqrt(dot (tmpvar_13, tmpvar_13)) * _LightShadowData.z) + _LightShadowData.w)
  , 0.0, 1.0)), 0.0, 1.0);
  res_2.y = 1.0;
  highp vec2 enc_17;
  highp vec2 tmpvar_18;
  tmpvar_18 = fract((vec2(1.0, 255.0) * (1.0 - 
    (xlv_TEXCOORD4.w * _ProjectionParams.w)
  )));
  enc_17.y = tmpvar_18.y;
  enc_17.x = (tmpvar_18.x - (tmpvar_18.y * 0.00392157));
  res_2.zw = enc_17;
  tmpvar_1 = res_2;
  _glesFragData[0] = tmpvar_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "SHADOWS_NONATIVE" }
"!!GLES"
}
SubProgram "gles " {
Keywords { "SHADOWS_NATIVE" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_NATIVE" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
"!!GLES"
}
SubProgram "gles " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
"!!GLES3"
}
}
 }
}
SubShader { 
 Tags { "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
 Pass {
  Tags { "QUEUE"="Geometry+200" "IGNOREPROJECTOR"="true" "RenderType"="GrassBillboard" }
  Lighting On
  Cull Off
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
Program "vp" {
}
  SetTexture [_MainTex] { combine texture * primary double, texture alpha * primary alpha }
 }
}
Fallback Off
}