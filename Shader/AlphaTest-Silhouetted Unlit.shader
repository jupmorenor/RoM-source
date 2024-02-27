//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Outlined/Cutout/Silhouetted Unlit" {
Properties {
 _OutlineColor ("Outline Color", Color) = (0,0,0,1)
 _Outline ("Outline width", Range(0,0.03)) = 0.005
 _OutlineOffsetZ ("Outline Offset Z", Float) = 0
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 Pass {
  Name "SILHOUETTED"
  Tags { "LIGHTMODE"="Always" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  AlphaToMask On
  ZWrite Off
  Cull Off
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
uniform highp mat4 glstate_matrix_projection;
uniform highp float _Outline;
uniform highp vec4 _OutlineColor;
varying highp vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.zw = tmpvar_2.zw;
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
  gl_Position = tmpvar_1;
  xlv_COLOR = _OutlineColor;
  xlv_TEXCOORD1 = _glesMultiTexCoord0.xy;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 tmpvar_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  highp vec4 tmpvar_4;
  tmpvar_4.xyz = xlv_COLOR.xyz;
  tmpvar_4.w = tmpvar_2.w;
  tmpvar_1 = tmpvar_4;
  gl_FragData[0] = tmpvar_1;
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec3 _glesNormal;
in vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
uniform highp mat4 glstate_matrix_projection;
uniform highp float _Outline;
uniform highp vec4 _OutlineColor;
out highp vec4 xlv_COLOR;
out highp vec2 xlv_TEXCOORD1;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.zw = tmpvar_2.zw;
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
  gl_Position = tmpvar_1;
  xlv_COLOR = _OutlineColor;
  xlv_TEXCOORD1 = _glesMultiTexCoord0.xy;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec4 xlv_COLOR;
in highp vec2 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 tmpvar_1;
  lowp vec4 tmpvar_2;
  tmpvar_2 = texture (_MainTex, xlv_TEXCOORD1);
  lowp float x_3;
  x_3 = (tmpvar_2.w - _Cutoff);
  if ((x_3 < 0.0)) {
    discard;
  };
  highp vec4 tmpvar_4;
  tmpvar_4.xyz = xlv_COLOR.xyz;
  tmpvar_4.w = tmpvar_2.w;
  tmpvar_1 = tmpvar_4;
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
  Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  AlphaToMask On
  Cull Off
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
  SetTexture [_MainTex] { combine texture }
 }
}
Fallback "Mobile/Unlit (Supports Lightmap)"
}