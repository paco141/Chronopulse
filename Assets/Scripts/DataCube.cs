using UnityEngine;
using System.Collections;

public class DataCube : MonoBehaviour {
	public bool RightCube;
	public bool UpCube;
	public float Speed;
	
	private Vector3 CubeVector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = CubeVector;
		
		if(UpCube){
		CubeVector = Vector3.up * Speed * TimeModifier.SimulateTime * 100;	
		}
		if(RightCube){
		CubeVector = Vector3.right * Speed * TimeModifier.SimulateTime * 100;	
		}
	}
}
