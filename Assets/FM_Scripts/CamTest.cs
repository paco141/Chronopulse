using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamTest : MonoBehaviour {
	public float angle;

	// will lerp the camera to follow this point;
	/*
	 * adjust cam follow speed
	 * adjust angle of cam 
	 */
	public GameObject moveObject;


	public float T;
	public int J;
	private float a;
	private float b;
	private float c;
	private bool stop = false;
	public float rate = 50;
	public float ang1 =90;
	public float ang2 =95;
	public Transform A;// player
	public Transform B;// R object
	public Transform C;// moveobject CamCurve

	List<GameObject> controlPoints = new List<GameObject>();

	

	void Start(){
		foreach(Transform child in transform){
			controlPoints.Add(child.gameObject);
		}
		T=1;

	}


	void Update() {
		triangleCalc();
		moveCam();
		//print(T);
	
	

		//moveObject.transform.LookAt(target.transform.position);
		//	print(angle  * Mathf.Rad2Deg);
				
	}




	void moveCam(){

//		print(angle);
		//I thethered the camera by what angle it is from the player by the angle
		// of a triangle. used the (the player, R object, the point moving on this curve.


		if (angle  < ang1 && !stop)
			T += 0.05f *Time.deltaTime*rate;

		else if (angle >ang2 && !stop)
			T -= 0.05f *Time.deltaTime*rate;
	
		if(T < -0.1f)
		{
			T= 0;
		}
	
		

		if(J < controlPoints.Count-2){
			
			Vector3 p0 = 0.5f * (controlPoints[J].transform.position 
			                     + controlPoints[J + 1].transform.position);
			Vector3 p1 = controlPoints[J + 1].transform.position;
			Vector3 p2 = 0.5f * (controlPoints[J + 1].transform.position 
			                     + controlPoints[J + 2].transform.position);
			
			
			
			moveObject.transform.position = Curve.BCurve(p0,p1,p2,T);
			
	
			if (T > 1){
				J++;
				T=0;
			}
			else if (T < 0 )
			{
				if(J !=0){
					J--;
					T=1;
				}
			}

			
		}

		
		
	}


	float AngleOfTriangle(float a, float b, float c)
	{
		float cAng = (a*a+b*b- c*c)/(2*a*b);
		float rad = Mathf.Acos(cAng);
		return Mathf.Rad2Deg *rad;
	}

	void triangleCalc()
	{
		Vector3 aZX = new Vector3(A.position.x,0,A.position.z);
		Vector3 bZX = new Vector3(B.position.x,0 , B.position.z);
		Vector3 cZX = new Vector3(C.position.x,0, C.position.z);
		float a = Vector3.Distance(aZX,bZX);
		float b = Vector3.Distance(bZX,cZX);
		float c = Vector3.Distance(cZX,aZX);
		angle =  AngleOfTriangle(a,b,c);
		

	}
	public void pause ( bool _pause)
	{
			stop = _pause;
	}



}
