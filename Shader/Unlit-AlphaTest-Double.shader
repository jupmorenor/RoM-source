//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Unlit/Transparent Cutout/Double-Sided" {
Properties {
 _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 LOD 100
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 Pass {
  Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  Cull Off
  AlphaTest Greater [_Cutoff]
  SetTexture [_MainTex] { combine texture }
 }
}
}