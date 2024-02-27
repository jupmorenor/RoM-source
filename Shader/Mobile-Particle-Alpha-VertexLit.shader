//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Mobile/Particles/VertexLit Blended" {
Properties {
 _EmisColor ("Emissive Color", Color) = (0.2,0.2,0.2,0)
 _MainTex ("Particle Texture", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  Lighting On
  Material {
   Emission [_EmisColor]
  }
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMaterial AmbientAndDiffuse
  SetTexture [_MainTex] { combine texture * primary }
 }
}
}