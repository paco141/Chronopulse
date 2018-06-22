using UnityEngine;
using System.Collections;

public class DataField : MonoBehaviour {
	public bool RightField;
	public bool UpField;
	
	public GameObject ResetField;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Data")){	
			if(UpField){
			other.transform.position = new Vector3(other.transform.position.x, ResetField.transform.position.y, other.transform.position.z);	
			}
			
			if(RightField){
			other.transform.position = new Vector3(ResetField.transform.position.x, other.transform.position.y, other.transform.position.z);	
			}
			
		}
	}
}
