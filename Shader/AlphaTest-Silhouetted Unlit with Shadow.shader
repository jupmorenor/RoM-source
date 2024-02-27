//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Outlined/Cutout/Silhouetted Unlit with Shadow" {
Properties {
 _OutlineColor ("Outline Color", Color) = (0,0,0,1)
 _Outline ("Outline width", Range(0,0.03)) = 0.005
 _OutlineOffsetZ ("Outline Offset Z", Float) = 0
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  Lighting On
  Cull Off
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

uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
varying highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp float x_1;
  x_1 = (texture2D (_MainTex, xlv_TEXCOORD1).w - _Cutoff);
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
uniform sampler2D _MainTex;
uniform lowp float _Cutoff;
in highp vec2 xlv_TEXCOORD1;
void main ()
{
  lowp float x_1;
  x_1 = (texture (_MainTex, xlv_TEXCOORD1).w - _Cutoff);
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
 UsePass "Outlined/Cutout/Silhouetted Unlit/SILHOUETTED"
 UsePass "Outlined/Cutout/Silhouetted Unlit/BASE"
}
SubShader { 
 LOD 100
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 UsePass "Outlined/Cutout/Silhouetted Unlit/SILHOUETTED"
 UsePass "Outlined/Cutout/Silhouetted Unlit/BASE"
}
SubShader { 
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 UsePass "Outlined/Cutout/Silhouetted Unlit/BASE"
}
Fallback "Mobile/Unlit (Supports Lightmap)"
}