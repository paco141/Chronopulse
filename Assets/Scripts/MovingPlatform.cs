using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public float switcher = 1;

	public float speed;
	private float simTime;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	simTime = TimeModifier.SimulateTime;	
		
	
		
		
		
		rigidbody.velocity = Vector3.right * simTime * switcher * speed;
		
	}
	
	public void SwitchUp(){
	
		switcher *= -1;
	}
	
	
	
	
}
