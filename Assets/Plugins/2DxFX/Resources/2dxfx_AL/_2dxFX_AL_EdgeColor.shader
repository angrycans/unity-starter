﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/AL/EdgeColor"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Distortion("Distortion", Range(0,1)) = 0
		_Alpha("Alpha", Range(0,1)) = 1.0
		_Color("_Color", Color) = (1,1,1,1)
		_ColorX("Tint", Color) = (1,1,1,1)
		[HideInInspector]_SrcBlend("_SrcBlend", Float) = 0
		[HideInInspector]_DstBlend("_DstBlend", Float) = 0
		[HideInInspector]_BlendOp("_BlendOp",Float) = 0
		[HideInInspector]_Z("_Z", Float) = 0
	}

		SubShader
	{
		Tags
	{
		"IgnoreProjector" = "True"
		"RenderType" = "TransparentCutout"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}
		Cull Off
		Lighting Off
		ZWrite[_Z]
		BlendOp[_BlendOp]
		Blend[_SrcBlend][_DstBlend]

		CGPROGRAM
#pragma surface surf Lambert vertex:vert nofog keepalpha addshadow fullforwardshadows


		sampler2D _MainTex;
	float _Distortion;
	float4 _ColorX;
	float _Alpha;

	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
		v.vertex = UnityPixelSnap(v.vertex);
		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color;
	}
	float4 getPixel(in int x, in int y, float2 uv)
	{
		return tex2D(_MainTex, (uv + float2(x, y) / 64.0));
	}
	void surf(Input IN, inout SurfaceOutput o)
	{
		float2  uv = IN.uv_MainTex;


		fixed4 sum = abs(getPixel(0, 1, uv) - getPixel(0, -1, uv));
		sum += abs(getPixel(1, 0, uv) - getPixel(-1, 0, uv));
		sum /= 2.0;
		fixed4 color = getPixel(0, 0, uv)*IN.color;
		color += length(sum) * _ColorX;
		color.a = color.a*(1 - _Alpha);



		o.Albedo = color.rgb * color.a;
		o.Alpha = color.a;

		clip(o.Alpha - 0.05);
	}
	ENDCG
	}

		Fallback "Transparent/VertexLit"
}