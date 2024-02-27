//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/Nature/Tree Soft Occlusion Bark Rendertex" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,0)
 _MainTex ("Main Texture", 2D) = "white" {}
 _BaseLight ("Base Light", Range(0,1)) = 0.35
 _AO ("Amb. Occlusion", Range(0,10)) = 2.4
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
}
SubShader { 
 Pass {
  Lighting On
  Fog { Mode Off }
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
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp vec4 _Scale;
uniform highp mat4 _TerrainEngineBendTree;
uniform highp vec4 _SquashPlaneNormal;
uniform highp float _SquashAmount;
uniform highp float _AO;
uniform highp float _BaseLight;
uniform lowp vec4 _Color;
uniform highp vec3 _TerrainTreeLightDirections[4];
uniform highp vec4 _TerrainTreeLightColors[4];
varying highp vec4 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 light_2;
  highp vec4 lightDir_3;
  lowp vec4 tmpvar_4;
  highp vec4 pos_5;
  pos_5.w = _glesVertex.w;
  highp float alpha_6;
  alpha_6 = tmpvar_1.w;
  pos_5.xyz = (_glesVertex.xyz * _Scale.xyz);
  highp vec4 tmpvar_7;
  tmpvar_7.w = 0.0;
  tmpvar_7.xyz = pos_5.xyz;
  pos_5.xyz = mix (pos_5.xyz, (_TerrainEngineBendTree * tmpvar_7).xyz, vec3(alpha_6));
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = mix ((pos_5.xyz - (
    (dot (_SquashPlaneNormal.xyz, pos_5.xyz) + _SquashPlaneNormal.w)
   * _SquashPlaneNormal.xyz)), pos_5.xyz, vec3(_SquashAmount));
  pos_5 = tmpvar_8;
  lightDir_3.w = _AO;
  lightDir_3.xyz = _TerrainTreeLightDirections[0];
  highp float cse_9;
  cse_9 = (_AO * _glesTANGENT.w);
  light_2 = (glstate_lightmodel_ambient + (_TerrainTreeLightColors[0] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[1];
  light_2 = (light_2 + (_TerrainTreeLightColors[1] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[2];
  light_2 = (light_2 + (_TerrainTreeLightColors[2] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[3];
  light_2.xyz = (light_2 + (_TerrainTreeLightColors[3] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  ))).xyz;
  light_2.w = 1.0;
  highp vec4 tmpvar_10;
  tmpvar_10 = (light_2 * _Color);
  tmpvar_4.xyz = tmpvar_10.xyz;
  tmpvar_4.w = 1.0;
  gl_Position = (glstate_matrix_mvp * tmpvar_8);
  xlv_TEXCOORD0 = _glesMultiTexCoord0;
  xlv_COLOR0 = tmpvar_4;
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
varying highp vec4 xlv_TEXCOORD0;
varying lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 col_1;
  col_1.w = xlv_COLOR0.w;
  col_1.xyz = (xlv_COLOR0.xyz * (2.0 * texture2D (_MainTex, xlv_TEXCOORD0.xy).xyz));
  gl_FragData[0] = col_1;
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
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp vec4 _Scale;
uniform highp mat4 _TerrainEngineBendTree;
uniform highp vec4 _SquashPlaneNormal;
uniform highp float _SquashAmount;
uniform highp float _AO;
uniform highp float _BaseLight;
uniform lowp vec4 _Color;
uniform highp vec3 _TerrainTreeLightDirections[4];
uniform highp vec4 _TerrainTreeLightColors[4];
out highp vec4 xlv_TEXCOORD0;
out lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 tmpvar_1;
  tmpvar_1 = _glesColor;
  highp vec4 light_2;
  highp vec4 lightDir_3;
  lowp vec4 tmpvar_4;
  highp vec4 pos_5;
  pos_5.w = _glesVertex.w;
  highp float alpha_6;
  alpha_6 = tmpvar_1.w;
  pos_5.xyz = (_glesVertex.xyz * _Scale.xyz);
  highp vec4 tmpvar_7;
  tmpvar_7.w = 0.0;
  tmpvar_7.xyz = pos_5.xyz;
  pos_5.xyz = mix (pos_5.xyz, (_TerrainEngineBendTree * tmpvar_7).xyz, vec3(alpha_6));
  highp vec4 tmpvar_8;
  tmpvar_8.w = 1.0;
  tmpvar_8.xyz = mix ((pos_5.xyz - (
    (dot (_SquashPlaneNormal.xyz, pos_5.xyz) + _SquashPlaneNormal.w)
   * _SquashPlaneNormal.xyz)), pos_5.xyz, vec3(_SquashAmount));
  pos_5 = tmpvar_8;
  lightDir_3.w = _AO;
  lightDir_3.xyz = _TerrainTreeLightDirections[0];
  highp float cse_9;
  cse_9 = (_AO * _glesTANGENT.w);
  light_2 = (glstate_lightmodel_ambient + (_TerrainTreeLightColors[0] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[1];
  light_2 = (light_2 + (_TerrainTreeLightColors[1] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[2];
  light_2 = (light_2 + (_TerrainTreeLightColors[2] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  )));
  lightDir_3.xyz = _TerrainTreeLightDirections[3];
  light_2.xyz = (light_2 + (_TerrainTreeLightColors[3] * (
    max (0.0, dot (_glesNormal, lightDir_3.xyz))
   * 
    (cse_9 + _BaseLight)
  ))).xyz;
  light_2.w = 1.0;
  highp vec4 tmpvar_10;
  tmpvar_10 = (light_2 * _Color);
  tmpvar_4.xyz = tmpvar_10.xyz;
  tmpvar_4.w = 1.0;
  gl_Position = (glstate_matrix_mvp * tmpvar_8);
  xlv_TEXCOORD0 = _glesMultiTexCoord0;
  xlv_COLOR0 = tmpvar_4;
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
in highp vec4 xlv_TEXCOORD0;
in lowp vec4 xlv_COLOR0;
void main ()
{
  lowp vec4 col_1;
  col_1.w = xlv_COLOR0.w;
  col_1.xyz = (xlv_COLOR0.xyz * (2.0 * texture (_MainTex, xlv_TEXCOORD0.xy).xyz));
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