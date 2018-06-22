using UnityEngine;
using System.Collections;

public class PlatformParen : MonoBehaviour {
	public GameObject 	Player;
	Vector3 diffVector;
	bool attached;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		adjustment();
	if(attached)
		{
			Player.transform.position += diffVector;
		}
	}
	
	void OnTriggerEnter (Collider other){
	if(other.tag.Equals("Player")){	
		///Player.transform.parent = transform;	
			attached =true;
		}
	}
	
	void OnTriggerExit (Collider other){
		if (other.tag.Equals ("Player")) {	
			attached= false;
				//		other.transform.parent = null;	
				}
		
	}
	void adjustment(){
		diffVector = transform.position - Player.transform.position;
		diffVector = new Vector3(diffVector.x, diffVector.y +1, diffVector.z);
	}
}
