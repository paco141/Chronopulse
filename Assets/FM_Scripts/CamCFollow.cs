using UnityEngine;
using System.Collections;

public class CamCFollow : MonoBehaviour {

	public GameObject followObject;
	[Range(0,1)]public float T;
	public

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(this.transform.position, followObject.transform.position, T);
		transform.LookAt(Controller.Player.transform);

	}
}
