//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/AlphaColorDouble cull zwrite q2800" {
Properties {
 _Color ("Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Texture", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent-200" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent-200" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZTest Less
  Fog {
   Color (0.5,0.5,0.5,0.5)
  }
  Blend SrcAlpha OneMinusSrcAlpha
  SetTexture [_MainTex] { combine texture * primary double }
  SetTexture [_MainTex] { ConstantColor [_Color] combine previous * constant double }
 }
}
}