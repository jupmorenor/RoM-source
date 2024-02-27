//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/Additive cull zwrite q2900" {
Properties {
 _MainTex ("Particle Texture", 2D) = "black" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent-100" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent-100" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZTest Less
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  SetTexture [_MainTex] { combine texture * primary }
 }
}
}