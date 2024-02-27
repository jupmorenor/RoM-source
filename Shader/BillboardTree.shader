//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/TerrainEngine/BillboardTree" {
Properties {
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent-100" "IGNOREPROJECTOR"="true" "RenderType"="TreeBillboard" }
 Pass {
  Tags { "QUEUE"="Transparent-100" "IGNOREPROJECTOR"="true" "RenderType"="TreeBillboard" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec4 _glesMultiTexCoord0;
attribute vec4 _glesMultiTexCoord1;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec3 _TreeBillboardCameraRight;
uniform highp vec4 _TreeBillboardCameraUp;
uniform highp vec4 _TreeBillboardCameraFront;
uniform highp vec4 _TreeBillboardCameraPos;
uniform highp vec4 _TreeBillboardDistances;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  tmpvar_2 = _glesMultiTexCoord0;
  highp vec2 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesMultiTexCoord1.xy;
  highp float offsetz_6;
  offsetz_6 = tmpvar_2.y;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _TreeBillboardCameraPos.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _TreeBillboardDistances.x)) {
    offsetz_6 = 0.0;
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (_TreeBillboardCameraRight * offset_5.x));
  pos_4.xyz = (pos_4.xyz + (_TreeBillboardCameraUp.xyz * mix (offset_5.y, offsetz_6, _TreeBillboardCameraPos.w)));
  pos_4.xyz = (pos_4.xyz + ((_TreeBillboardCameraFront.xyz * 
    abs(offset_5.x)
  ) * _TreeBillboardCameraUp.w));
  tmpvar_3.x = tmpvar_2.x;
  tmpvar_3.y = float((_glesMultiTexCoord0.y > 0.0));
  gl_Position = (glstate_matrix_mvp * pos_4);
  xlv_COLOR0 = tmpvar_1;
  xlv_TEXCOORD0 = tmpvar_3;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
varying lowp vec4 xlv_COLOR0;
varying highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  col_1.w = tmpvar_2.w;
  col_1.xyz = (tmpvar_2.xyz * xlv_COLOR0.xyz);
  if ((tmpvar_2.w < 0.0)) {
    discard;
  };
  gl_FragData[0] = col_1;
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesColor;
in vec4 _glesMultiTexCoord0;
in vec4 _glesMultiTexCoord1;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec3 _TreeBillboardCameraRight;
uniform highp vec4 _TreeBillboardCameraUp;
uniform highp vec4 _TreeBillboardCameraFront;
uniform highp vec4 _TreeBillboardCameraPos;
uniform highp vec4 _TreeBillboardDistances;
out lowp vec4 xlv_COLOR0;
out highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 tmpvar_2;
  tmpvar_2 = _glesMultiTexCoord0;
  highp vec2 tmpvar_3;
  highp vec4 pos_4;
  pos_4 = _glesVertex;
  highp vec2 offset_5;
  offset_5 = _glesMultiTexCoord1.xy;
  highp float offsetz_6;
  offsetz_6 = tmpvar_2.y;
  highp vec3 tmpvar_7;
  tmpvar_7 = (_glesVertex.xyz - _TreeBillboardCameraPos.xyz);
  highp float tmpvar_8;
  tmpvar_8 = dot (tmpvar_7, tmpvar_7);
  if ((tmpvar_8 > _TreeBillboardDistances.x)) {
    offsetz_6 = 0.0;
    offset_5 = vec2(0.0, 0.0);
  };
  pos_4.xyz = (_glesVertex.xyz + (_TreeBillboardCameraRight * offset_5.x));
  pos_4.xyz = (pos_4.xyz + (_TreeBillboardCameraUp.xyz * mix (offset_5.y, offsetz_6, _TreeBillboardCameraPos.w)));
  pos_4.xyz = (pos_4.xyz + ((_TreeBillboardCameraFront.xyz * 
    abs(offset_5.x)
  ) * _TreeBillboardCameraUp.w));
  tmpvar_3.x = tmpvar_2.x;
  tmpvar_3.y = float((_glesMultiTexCoord0.y > 0.0));
  gl_Position = (glstate_matrix_mvp * pos_4);
  xlv_COLOR0 = tmpvar_1;
  xlv_TEXCOORD0 = tmpvar_3;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
in lowp vec4 xlv_COLOR0;
in highp vec2 xlv_TEXCOORD0;
void main ()
{
  lowp vec4 col_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_MainTex, xlv_TEXCOORD0);
  col_1.w = tmpvar_2.w;
  col_1.xyz = (tmpvar_2.xyz * xlv_COLOR0.xyz);
  if ((tmpvar_2.w < 0.0)) {
    discard;
  };
  _glesFragData[0] = col_1;
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
}
Fallback Off
}