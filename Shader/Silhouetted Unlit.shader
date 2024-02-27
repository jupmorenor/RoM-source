//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Outlined/Silhouetted Unlit" {
Properties {
 _OutlineColor ("Outline Color", Color) = (0,0,0,1)
 _Outline ("Outline width", Range(0,0.03)) = 0.005
 _OutlineOffsetZ ("Outline Offset Z", Float) = 0
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent" }
 Pass {
  Name "SILHOUETTED"
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
uniform highp mat4 glstate_matrix_projection;
uniform highp float _Outline;
uniform highp vec4 _OutlineColor;
uniform highp float _OutlineOffsetZ;
varying highp vec4 xlv_COLOR;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.w = tmpvar_2.w;
  highp mat3 tmpvar_3;
  tmpvar_3[0] = glstate_matrix_invtrans_modelview0[0].xyz;
  tmpvar_3[1] = glstate_matrix_invtrans_modelview0[1].xyz;
  tmpvar_3[2] = glstate_matrix_invtrans_modelview0[2].xyz;
  highp mat2 tmpvar_4;
  tmpvar_4[0] = glstate_matrix_projection[0].xy;
  tmpvar_4[1] = glstate_matrix_projection[1].xy;
  tmpvar_1.xy = (tmpvar_2.xy + ((
    (tmpvar_4 * (tmpvar_3 * normalize(_glesNormal)).xy)
   * tmpvar_2.z) * _Outline));
  tmpvar_1.z = (tmpvar_2.z + _OutlineOffsetZ);
  gl_Position = tmpvar_1;
  xlv_COLOR = _OutlineColor;
}



#endif
#ifdef FRAGMENT

varying highp vec4 xlv_COLOR;
void main ()
{
  mediump vec4 tmpvar_1;
  tmpvar_1 = xlv_COLOR;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
uniform highp mat4 glstate_matrix_projection;
uniform highp float _Outline;
uniform highp vec4 _OutlineColor;
uniform highp float _OutlineOffsetZ;
out highp vec4 xlv_COLOR;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.w = tmpvar_2.w;
  highp mat3 tmpvar_3;
  tmpvar_3[0] = glstate_matrix_invtrans_modelview0[0].xyz;
  tmpvar_3[1] = glstate_matrix_invtrans_modelview0[1].xyz;
  tmpvar_3[2] = glstate_matrix_invtrans_modelview0[2].xyz;
  highp mat2 tmpvar_4;
  tmpvar_4[0] = glstate_matrix_projection[0].xy;
  tmpvar_4[1] = glstate_matrix_projection[1].xy;
  tmpvar_1.xy = (tmpvar_2.xy + ((
    (tmpvar_4 * (tmpvar_3 * normalize(_glesNormal)).xy)
   * tmpvar_2.z) * _Outline));
  tmpvar_1.z = (tmpvar_2.z + _OutlineOffsetZ);
  gl_Position = tmpvar_1;
  xlv_COLOR = _OutlineColor;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
in highp vec4 xlv_COLOR;
void main ()
{
  mediump vec4 tmpvar_1;
  tmpvar_1 = xlv_COLOR;
  _glesFragData[0] = tmpvar_1;
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
  Name "BASE"
  Tags { "QUEUE"="Transparent" }
  ColorMask RGB
  SetTexture [_MainTex] { combine texture }
 }
}
Fallback "Mobile/Unlit (Supports Lightmap)"
}