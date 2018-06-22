using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject Player;
	public float Threshold;
	public float Dist;
	public float DistY;
	public CharacterController characterController;
	public bool Running = false;
	public bool Grounded = false;
	public Vector3 PlayerPos;
	public float TempXpos;
	public float TempYPos;
	private Vector3 CameraPos;
	public float CamSpeed;
	public float CameraZ;
	
	void Start (){
		transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y,CameraZ );
	}
	
	void Update (){
		
		CameraPos = new Vector3(transform.position.x, transform.position.y, CameraZ);
		PlayerPos = new Vector3(TempXpos, Player.transform.position.y + 2.0f, CameraZ); 
		
		
		
		if (characterController.isGrounded){
			Grounded = true;
		}
		
		if (characterController.isGrounded == false){
			Grounded = false;
		}
		
		if(Input.GetAxis("Horizontal") !=0){
		Running = true;	
		}
		
		else
		Running = false;	
		
		
		
		Dist = Vector3.Distance(CameraPos, PlayerPos);
		
		
		if(Player.transform.position.x > -13.0f){
			TempXpos = Player.transform.position.x;
		}

		
		else
		TempXpos = -13.0f;
		
		//CamSpeed = Dist *= 2.3f;
		
		if(Dist >=Threshold){
			
			
			
		transform.position = Vector3.Lerp (CameraPos, PlayerPos, Time.deltaTime * CamSpeed);
				
			

			
			if(Input.GetKey(KeyCode.UpArrow)){
				if (Grounded){
					if(Running == false){
						transform.position += transform.up * 7.0f * Time.deltaTime*CamSpeed;	
					}
				}
			}
		}
		
	
	}
}

