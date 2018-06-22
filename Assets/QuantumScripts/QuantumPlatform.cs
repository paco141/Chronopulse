using UnityEngine;
using System.Collections;

public class QuantumPlatform : MonoBehaviour {
	public bool Child;
	public bool Parent;
	public float Speed;
	private float SimulateTime;
	public Transform ParentObj;
	void Start () {
		if(Child){
			SimulateTime = 0;
		}
		
		if(Parent){
			SimulateTime = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){
		Application.LoadLevel(0);	
		}
		transform.position -= transform.up * Time.deltaTime * SimulateTime * Speed;
				
		if(!Input.GetKey(KeyCode.LeftShift)){
			if(Child){
				transform.position = ParentObj.position;	
				SimulateTime = 0;
			}
			if(Parent){
			SimulateTime = 1;	
			}
			
		if(Input.GetKey(KeyCode.LeftShift)){	
			if(Child){
				SimulateTime = 1;
			}
			if(Parent){
			SimulateTime = 0;	
			}
			}
		}
		
		
		
		
	}
}
