//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/RimAlpha_Not cull" {
Properties {
 _MainTex ("Diffuse Color", 2D) = "white" {}
 _RimPlus ("Rim Power", Range(-1,1)) = 1
 _RimMultip ("Rim Multiply", Range(1,10)) = 1
 _RimShine ("Rim Shinness", Range(0,2)) = 0.5
 _RimColor ("Shine Color", Color) = (0.1,0.1,0.1,1)
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Less
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
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
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying lowp vec3 xlv_TEXCOORD3;
void main ()
{
  highp vec3 shlight_1;
  mediump vec2 tmpvar_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec2 tmpvar_5;
  tmpvar_5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_2 = tmpvar_5;
  highp mat3 tmpvar_6;
  tmpvar_6[0] = _Object2World[0].xyz;
  tmpvar_6[1] = _Object2World[1].xyz;
  tmpvar_6[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_7;
  tmpvar_7 = (tmpvar_6 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_3 = tmpvar_7;
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = tmpvar_7;
  mediump vec3 tmpvar_9;
  mediump vec4 normal_10;
  normal_10 = tmpvar_8;
  highp float vC_11;
  mediump vec3 x3_12;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  highp float tmpvar_15;
  tmpvar_15 = dot (unity_SHAr, normal_10);
  x1_14.x = tmpvar_15;
  highp float tmpvar_16;
  tmpvar_16 = dot (unity_SHAg, normal_10);
  x1_14.y = tmpvar_16;
  highp float tmpvar_17;
  tmpvar_17 = dot (unity_SHAb, normal_10);
  x1_14.z = tmpvar_17;
  mediump vec4 tmpvar_18;
  tmpvar_18 = (normal_10.xyzz * normal_10.yzzx);
  highp float tmpvar_19;
  tmpvar_19 = dot (unity_SHBr, tmpvar_18);
  x2_13.x = tmpvar_19;
  highp float tmpvar_20;
  tmpvar_20 = dot (unity_SHBg, tmpvar_18);
  x2_13.y = tmpvar_20;
  highp float tmpvar_21;
  tmpvar_21 = dot (unity_SHBb, tmpvar_18);
  x2_13.z = tmpvar_21;
  mediump float tmpvar_22;
  tmpvar_22 = ((normal_10.x * normal_10.x) - (normal_10.y * normal_10.y));
  vC_11 = tmpvar_22;
  highp vec3 tmpvar_23;
  tmpvar_23 = (unity_SHC.xyz * vC_11);
  x3_12 = tmpvar_23;
  tmpvar_9 = ((x1_14 + x2_13) + x3_12);
  shlight_1 = tmpvar_9;
  tmpvar_4 = shlight_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
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
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out lowp vec3 xlv_TEXCOORD3;
void main ()
{
  highp vec3 shlight_1;
  mediump vec2 tmpvar_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec2 tmpvar_5;
  tmpvar_5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_2 = tmpvar_5;
  highp mat3 tmpvar_6;
  tmpvar_6[0] = _Object2World[0].xyz;
  tmpvar_6[1] = _Object2World[1].xyz;
  tmpvar_6[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_7;
  tmpvar_7 = (tmpvar_6 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_3 = tmpvar_7;
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = tmpvar_7;
  mediump vec3 tmpvar_9;
  mediump vec4 normal_10;
  normal_10 = tmpvar_8;
  highp float vC_11;
  mediump vec3 x3_12;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  highp float tmpvar_15;
  tmpvar_15 = dot (unity_SHAr, normal_10);
  x1_14.x = tmpvar_15;
  highp float tmpvar_16;
  tmpvar_16 = dot (unity_SHAg, normal_10);
  x1_14.y = tmpvar_16;
  highp float tmpvar_17;
  tmpvar_17 = dot (unity_SHAb, normal_10);
  x1_14.z = tmpvar_17;
  mediump vec4 tmpvar_18;
  tmpvar_18 = (normal_10.xyzz * normal_10.yzzx);
  highp float tmpvar_19;
  tmpvar_19 = dot (unity_SHBr, tmpvar_18);
  x2_13.x = tmpvar_19;
  highp float tmpvar_20;
  tmpvar_20 = dot (unity_SHBg, tmpvar_18);
  x2_13.y = tmpvar_20;
  highp float tmpvar_21;
  tmpvar_21 = dot (unity_SHBb, tmpvar_18);
  x2_13.z = tmpvar_21;
  mediump float tmpvar_22;
  tmpvar_22 = ((normal_10.x * normal_10.x) - (normal_10.y * normal_10.y));
  vC_11 = tmpvar_22;
  highp vec3 tmpvar_23;
  tmpvar_23 = (unity_SHC.xyz * vC_11);
  x3_12 = tmpvar_23;
  tmpvar_9 = ((x1_14 + x2_13) + x3_12);
  shlight_1 = tmpvar_9;
  tmpvar_4 = shlight_1;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec2 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp mat3 tmpvar_4;
  tmpvar_4[0] = _Object2World[0].xyz;
  tmpvar_4[1] = _Object2World[1].xyz;
  tmpvar_4[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_5;
  tmpvar_5 = (tmpvar_4 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_5;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out highp vec2 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp mat3 tmpvar_4;
  tmpvar_4[0] = _Object2World[0].xyz;
  tmpvar_4[1] = _Object2World[1].xyz;
  tmpvar_4[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_5;
  tmpvar_5 = (tmpvar_4 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_5;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying highp vec2 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp mat3 tmpvar_4;
  tmpvar_4[0] = _Object2World[0].xyz;
  tmpvar_4[1] = _Object2World[1].xyz;
  tmpvar_4[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_5;
  tmpvar_5 = (tmpvar_4 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_5;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 unity_LightmapST;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out highp vec2 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  highp vec2 tmpvar_3;
  tmpvar_3 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_3;
  highp mat3 tmpvar_4;
  tmpvar_4[0] = _Object2World[0].xyz;
  tmpvar_4[1] = _Object2World[1].xyz;
  tmpvar_4[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_5;
  tmpvar_5 = (tmpvar_4 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_5;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = ((_glesMultiTexCoord1.xy * unity_LightmapST.xy) + unity_LightmapST.zw);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
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
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying lowp vec3 xlv_TEXCOORD3;
void main ()
{
  highp vec3 shlight_1;
  mediump vec2 tmpvar_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec2 tmpvar_5;
  tmpvar_5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_2 = tmpvar_5;
  highp mat3 tmpvar_6;
  tmpvar_6[0] = _Object2World[0].xyz;
  tmpvar_6[1] = _Object2World[1].xyz;
  tmpvar_6[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_7;
  tmpvar_7 = (tmpvar_6 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_3 = tmpvar_7;
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = tmpvar_7;
  mediump vec3 tmpvar_9;
  mediump vec4 normal_10;
  normal_10 = tmpvar_8;
  highp float vC_11;
  mediump vec3 x3_12;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  highp float tmpvar_15;
  tmpvar_15 = dot (unity_SHAr, normal_10);
  x1_14.x = tmpvar_15;
  highp float tmpvar_16;
  tmpvar_16 = dot (unity_SHAg, normal_10);
  x1_14.y = tmpvar_16;
  highp float tmpvar_17;
  tmpvar_17 = dot (unity_SHAb, normal_10);
  x1_14.z = tmpvar_17;
  mediump vec4 tmpvar_18;
  tmpvar_18 = (normal_10.xyzz * normal_10.yzzx);
  highp float tmpvar_19;
  tmpvar_19 = dot (unity_SHBr, tmpvar_18);
  x2_13.x = tmpvar_19;
  highp float tmpvar_20;
  tmpvar_20 = dot (unity_SHBg, tmpvar_18);
  x2_13.y = tmpvar_20;
  highp float tmpvar_21;
  tmpvar_21 = dot (unity_SHBb, tmpvar_18);
  x2_13.z = tmpvar_21;
  mediump float tmpvar_22;
  tmpvar_22 = ((normal_10.x * normal_10.x) - (normal_10.y * normal_10.y));
  vC_11 = tmpvar_22;
  highp vec3 tmpvar_23;
  tmpvar_23 = (unity_SHC.xyz * vC_11);
  x3_12 = tmpvar_23;
  tmpvar_9 = ((x1_14 + x2_13) + x3_12);
  shlight_1 = tmpvar_9;
  tmpvar_4 = shlight_1;
  highp vec4 cse_24;
  cse_24 = (_Object2World * _glesVertex);
  highp vec4 tmpvar_25;
  tmpvar_25 = (unity_4LightPosX0 - cse_24.x);
  highp vec4 tmpvar_26;
  tmpvar_26 = (unity_4LightPosY0 - cse_24.y);
  highp vec4 tmpvar_27;
  tmpvar_27 = (unity_4LightPosZ0 - cse_24.z);
  highp vec4 tmpvar_28;
  tmpvar_28 = (((tmpvar_25 * tmpvar_25) + (tmpvar_26 * tmpvar_26)) + (tmpvar_27 * tmpvar_27));
  highp vec4 tmpvar_29;
  tmpvar_29 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_25 * tmpvar_7.x) + (tmpvar_26 * tmpvar_7.y)) + (tmpvar_27 * tmpvar_7.z))
   * 
    inversesqrt(tmpvar_28)
  )) * (1.0/((1.0 + 
    (tmpvar_28 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_30;
  tmpvar_30 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_29.x) + (unity_LightColor[1].xyz * tmpvar_29.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_29.z)
  ) + (unity_LightColor[3].xyz * tmpvar_29.w)));
  tmpvar_4 = tmpvar_30;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_24.xyz);
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
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
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out lowp vec3 xlv_TEXCOORD3;
void main ()
{
  highp vec3 shlight_1;
  mediump vec2 tmpvar_2;
  lowp vec3 tmpvar_3;
  lowp vec3 tmpvar_4;
  highp vec2 tmpvar_5;
  tmpvar_5 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_2 = tmpvar_5;
  highp mat3 tmpvar_6;
  tmpvar_6[0] = _Object2World[0].xyz;
  tmpvar_6[1] = _Object2World[1].xyz;
  tmpvar_6[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_7;
  tmpvar_7 = (tmpvar_6 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_3 = tmpvar_7;
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = tmpvar_7;
  mediump vec3 tmpvar_9;
  mediump vec4 normal_10;
  normal_10 = tmpvar_8;
  highp float vC_11;
  mediump vec3 x3_12;
  mediump vec3 x2_13;
  mediump vec3 x1_14;
  highp float tmpvar_15;
  tmpvar_15 = dot (unity_SHAr, normal_10);
  x1_14.x = tmpvar_15;
  highp float tmpvar_16;
  tmpvar_16 = dot (unity_SHAg, normal_10);
  x1_14.y = tmpvar_16;
  highp float tmpvar_17;
  tmpvar_17 = dot (unity_SHAb, normal_10);
  x1_14.z = tmpvar_17;
  mediump vec4 tmpvar_18;
  tmpvar_18 = (normal_10.xyzz * normal_10.yzzx);
  highp float tmpvar_19;
  tmpvar_19 = dot (unity_SHBr, tmpvar_18);
  x2_13.x = tmpvar_19;
  highp float tmpvar_20;
  tmpvar_20 = dot (unity_SHBg, tmpvar_18);
  x2_13.y = tmpvar_20;
  highp float tmpvar_21;
  tmpvar_21 = dot (unity_SHBb, tmpvar_18);
  x2_13.z = tmpvar_21;
  mediump float tmpvar_22;
  tmpvar_22 = ((normal_10.x * normal_10.x) - (normal_10.y * normal_10.y));
  vC_11 = tmpvar_22;
  highp vec3 tmpvar_23;
  tmpvar_23 = (unity_SHC.xyz * vC_11);
  x3_12 = tmpvar_23;
  tmpvar_9 = ((x1_14 + x2_13) + x3_12);
  shlight_1 = tmpvar_9;
  tmpvar_4 = shlight_1;
  highp vec4 cse_24;
  cse_24 = (_Object2World * _glesVertex);
  highp vec4 tmpvar_25;
  tmpvar_25 = (unity_4LightPosX0 - cse_24.x);
  highp vec4 tmpvar_26;
  tmpvar_26 = (unity_4LightPosY0 - cse_24.y);
  highp vec4 tmpvar_27;
  tmpvar_27 = (unity_4LightPosZ0 - cse_24.z);
  highp vec4 tmpvar_28;
  tmpvar_28 = (((tmpvar_25 * tmpvar_25) + (tmpvar_26 * tmpvar_26)) + (tmpvar_27 * tmpvar_27));
  highp vec4 tmpvar_29;
  tmpvar_29 = (max (vec4(0.0, 0.0, 0.0, 0.0), (
    (((tmpvar_25 * tmpvar_7.x) + (tmpvar_26 * tmpvar_7.y)) + (tmpvar_27 * tmpvar_7.z))
   * 
    inversesqrt(tmpvar_28)
  )) * (1.0/((1.0 + 
    (tmpvar_28 * unity_4LightAtten0)
  ))));
  highp vec3 tmpvar_30;
  tmpvar_30 = (tmpvar_4 + ((
    ((unity_LightColor[0].xyz * tmpvar_29.x) + (unity_LightColor[1].xyz * tmpvar_29.y))
   + 
    (unity_LightColor[2].xyz * tmpvar_29.z)
  ) + (unity_LightColor[3].xyz * tmpvar_29.w)));
  tmpvar_4 = tmpvar_30;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_24.xyz);
  xlv_TEXCOORD2 = tmpvar_3;
  xlv_TEXCOORD3 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
uniform mediump float _RimShine;
uniform mediump vec4 _RimColor;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp vec3 tmpvar_3;
  lowp float tmpvar_4;
  mediump vec4 tex_5;
  mediump float tmpvar_6;
  tmpvar_6 = (abs(dot (
    normalize(tmpvar_2)
  , xlv_TEXCOORD2)) - _RimPlus);
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture (_MainTex, xlv_TEXCOORD0);
  tex_5 = tmpvar_7;
  mediump float tmpvar_8;
  tmpvar_8 = ((tex_5.w - tmpvar_6) * _RimMultip);
  tmpvar_4 = tmpvar_8;
  mediump vec3 tmpvar_9;
  tmpvar_9 = (tex_5.xyz + ((
    (_RimColor - 0.5)
   * 
    (1.0 - tmpvar_6)
  ) * _RimShine).xyz);
  tmpvar_3 = tmpvar_9;
  c_1.xyz = tmpvar_3;
  c_1.w = tmpvar_4;
  _glesFragData[0] = c_1;
}



#endif"
}
}
Program "fp" {
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!GLES3"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!GLES3"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Less
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
Keywords { "POINT" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xyz;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "POINT" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  tmpvar_7 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  tmpvar_7 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - (_Object2World * _glesVertex).xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "SPOT" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying highp vec4 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "SPOT" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out highp vec4 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "POINT_COOKIE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying highp vec3 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xyz;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "POINT_COOKIE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out highp vec3 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = (_WorldSpaceLightPos0.xyz - cse_8.xyz);
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xyz;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  _glesFragData[0] = c_1;
}



#endif"
}
SubProgram "gles " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
varying mediump vec3 xlv_TEXCOORD3;
varying highp vec2 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xy;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
varying mediump vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
varying lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
  gl_FragData[0] = c_1;
}



#endif"
}
SubProgram "gles3 " {
Keywords { "DIRECTIONAL_COOKIE" }
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp vec3 _WorldSpaceCameraPos;
uniform lowp vec4 _WorldSpaceLightPos0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 _Object2World;
uniform highp vec4 unity_Scale;
uniform highp mat4 _LightMatrix0;
uniform highp vec4 _MainTex_ST;
out mediump vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
out lowp vec3 xlv_TEXCOORD2;
out mediump vec3 xlv_TEXCOORD3;
out highp vec2 xlv_TEXCOORD4;
void main ()
{
  mediump vec2 tmpvar_1;
  lowp vec3 tmpvar_2;
  mediump vec3 tmpvar_3;
  highp vec2 tmpvar_4;
  tmpvar_4 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  tmpvar_1 = tmpvar_4;
  highp mat3 tmpvar_5;
  tmpvar_5[0] = _Object2World[0].xyz;
  tmpvar_5[1] = _Object2World[1].xyz;
  tmpvar_5[2] = _Object2World[2].xyz;
  highp vec3 tmpvar_6;
  tmpvar_6 = (tmpvar_5 * (normalize(_glesNormal) * unity_Scale.w));
  tmpvar_2 = tmpvar_6;
  highp vec3 tmpvar_7;
  highp vec4 cse_8;
  cse_8 = (_Object2World * _glesVertex);
  tmpvar_7 = _WorldSpaceLightPos0.xyz;
  tmpvar_3 = tmpvar_7;
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = (_WorldSpaceCameraPos - cse_8.xyz);
  xlv_TEXCOORD2 = tmpvar_2;
  xlv_TEXCOORD3 = tmpvar_3;
  xlv_TEXCOORD4 = (_LightMatrix0 * cse_8).xy;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform mediump float _RimPlus;
uniform mediump float _RimMultip;
in mediump vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
in lowp vec3 xlv_TEXCOORD2;
void main ()
{
  lowp vec4 c_1;
  mediump vec3 tmpvar_2;
  tmpvar_2 = xlv_TEXCOORD1;
  lowp float tmpvar_3;
  mediump vec4 tex_4;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture (_MainTex, xlv_TEXCOORD0);
  tex_4 = tmpvar_5;
  mediump float tmpvar_6;
  tmpvar_6 = ((tex_4.w - (
    abs(dot (normalize(tmpvar_2), xlv_TEXCOORD2))
   - _RimPlus)) * _RimMultip);
  tmpvar_3 = tmpvar_6;
  lowp vec4 c_7;
  c_7.xyz = vec3(0.0, 0.0, 0.0);
  c_7.w = tmpvar_3;
  c_1.xyz = c_7.xyz;
  c_1.w = tmpvar_3;
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
}
Fallback "Diffuse"
}