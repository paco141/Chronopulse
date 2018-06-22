  Shader "Example/glow" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _Color1 ("Color 1", Color) = (1.0, 0.6, 0.6, 1.0)
      _Color2("Color 2", Color) =  (1,1,1,1)
       _ColorCull("Color Cull", Color) =  (1,1,1,1)
       _Amount ("Extrusion Amount", Range(0,1)) = 0.0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      
     
    
    
      CGPROGRAM
      #pragma surface surf Lambert finalcolor:mycolor vertex:vert
      
      
      
      struct Input {
          float2 uv_MainTex;
      };
      float _Amount;
      fixed4 _Color1;
       fixed4 _Color2;
      void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)
      {
          color = lerp(_Color1,_Color2, sin(_Amount *_Time ));
      }
      
       
       float _Start;
       float _End ;
        
      void vert (inout appdata_full v) {
      _Start= 0.1;
       _End =0.2;
        
      	
         v.vertex.xyz += v.normal * lerp(_Start,_End,sin(_Amount *_Time * 20));
      }
      
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
      
      
        
    }
    
 
     
    
    
    Fallback "Diffuse"
  }