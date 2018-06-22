using UnityEngine;
using System.Collections;

public class Anims : MonoBehaviour {
	public CharacterController CharacterController;
	public bool Landing;
	public bool grounded;
	// Use this for initialization
	void Start () {
	//CharacterController = gameObject.GetComponent("CharacterController") as CharacterController;	
	animation["run"].speed = 5.0f;
	animation["attack"].speed = 4.0f;	
	animation["idle"].speed = 0.5f;
	animation["jump"].speed = 0.55f;	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(CharacterController.isGrounded){
		
		
		if(Input.GetMouseButtonDown(0)){
		animation.Play("attack");	
		}	
			
			grounded = false;
		if(Input.GetAxisRaw("Horizontal") != 0){
		animation.CrossFade("run");	
		}
			if(Input.GetAxisRaw("Horizontal") == 0){
		animation.CrossFade("idle");	
		}
		
			
		}
		
		if(CharacterController.isGrounded){
			grounded = true;
			
			if(Input.GetAxis("Horizontal")==0){
				if(Landing){		
					StartCoroutine("Land");
						animation.CrossFade ("land");
						animation.CrossFadeQueued ("idle");
				}
				
				if(!Landing){
				//	animation.CrossFade ("idle");	
				}
				
			}
		}
		if(Input.GetKeyDown(KeyCode.Space)){
		Landing = true;
		animation.Play ("jump");		
		}
		
		
		
	}
	
	IEnumerator Land (){
	
	yield return new WaitForSeconds(.25f);
		Landing = false;
		//animation.CrossFade ("idle");
		
	}
}
