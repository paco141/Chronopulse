using UnityEngine;
using System.Collections;

public class swordSwing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider laserCollide){
		if (laserCollide.transform.tag == "Data"&& Input.GetMouseButtonDown(0)) {
			laserCollide.GetComponent<Laser>().Reflect(transform.forward);
		}

	}
}
