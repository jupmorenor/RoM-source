//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/Multiply ztoff q2800" {
Properties {
 _MainTex ("Particle Texture", 2D) = "white" {}
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
  ZTest False
  ZWrite Off
  Cull Off
  Fog {
   Color (1,1,1,1)
  }
  Blend Zero SrcColor
  SetTexture [_MainTex] { combine texture * primary }
  SetTexture [_MainTex] { ConstantColor (1,1,1,1) combine previous lerp(previous) constant }
 }
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
  ZTest False
  ZWrite Off
  Cull Off
  Fog {
   Color (1,1,1,1)
  }
  Blend Zero SrcColor
  SetTexture [_MainTex] { ConstantColor (1,1,1,1) combine texture lerp(texture) constant }
 }
}
}