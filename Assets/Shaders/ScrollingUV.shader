Shader "Custom/ScrollingUV" {
	Properties
        {
            _MainTex("Main Texture",2D)="white"{}
            _xRcrollingSpeed("xRcrollingSpeed",float)=1
            _yRcrollingSpeed("yRcrollingSpeed",float)=1
        }
        SubShader
        {
            CGPROGRAM
            #pragma surface surf Lambert
            struct Input
            {
                float2 uv_MainTexture;
            };

            sampler2D _MainTex;
            float _xRcrollingSpeed;
            float _yRcrollingSpeed;

            void surf(Input IN,inout SurfaceOutput o)
            {

                float2 sourceUv = IN.uv_MainTexture;

                float xRcrollingSpeed = _xRcrollingSpeed*_Time.y;
                float yRcrollingSpeed = _yRcrollingSpeed*_Time.y;

                sourceUv += float2(xRcrollingSpeed,yRcrollingSpeed);

                float4 c = tex2D(_MainTex,sourceUv);


                o.Albedo = c.rgb;
                o.Alpha = c.a;

            }

            ENDCG
        }
         FallBack "Diffuse" 
}
