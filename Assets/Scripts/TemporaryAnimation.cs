using UnityEngine;
using System.Collections;

public class TemporaryAnimation : MonoBehaviour {
	public GameObject Player;
	private Controller controller;
	
	private bool Attack;
	
	
	// Use this for initialization
	void Start () {
	controller = Player.GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	if(Attack){	
		transform.Rotate(Vector3.forward * -60.0f );
		}
		
	
		

	if(Input.GetKeyDown(KeyCode.Z)){
		StartCoroutine("Attackanim");
		}
	if(Input.GetMouseButtonDown(0)){	
			StartCoroutine("Attackanim");
		
		}
		
	
	if(Input.GetKeyDown(KeyCode.Z)){
	StartCoroutine("Attackanim");
			}
	if(Input.GetMouseButtonDown(0)){	
		StartCoroutine("Attackanim");
		}
		
		
	}
			
	
	IEnumerator Attackanim (){
		Attack = true;
		yield return new WaitForSeconds(.1f);
		Attack = false;
	}
}
