using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool Open = false;
	public Vector3 OpenPos;
	private Vector3 OriginalPos;
	public float Speed;
	public Quaternion OriginalRot;
	// Use this for initialization
	void Start () {
	OriginalRot = transform.rotation;	
	OriginalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Open){
			if(transform.position != OriginalPos){
			transform.position = Vector3.Lerp(transform.position, OriginalPos, TimeModifier.SimulateTime*Speed);
			
				
			}
				
		}
		
		if(Open){
			if(transform.position != OpenPos){
			transform.position = Vector3.Lerp(transform.position, OpenPos, TimeModifier.SimulateTime*Speed);
			}
		}
	}
}
