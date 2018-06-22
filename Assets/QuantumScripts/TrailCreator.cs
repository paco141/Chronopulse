using UnityEngine;
using System.Collections;

public class TrailCreator : MonoBehaviour {
	public GameObject ParentPlatform;
	private Vector3 StartScale;
	// Use this for initialization
	void Start () {
	StartScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)){
			
			transform.localScale += Vector3.up * Time.deltaTime * 2f;
			transform.position += Vector3.up * Time.deltaTime;
		}
		
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			transform.position = ParentPlatform.transform.position;
			transform.localScale = StartScale;
		}
	}
}
