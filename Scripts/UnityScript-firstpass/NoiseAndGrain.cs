using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Noise And Grain (Overlay)")]
public class NoiseAndGrain : PostEffectsBase
{
	public float strength;

	public float blackIntensity;

	public float whiteIntensity;

	public float redChannelNoise;

	public float greenChannelNoise;

	public float blueChannelNoise;

	public float redChannelTiling;

	public float greenChannelTiling;

	public float blueChannelTiling;

	public FilterMode filterMode;

	public Shader noiseShader;

	public Texture2D noiseTexture;

	private Material noiseMaterial;

	public NoiseAndGrain()
	{
		strength = 1f;
		blackIntensity = 1f;
		whiteIntensity = 1f;
		redChannelNoise = 0.975f;
		greenChannelNoise = 0.875f;
		blueChannelNoise = 1.2f;
		redChannelTiling = 24f;
		greenChannelTiling = 28f;
		blueChannelTiling = 34f;
		filterMode = FilterMode.Bilinear;
	}

	public override bool CheckResources()
	{
		CheckSupport(needDepth: false);
		noiseMaterial = CheckShaderAndCreateMaterial(noiseShader, noiseMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		noiseMaterial.SetVector("_NoisePerChannel", new Vector3(redChannelNoise, greenChannelNoise, blueChannelNoise));
		noiseMaterial.SetVector("_NoiseTilingPerChannel", new Vector3(redChannelTiling, greenChannelTiling, blueChannelTiling));
		noiseMaterial.SetVector("_NoiseAmount", new Vector3(strength, blackIntensity, whiteIntensity));
		noiseMaterial.SetTexture("_NoiseTex", noiseTexture);
		noiseTexture.filterMode = filterMode;
		DrawNoiseQuadGrid(source, destination, noiseMaterial, noiseTexture, 0);
	}

	public static void DrawNoiseQuadGrid(RenderTexture source, RenderTexture dest, Material fxMaterial, Texture2D noise, int passNr)
	{
		RenderTexture.active = dest;
		float num = (float)noise.width * 1f;
		float num2 = num;
		float num3 = 1f * (float)source.width / num2;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		float num4 = 1f * (float)source.width / (1f * (float)source.height);
		float num5 = 1f / num3;
		float num6 = num5 * num4;
		float num7 = num2 / ((float)noise.width * 1f);
		fxMaterial.SetPass(passNr);
		GL.Begin(7);
		for (float num8 = 0f; num8 < 1f; num8 += num5)
		{
			for (float num9 = 0f; num9 < 1f; num9 += num6)
			{
				float num10 = UnityEngine.Random.Range(0f, 1f);
				float num11 = UnityEngine.Random.Range(0f, 1f);
				num10 = Mathf.Floor(num10 * num) / num;
				num11 = Mathf.Floor(num11 * num) / num;
				float num12 = 1f / num;
				GL.MultiTexCoord2(0, num10, num11);
				GL.MultiTexCoord2(1, 0f, 0f);
				GL.Vertex3(num8, num9, 0.1f);
				GL.MultiTexCoord2(0, num10 + num7 * num12, num11);
				GL.MultiTexCoord2(1, 1f, 0f);
				GL.Vertex3(num8 + num5, num9, 0.1f);
				GL.MultiTexCoord2(0, num10 + num7 * num12, num11 + num7 * num12);
				GL.MultiTexCoord2(1, 1f, 1f);
				GL.Vertex3(num8 + num5, num9 + num6, 0.1f);
				GL.MultiTexCoord2(0, num10, num11 + num7 * num12);
				GL.MultiTexCoord2(1, 0f, 1f);
				GL.Vertex3(num8, num9 + num6, 0.1f);
			}
		}
		GL.End();
		GL.PopMatrix();
	}

	public override void Main()
	{
	}
}
