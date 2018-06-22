using UnityEngine;
using System.Collections;

public class PlatformSwitcher : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other){
		if(other.collider.tag.Equals("Platform")){
		other.gameObject.GetComponent<MovingPlatform>().SwitchUp();
		}
	}
}
