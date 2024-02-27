//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Debug/Lines" {
SubShader { 
 Pass {
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
  }
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
 }
}
}