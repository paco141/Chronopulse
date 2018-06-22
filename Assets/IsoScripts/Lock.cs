using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {
	public GameObject Door;
	private Door door;
	public float UnlockTime;
	private float UTime;
	public GameObject Beam;
	public bool Unlock = false;
	// Use this for initialization
	void Start () {
	UTime = UnlockTime;	
	door = Door.GetComponent<Door>();
	}
	

	
	// Update is called once per frame
	void Update () {
		
		if(Unlock){
			UnlockTime -= TimeModifier.SimulateTime;
			door.Open = true;
		}
		
		if(UnlockTime <= 0){
			Unlock = false;
			UnlockTime = UTime;
			door.Open = false;
		}
		
		//UnlockTime *= TimeModifier.SimulateTime * 100;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.left, out hit, 3.0f) || Physics.Raycast(transform.position, Vector3.right, out hit, 3.0f)) {
			if(Input.GetKeyDown(KeyCode.K)){
					
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Key")){	
			Unlock = true;
			//StartCoroutine("Unlock");
			//Beam.SetActive(false);	
		}
		
	}
	
}
