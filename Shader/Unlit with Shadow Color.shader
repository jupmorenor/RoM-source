//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/Cutout/Unlit with Shadow Color" {
Properties {
 _EnableShadow ("Enable Shadow", Float) = 1
 _Color ("Light Color (Unlit = rgb 0.5)", Color) = (0.5,0.5,0.5,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Geometry" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
 Pass {
  Tags { "QUEUE"="Geometry" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
  ColorMask RGB
  SetTexture [_MainTex] { ConstantColor [_Color] combine texture * constant double }
 }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "QUEUE"="Geometry" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
  Lighting On
  Fog { Mode Off }
  ColorMask RGB
  Offset 1, 1
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.xyw = tmpvar_2.xyw;
  tmpvar_1.z = (tmpvar_2.z + unity_LightShadowBias.x);
  tmpvar_1.z = mix (tmpvar_1.z, max (tmpvar_1.z, -(tmpvar_2.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_1;
  xlv_TEXCOORD1 = _glesMultiTexCoord0.xy;
}



#endif
#ifdef FRAGMENT

uniform highp float _EnableShadow;
void main ()
{
  highp float x_1;
  x_1 = (_EnableShadow - 1.0);
  if ((x_1 < 0.0)) {
    discard;
  };
  gl_FragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
in vec4 _glesMultiTexCoord0;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
out highp vec2 xlv_TEXCOORD1;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.xyw = tmpvar_2.xyw;
  tmpvar_1.z = (tmpvar_2.z + unity_LightShadowBias.x);
  tmpvar_1.z = mix (tmpvar_1.z, max (tmpvar_1.z, -(tmpvar_2.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_1;
  xlv_TEXCOORD1 = _glesMultiTexCoord0.xy;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform highp float _EnableShadow;
void main ()
{
  highp float x_1;
  x_1 = (_EnableShadow - 1.0);
  if ((x_1 < 0.0)) {
    discard;
  };
  _glesFragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
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
}