//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/MobileSh_TrnAdd_NoZtest" {
Properties {
 _MainTex ("Particle Texture", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent+1" "IGNOREPROJECTOR"="true" "RenderType"="Transparent+1" }
 Pass {
  Tags { "QUEUE"="Transparent+1" "IGNOREPROJECTOR"="true" "RenderType"="Transparent+1" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZTest Always
  ZWrite Off
  Cull Off
  Blend SrcAlpha One
  SetTexture [_MainTex] { combine texture * primary }
 }
}
}