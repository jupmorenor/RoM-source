//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Unlit/Transparent Colored (Packed) Soft" {
Properties {
 _MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
  Offset -1, -1
Program "vp" {
SubProgram "gles " {
"!!GLES


#ifdef VERTEX

attribute vec4 _glesVertex;
attribute vec4 _glesColor;
attribute vec3 _glesNormal;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
varying mediump vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
  xlv_TEXCOORD1 = normalize(_glesNormal);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
varying mediump vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 col_1;
  mediump vec4 mask_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2D (_MainTex, xlv_TEXCOORD0);
  mask_2 = tmpvar_3;
  mediump vec4 tmpvar_4;
  tmpvar_4 = clamp (ceil((xlv_COLOR - 0.5)), 0.0, 1.0);
  mediump vec4 tmpvar_5;
  tmpvar_5 = clamp (((
    (tmpvar_4 * 0.51)
   - xlv_COLOR) / -0.49), 0.0, 1.0);
  col_1 = tmpvar_5;
  if ((xlv_TEXCOORD1.z > 0.0)) {
    highp float tmpvar_6;
    tmpvar_6 = xlv_TEXCOORD1.x;
    highp float tmpvar_7;
    tmpvar_7 = xlv_TEXCOORD1.y;
    highp vec2 tmpvar_8;
    tmpvar_8.x = 0.0;
    tmpvar_8.y = tmpvar_7;
    highp vec2 tmpvar_9;
    tmpvar_9 = clamp ((xlv_TEXCOORD0 + tmpvar_8), 0.0, 1.0);
    lowp vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, tmpvar_9);
    highp vec2 tmpvar_11;
    tmpvar_11.y = 0.0;
    highp float cse_12;
    cse_12 = -(xlv_TEXCOORD1.x);
    tmpvar_11.x = cse_12;
    highp vec2 tmpvar_13;
    tmpvar_13 = clamp ((xlv_TEXCOORD0 + tmpvar_11), 0.0, 1.0);
    lowp vec4 tmpvar_14;
    tmpvar_14 = texture2D (_MainTex, tmpvar_13);
    highp vec2 tmpvar_15;
    tmpvar_15.y = 0.0;
    tmpvar_15.x = tmpvar_6;
    highp vec2 tmpvar_16;
    tmpvar_16 = clamp ((xlv_TEXCOORD0 + tmpvar_15), 0.0, 1.0);
    lowp vec4 tmpvar_17;
    tmpvar_17 = texture2D (_MainTex, tmpvar_16);
    highp vec2 tmpvar_18;
    tmpvar_18.x = 0.0;
    highp float cse_19;
    cse_19 = -(xlv_TEXCOORD1.y);
    tmpvar_18.y = cse_19;
    highp vec2 tmpvar_20;
    tmpvar_20 = clamp ((xlv_TEXCOORD0 + tmpvar_18), 0.0, 1.0);
    lowp vec4 tmpvar_21;
    tmpvar_21 = texture2D (_MainTex, tmpvar_20);
    highp vec2 tmpvar_22;
    tmpvar_22.x = tmpvar_6;
    tmpvar_22.y = tmpvar_7;
    highp vec2 tmpvar_23;
    tmpvar_23 = clamp ((xlv_TEXCOORD0 + tmpvar_22), 0.0, 1.0);
    lowp vec4 tmpvar_24;
    tmpvar_24 = texture2D (_MainTex, tmpvar_23);
    highp vec2 tmpvar_25;
    tmpvar_25.x = cse_12;
    tmpvar_25.y = tmpvar_7;
    highp vec2 tmpvar_26;
    tmpvar_26 = clamp ((xlv_TEXCOORD0 + tmpvar_25), 0.0, 1.0);
    lowp vec4 tmpvar_27;
    tmpvar_27 = texture2D (_MainTex, tmpvar_26);
    highp vec2 tmpvar_28;
    tmpvar_28 = clamp ((xlv_TEXCOORD0 - xlv_TEXCOORD1.xy), 0.0, 1.0);
    lowp vec4 tmpvar_29;
    tmpvar_29 = texture2D (_MainTex, tmpvar_28);
    highp vec2 tmpvar_30;
    tmpvar_30.x = tmpvar_6;
    tmpvar_30.y = cse_19;
    highp vec2 tmpvar_31;
    tmpvar_31 = clamp ((xlv_TEXCOORD0 + tmpvar_30), 0.0, 1.0);
    lowp vec4 tmpvar_32;
    tmpvar_32 = texture2D (_MainTex, tmpvar_31);
    highp vec4 tmpvar_33;
    tmpvar_33 = (mask_2 + (xlv_TEXCOORD1.z * (
      ((((
        ((tmpvar_10 + tmpvar_14) + tmpvar_17)
       + tmpvar_21) + tmpvar_24) + tmpvar_27) + tmpvar_29)
     + tmpvar_32)));
    mask_2 = tmpvar_33;
  };
  mediump vec4 tmpvar_34;
  tmpvar_34 = (mask_2 * tmpvar_4);
  mask_2 = tmpvar_34;
  col_1.w = (tmpvar_5.w * clamp ((
    ((tmpvar_34.x + tmpvar_34.y) + tmpvar_34.z)
   + tmpvar_34.w), 0.0, 1.0));
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
uniform highp mat4 glstate_matrix_mvp;
out mediump vec4 xlv_COLOR;
out highp vec2 xlv_TEXCOORD0;
out highp vec3 xlv_TEXCOORD1;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
  xlv_TEXCOORD1 = normalize(_glesNormal);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
in mediump vec4 xlv_COLOR;
in highp vec2 xlv_TEXCOORD0;
in highp vec3 xlv_TEXCOORD1;
void main ()
{
  mediump vec4 col_1;
  mediump vec4 mask_2;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture (_MainTex, xlv_TEXCOORD0);
  mask_2 = tmpvar_3;
  mediump vec4 tmpvar_4;
  tmpvar_4 = clamp (ceil((xlv_COLOR - 0.5)), 0.0, 1.0);
  mediump vec4 tmpvar_5;
  tmpvar_5 = clamp (((
    (tmpvar_4 * 0.51)
   - xlv_COLOR) / -0.49), 0.0, 1.0);
  col_1 = tmpvar_5;
  if ((xlv_TEXCOORD1.z > 0.0)) {
    highp float tmpvar_6;
    tmpvar_6 = xlv_TEXCOORD1.x;
    highp float tmpvar_7;
    tmpvar_7 = xlv_TEXCOORD1.y;
    highp vec2 tmpvar_8;
    tmpvar_8.x = 0.0;
    tmpvar_8.y = tmpvar_7;
    highp vec2 tmpvar_9;
    tmpvar_9 = clamp ((xlv_TEXCOORD0 + tmpvar_8), 0.0, 1.0);
    lowp vec4 tmpvar_10;
    tmpvar_10 = texture (_MainTex, tmpvar_9);
    highp vec2 tmpvar_11;
    tmpvar_11.y = 0.0;
    highp float cse_12;
    cse_12 = -(xlv_TEXCOORD1.x);
    tmpvar_11.x = cse_12;
    highp vec2 tmpvar_13;
    tmpvar_13 = clamp ((xlv_TEXCOORD0 + tmpvar_11), 0.0, 1.0);
    lowp vec4 tmpvar_14;
    tmpvar_14 = texture (_MainTex, tmpvar_13);
    highp vec2 tmpvar_15;
    tmpvar_15.y = 0.0;
    tmpvar_15.x = tmpvar_6;
    highp vec2 tmpvar_16;
    tmpvar_16 = clamp ((xlv_TEXCOORD0 + tmpvar_15), 0.0, 1.0);
    lowp vec4 tmpvar_17;
    tmpvar_17 = texture (_MainTex, tmpvar_16);
    highp vec2 tmpvar_18;
    tmpvar_18.x = 0.0;
    highp float cse_19;
    cse_19 = -(xlv_TEXCOORD1.y);
    tmpvar_18.y = cse_19;
    highp vec2 tmpvar_20;
    tmpvar_20 = clamp ((xlv_TEXCOORD0 + tmpvar_18), 0.0, 1.0);
    lowp vec4 tmpvar_21;
    tmpvar_21 = texture (_MainTex, tmpvar_20);
    highp vec2 tmpvar_22;
    tmpvar_22.x = tmpvar_6;
    tmpvar_22.y = tmpvar_7;
    highp vec2 tmpvar_23;
    tmpvar_23 = clamp ((xlv_TEXCOORD0 + tmpvar_22), 0.0, 1.0);
    lowp vec4 tmpvar_24;
    tmpvar_24 = texture (_MainTex, tmpvar_23);
    highp vec2 tmpvar_25;
    tmpvar_25.x = cse_12;
    tmpvar_25.y = tmpvar_7;
    highp vec2 tmpvar_26;
    tmpvar_26 = clamp ((xlv_TEXCOORD0 + tmpvar_25), 0.0, 1.0);
    lowp vec4 tmpvar_27;
    tmpvar_27 = texture (_MainTex, tmpvar_26);
    highp vec2 tmpvar_28;
    tmpvar_28 = clamp ((xlv_TEXCOORD0 - xlv_TEXCOORD1.xy), 0.0, 1.0);
    lowp vec4 tmpvar_29;
    tmpvar_29 = texture (_MainTex, tmpvar_28);
    highp vec2 tmpvar_30;
    tmpvar_30.x = tmpvar_6;
    tmpvar_30.y = cse_19;
    highp vec2 tmpvar_31;
    tmpvar_31 = clamp ((xlv_TEXCOORD0 + tmpvar_30), 0.0, 1.0);
    lowp vec4 tmpvar_32;
    tmpvar_32 = texture (_MainTex, tmpvar_31);
    highp vec4 tmpvar_33;
    tmpvar_33 = (mask_2 + (xlv_TEXCOORD1.z * (
      ((((
        ((tmpvar_10 + tmpvar_14) + tmpvar_17)
       + tmpvar_21) + tmpvar_24) + tmpvar_27) + tmpvar_29)
     + tmpvar_32)));
    mask_2 = tmpvar_33;
  };
  mediump vec4 tmpvar_34;
  tmpvar_34 = (mask_2 * tmpvar_4);
  mask_2 = tmpvar_34;
  col_1.w = (tmpvar_5.w * clamp ((
    ((tmpvar_34.x + tmpvar_34.y) + tmpvar_34.z)
   + tmpvar_34.w), 0.0, 1.0));
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