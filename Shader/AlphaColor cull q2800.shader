//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/AlphaColor cull q2800" {
Properties {
 _Color ("Color", Color) = (1,1,1,1)
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
  ZWrite Off
  Fog {
   Color (1,1,1,1)
  }
  Blend SrcAlpha OneMinusSrcAlpha
  SetTexture [_MainTex] { combine texture * primary }
  SetTexture [_MainTex] { ConstantColor [_Color] combine previous * constant }
 }
}
}