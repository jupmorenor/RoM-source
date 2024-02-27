//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Outlined/Silhouetted Unlit with Shadow" {
Properties {
 _OutlineColor ("Outline Color", Color) = (0,0,0,1)
 _Outline ("Outline width", Range(0,0.03)) = 0.005
 _OutlineOffsetZ ("Outline Offset Z", Float) = 0
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Transparent" }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "QUEUE"="Transparent" }
  Lighting On
  ZTest Less
  Cull Off
  Fog { Mode Off }
  ColorMask RGB
  Offset 1, 1
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.xyw = tmpvar_2.xyw;
  tmpvar_1.z = (tmpvar_2.z + unity_LightShadowBias.x);
  tmpvar_1.z = mix (tmpvar_1.z, max (tmpvar_1.z, -(tmpvar_2.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_1;
}



#endif
#ifdef FRAGMENT

void main ()
{
  gl_FragData[0] = vec4(0.0, 0.0, 0.0, 0.0);
}



#endif"
}
SubProgram "gles3 " {
"!!GLES3#version 300 es


#ifdef VERTEX


in vec4 _glesVertex;
uniform highp vec4 unity_LightShadowBias;
uniform highp mat4 glstate_matrix_mvp;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_1.xyw = tmpvar_2.xyw;
  tmpvar_1.z = (tmpvar_2.z + unity_LightShadowBias.x);
  tmpvar_1.z = mix (tmpvar_1.z, max (tmpvar_1.z, -(tmpvar_2.w)), unity_LightShadowBias.y);
  gl_Position = tmpvar_1;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
void main ()
{
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
 UsePass "Outlined/Silhouetted Unlit/SILHOUETTED"
 UsePass "Outlined/Silhouetted Unlit/BASE"
}
SubShader { 
 LOD 100
 Tags { "QUEUE"="Transparent" }
 UsePass "Outlined/Silhouetted Unlit/SILHOUETTED"
 UsePass "Outlined/Silhouetted Unlit/BASE"
}
SubShader { 
 Tags { "QUEUE"="Transparent" }
 UsePass "Outlined/Silhouetted Unlit/BASE"
}
Fallback "Mobile/Unlit (Supports Lightmap)"
}