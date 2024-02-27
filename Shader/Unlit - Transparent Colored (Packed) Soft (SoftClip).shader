//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Unlit/Transparent Colored (Packed) Soft (SoftClip)" {
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
uniform mediump vec4 _MainTex_ST;
varying mediump vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
  xlv_TEXCOORD1 = ((_glesVertex.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD2 = normalize(_glesNormal);
}



#endif
#ifdef FRAGMENT

uniform sampler2D _MainTex;
uniform highp vec2 _ClipSharpness;
varying mediump vec4 xlv_COLOR;
varying highp vec2 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec3 xlv_TEXCOORD2;
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
  highp vec2 tmpvar_6;
  tmpvar_6 = ((vec2(1.0, 1.0) - abs(xlv_TEXCOORD1)) * _ClipSharpness);
  if ((xlv_TEXCOORD2.z > 0.0)) {
    highp float tmpvar_7;
    tmpvar_7 = xlv_TEXCOORD2.x;
    highp float tmpvar_8;
    tmpvar_8 = xlv_TEXCOORD2.y;
    highp vec2 tmpvar_9;
    tmpvar_9.x = 0.0;
    tmpvar_9.y = tmpvar_8;
    highp vec2 tmpvar_10;
    tmpvar_10 = clamp ((xlv_TEXCOORD0 + tmpvar_9), 0.0, 1.0);
    lowp vec4 tmpvar_11;
    tmpvar_11 = texture2D (_MainTex, tmpvar_10);
    highp vec2 tmpvar_12;
    tmpvar_12.y = 0.0;
    highp float cse_13;
    cse_13 = -(xlv_TEXCOORD2.x);
    tmpvar_12.x = cse_13;
    highp vec2 tmpvar_14;
    tmpvar_14 = clamp ((xlv_TEXCOORD0 + tmpvar_12), 0.0, 1.0);
    lowp vec4 tmpvar_15;
    tmpvar_15 = texture2D (_MainTex, tmpvar_14);
    highp vec2 tmpvar_16;
    tmpvar_16.y = 0.0;
    tmpvar_16.x = tmpvar_7;
    highp vec2 tmpvar_17;
    tmpvar_17 = clamp ((xlv_TEXCOORD0 + tmpvar_16), 0.0, 1.0);
    lowp vec4 tmpvar_18;
    tmpvar_18 = texture2D (_MainTex, tmpvar_17);
    highp vec2 tmpvar_19;
    tmpvar_19.x = 0.0;
    highp float cse_20;
    cse_20 = -(xlv_TEXCOORD2.y);
    tmpvar_19.y = cse_20;
    highp vec2 tmpvar_21;
    tmpvar_21 = clamp ((xlv_TEXCOORD0 + tmpvar_19), 0.0, 1.0);
    lowp vec4 tmpvar_22;
    tmpvar_22 = texture2D (_MainTex, tmpvar_21);
    highp vec2 tmpvar_23;
    tmpvar_23.x = tmpvar_7;
    tmpvar_23.y = tmpvar_8;
    highp vec2 tmpvar_24;
    tmpvar_24 = clamp ((xlv_TEXCOORD0 + tmpvar_23), 0.0, 1.0);
    lowp vec4 tmpvar_25;
    tmpvar_25 = texture2D (_MainTex, tmpvar_24);
    highp vec2 tmpvar_26;
    tmpvar_26.x = cse_13;
    tmpvar_26.y = tmpvar_8;
    highp vec2 tmpvar_27;
    tmpvar_27 = clamp ((xlv_TEXCOORD0 + tmpvar_26), 0.0, 1.0);
    lowp vec4 tmpvar_28;
    tmpvar_28 = texture2D (_MainTex, tmpvar_27);
    highp vec2 tmpvar_29;
    tmpvar_29 = clamp ((xlv_TEXCOORD0 - xlv_TEXCOORD2.xy), 0.0, 1.0);
    lowp vec4 tmpvar_30;
    tmpvar_30 = texture2D (_MainTex, tmpvar_29);
    highp vec2 tmpvar_31;
    tmpvar_31.x = tmpvar_7;
    tmpvar_31.y = cse_20;
    highp vec2 tmpvar_32;
    tmpvar_32 = clamp ((xlv_TEXCOORD0 + tmpvar_31), 0.0, 1.0);
    lowp vec4 tmpvar_33;
    tmpvar_33 = texture2D (_MainTex, tmpvar_32);
    highp vec4 tmpvar_34;
    tmpvar_34 = (mask_2 + (xlv_TEXCOORD2.z * (
      ((((
        ((tmpvar_11 + tmpvar_15) + tmpvar_18)
       + tmpvar_22) + tmpvar_25) + tmpvar_28) + tmpvar_30)
     + tmpvar_33)));
    mask_2 = tmpvar_34;
  };
  mediump vec4 tmpvar_35;
  tmpvar_35 = (mask_2 * tmpvar_4);
  mask_2 = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = (tmpvar_5.w * clamp (min (tmpvar_6.x, tmpvar_6.y), 0.0, 1.0));
  col_1.w = tmpvar_36;
  col_1.w = (col_1.w * clamp ((
    ((tmpvar_35.x + tmpvar_35.y) + tmpvar_35.z)
   + tmpvar_35.w), 0.0, 1.0));
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
uniform mediump vec4 _MainTex_ST;
out mediump vec4 xlv_COLOR;
out highp vec2 xlv_TEXCOORD0;
out highp vec2 xlv_TEXCOORD1;
out highp vec3 xlv_TEXCOORD2;
void main ()
{
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_COLOR = _glesColor;
  xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
  xlv_TEXCOORD1 = ((_glesVertex.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  xlv_TEXCOORD2 = normalize(_glesNormal);
}



#endif
#ifdef FRAGMENT


layout(location=0) out mediump vec4 _glesFragData[4];
uniform sampler2D _MainTex;
uniform highp vec2 _ClipSharpness;
in mediump vec4 xlv_COLOR;
in highp vec2 xlv_TEXCOORD0;
in highp vec2 xlv_TEXCOORD1;
in highp vec3 xlv_TEXCOORD2;
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
  highp vec2 tmpvar_6;
  tmpvar_6 = ((vec2(1.0, 1.0) - abs(xlv_TEXCOORD1)) * _ClipSharpness);
  if ((xlv_TEXCOORD2.z > 0.0)) {
    highp float tmpvar_7;
    tmpvar_7 = xlv_TEXCOORD2.x;
    highp float tmpvar_8;
    tmpvar_8 = xlv_TEXCOORD2.y;
    highp vec2 tmpvar_9;
    tmpvar_9.x = 0.0;
    tmpvar_9.y = tmpvar_8;
    highp vec2 tmpvar_10;
    tmpvar_10 = clamp ((xlv_TEXCOORD0 + tmpvar_9), 0.0, 1.0);
    lowp vec4 tmpvar_11;
    tmpvar_11 = texture (_MainTex, tmpvar_10);
    highp vec2 tmpvar_12;
    tmpvar_12.y = 0.0;
    highp float cse_13;
    cse_13 = -(xlv_TEXCOORD2.x);
    tmpvar_12.x = cse_13;
    highp vec2 tmpvar_14;
    tmpvar_14 = clamp ((xlv_TEXCOORD0 + tmpvar_12), 0.0, 1.0);
    lowp vec4 tmpvar_15;
    tmpvar_15 = texture (_MainTex, tmpvar_14);
    highp vec2 tmpvar_16;
    tmpvar_16.y = 0.0;
    tmpvar_16.x = tmpvar_7;
    highp vec2 tmpvar_17;
    tmpvar_17 = clamp ((xlv_TEXCOORD0 + tmpvar_16), 0.0, 1.0);
    lowp vec4 tmpvar_18;
    tmpvar_18 = texture (_MainTex, tmpvar_17);
    highp vec2 tmpvar_19;
    tmpvar_19.x = 0.0;
    highp float cse_20;
    cse_20 = -(xlv_TEXCOORD2.y);
    tmpvar_19.y = cse_20;
    highp vec2 tmpvar_21;
    tmpvar_21 = clamp ((xlv_TEXCOORD0 + tmpvar_19), 0.0, 1.0);
    lowp vec4 tmpvar_22;
    tmpvar_22 = texture (_MainTex, tmpvar_21);
    highp vec2 tmpvar_23;
    tmpvar_23.x = tmpvar_7;
    tmpvar_23.y = tmpvar_8;
    highp vec2 tmpvar_24;
    tmpvar_24 = clamp ((xlv_TEXCOORD0 + tmpvar_23), 0.0, 1.0);
    lowp vec4 tmpvar_25;
    tmpvar_25 = texture (_MainTex, tmpvar_24);
    highp vec2 tmpvar_26;
    tmpvar_26.x = cse_13;
    tmpvar_26.y = tmpvar_8;
    highp vec2 tmpvar_27;
    tmpvar_27 = clamp ((xlv_TEXCOORD0 + tmpvar_26), 0.0, 1.0);
    lowp vec4 tmpvar_28;
    tmpvar_28 = texture (_MainTex, tmpvar_27);
    highp vec2 tmpvar_29;
    tmpvar_29 = clamp ((xlv_TEXCOORD0 - xlv_TEXCOORD2.xy), 0.0, 1.0);
    lowp vec4 tmpvar_30;
    tmpvar_30 = texture (_MainTex, tmpvar_29);
    highp vec2 tmpvar_31;
    tmpvar_31.x = tmpvar_7;
    tmpvar_31.y = cse_20;
    highp vec2 tmpvar_32;
    tmpvar_32 = clamp ((xlv_TEXCOORD0 + tmpvar_31), 0.0, 1.0);
    lowp vec4 tmpvar_33;
    tmpvar_33 = texture (_MainTex, tmpvar_32);
    highp vec4 tmpvar_34;
    tmpvar_34 = (mask_2 + (xlv_TEXCOORD2.z * (
      ((((
        ((tmpvar_11 + tmpvar_15) + tmpvar_18)
       + tmpvar_22) + tmpvar_25) + tmpvar_28) + tmpvar_30)
     + tmpvar_33)));
    mask_2 = tmpvar_34;
  };
  mediump vec4 tmpvar_35;
  tmpvar_35 = (mask_2 * tmpvar_4);
  mask_2 = tmpvar_35;
  highp float tmpvar_36;
  tmpvar_36 = (tmpvar_5.w * clamp (min (tmpvar_6.x, tmpvar_6.y), 0.0, 1.0));
  col_1.w = tmpvar_36;
  col_1.w = (col_1.w * clamp ((
    ((tmpvar_35.x + tmpvar_35.y) + tmpvar_35.z)
   + tmpvar_35.w), 0.0, 1.0));
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