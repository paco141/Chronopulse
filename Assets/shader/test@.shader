Shader "Glass Reflective" {
	Properties {
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_Gloss ("Gloss LEVEl", range(0.01, 2)) = 1
		
		_ReflectColor ("Reflection Color", Color) = (1,1,1,1)
		_Cube ("Reflection Cubemap", Cube) = "black" { TexGen CubeReflect }
	}
	SubShader {
		Tags {
			"Queue"="Transparent"
			//"IgnoreProjector"="True"
			"RenderType"="Transparent"
		}
		   ZWrite on
		   Blend SrcAlpha OneMinusSrcAlpha
		   //Zwrite on
		CGPROGRAM
			#pragma surface surf BlinnPhong 
			
			samplerCUBE _Cube;
			
			fixed4 _ReflectColor;
			half _Shininess;
			half _Gloss;
			half _Albeo;
			
			struct Input {
				float3 worldRefl;
			};
			
			void surf (Input IN, inout SurfaceOutput o) {
				o.Albedo = 0;
				o.Gloss = _Gloss;
				o.Specular = _Shininess;
				
				fixed4 reflcol = texCUBE (_Cube, IN.worldRefl);
				o.Emission = reflcol.rgb * _ReflectColor.rgb;
				o.Alpha = reflcol.a * _ReflectColor.a  ;
			}
		ENDCG
	}
	FallBack "Transparent/VertexLit"
}