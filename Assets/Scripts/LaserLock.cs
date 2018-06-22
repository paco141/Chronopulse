using UnityEngine;
using System.Collections;

public class LaserLock : MonoBehaviour {
	public GameObject Laser;
	public GameObject LaserPointer;
	private bool Enter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	if(Enter){
		if(Input.GetKeyDown(KeyCode.Z)){
			Fire();	
			}		
		}
	}
	
	void OnTriggerEnter (Collider other){
		if(other.tag.Equals("Player")){	
			Enter = true;
		}
	}
	
		void OnTriggerExit(Collider other){
		if(other.tag.Equals("Player")){	
			Enter = false;
		}
	}
	
	void Fire(){
		Instantiate(Laser, LaserPointer.transform.position, LaserPointer.transform.rotation);
	}
}
