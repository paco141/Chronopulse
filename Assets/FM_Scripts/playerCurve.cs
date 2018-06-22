using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class playerCurve : MonoBehaviour {

	public GameObject L_ObjectFollow;
	public GameObject R_ObjectFollow;


	public float distRange=1;
	public float rate = 8;

	private int J1;// j= array value
	private int J2;
	private float T1;
	private float T2;
	private float dist1;//dist of L from player
	private float dist2;//dist of R from player
 	private float dist3;//dist of R from L 



	List<GameObject> controlPoints= new List<GameObject>();
	// Use this for initialization
	void Start () {

		foreach(Transform child in transform){
			
		controlPoints.Add(child.gameObject);
		}
		// need to modify so the points automatically set up
		T1 = 0.2f;
		T2= 1f;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Dist1:" + dist1 + " Dist2:" + dist2);

		playerMove();

	}
	// the points that are need for the  Bezier curve and they adjust 
	//  along the array
	Vector3 p0(int J) {
		return	0.5f * (controlPoints[J].transform.position 
		               + controlPoints[J + 1].transform.position);
	}
	Vector3 p1(int J){
		
		return controlPoints[J + 1].transform.position;
		
	}
	Vector3 p2(int J){
		return 0.5f * (controlPoints[J + 1].transform.position 
		               + controlPoints[J + 2].transform.position);
	}



	void playerMove(){

		
		#region Keep a fixed distance away from Player
		//print(T2);
		 
		Vector3 playerZX = new Vector3(Controller.Player.transform.position.x, 0 ,
		                               Controller.Player.transform.position.z);
		Vector3 L_ObjectFollowZX = new Vector3(L_ObjectFollow.transform.position.x,0,
		                                     L_ObjectFollow.transform.position.z);
		Vector3 R_ObjectFolloZX = new Vector3(R_ObjectFollow.transform.position.x,0,
		                                      R_ObjectFollow.transform.position.z);


		dist2 = Vector3.Distance(playerZX,R_ObjectFolloZX);


		dist1 = Vector3.Distance(playerZX,L_ObjectFollowZX);

		dist3 = Vector3.Distance(R_ObjectFollow.transform.position,
		                         L_ObjectFollow.transform.position);
		//print(dist2);
		


		if(dist2 < distRange)
			T2+=0.05f* Time.deltaTime * rate;
		
		else if(dist2 > distRange+2)
			T2-=0.05f* Time.deltaTime * rate;

		if(dist1 < distRange)
			T1-=0.05f* Time.deltaTime * rate;

		else if (dist3 < distRange + 3)
			T1-=0.05f* Time.deltaTime * rate;

		else if(dist1 > distRange+2)
			T1+=0.05f* Time.deltaTime * rate;

		
		#endregion
	
		#region Move the object along the curve to the next array of points
		// there are 2 if statments so that each object 
		// adjust it self on which array they are on
		if(J1 < controlPoints.Count-2){
			L_ObjectFollow.transform.position = Curve.BCurve(p0(J1),p1(J1),p2(J1),T1);
			if (T1 > 1){
				J1++;
				T1=0;
			}
			else if (T1 < 0 )
			{
				if(J1 !=0){
				J1--;
				T1=1;
				}
			}
		}

		if(J2 < controlPoints.Count-2){
			R_ObjectFollow.transform.position = Curve.BCurve(p0(J2),p1(J2),p2(J2),T2);
			if (T2 > 1){
				J2++;
				T2=0;
			}
			else if (T2 < 0 )
			{
				if(J2 !=0){
				J2--;
				T2=1;
				}
			}
		}
		#endregion
		
		
		
	}


	void resetFlollowObjectPostion(){
	
	}
}
