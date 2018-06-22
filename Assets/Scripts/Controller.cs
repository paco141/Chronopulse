using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public float Gravity;	 //downward force
	public float TerminalVelocity;	//max downward speed
	public float JumpSpeed;
	public float MoveSpeed;
	public float jumpCount;	
	
	
	private float HorizontalInput;
	public bool RightWall = false;
	public bool LeftWall = false;
	public bool WallJumping = false;	
	public bool LockInput = false;	
	
	
	public Vector3 MoveVector {get; set;}
	public float VerticalVelocity {get; set;}
	public CharacterController CharacterController;
	
	// added
	public static GameObject Player ;
	public Transform R;
	public Transform L;
	Vector3 respawnPoint;
	// note need to add in rotaion or adjust player double jump;
	
	// Use this for initialization
	void Awake () {
		CharacterController = gameObject.GetComponent("CharacterController") as CharacterController;
		Player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		CheckMovement();
		CheckHitbox();
		HandleActionInput();
		ProcessMovement();
		
	}
	
	
	
	void CheckMovement(){
		
		if(!WallJumping){	
			HorizontalInput = Mathf.Lerp(HorizontalInput, Input.GetAxis("Horizontal"), Time.deltaTime*15);	
		}
		
		if(WallJumping){	
			//HorizontalInput = -2;
			
		}	
		var deadZone = 0.1f;
		VerticalVelocity = MoveVector.y;
		MoveVector = Vector3.zero;
		
		if(!LockInput){	
			if(Input.GetAxis("Horizontal") !=0){	
				WallJumping = false;	
			}
		}
		
		if(HorizontalInput > deadZone || HorizontalInput< -deadZone){
			
			MoveVector += new Vector3(HorizontalInput,0,0);	
		}
		
		
		
		
		
	}
	
	void CheckHitbox (){	
		
		RaycastHit hit;	
		
		if(Physics.Raycast(transform.position, Vector3.right, out hit, 1.0f)){
			jumpCount = 2;	
			RightWall = true;
		}
		
		if(!Physics.Raycast(transform.position, Vector3.right, out hit, 1.0f)){
			RightWall = false;
		}
		
		if(Physics.Raycast(transform.position, Vector3.left, out hit, 1.0f)){
			jumpCount = 2;
			LeftWall = true;
		}
		
		if(!Physics.Raycast(transform.position, Vector3.left, out hit, 1.0f)){
			LeftWall = false;
		}	
	}
	
	void HandleActionInput(){
		
		if(CharacterController.isGrounded){
			WallJumping = false;	
			jumpCount = 0;
		}		
		
		if(Input.GetButtonDown("Jump")){
			if(!RightWall && !LeftWall){	
				if(jumpCount < 1){
					if (Input.GetKeyDown(KeyCode.Space)){
						Jump();
						jumpCount++;
					}
				}
				
				if(jumpCount <= 2){
					if (Input.GetKeyDown(KeyCode.Space)){
						JumpJump();
						jumpCount++;
					}
					
					if(!LockInput){	
						WallJumping = false;	
					}	
				}
			}
			
			if(RightWall){		
				StartCoroutine(JumpRight());	
			}
			if(LeftWall){	
				StartCoroutine(JumpLeft());		
			}
			
		}
	}
	
	
	
	void ProcessMovement(){
		if(!WallJumping){	
			//transform moveVector into world-space relative to character rotation
			// mod . get the target objects direction then determine if going right or left 
			Vector3 playerZX = new Vector3(transform.position.x,0,transform.position.z);
			Vector3 dirZX    = new Vector3(R.position.x,0,R.position.z);
			Vector3 dir2ZX   = new Vector3(L.position.x,0,L.position.z);
			Vector3 dirLook  = (dirZX - playerZX); 
			Vector3 dirLook2 = (dir2ZX - playerZX); 
			if(Input.GetAxis("Horizontal") >= .02f)
			{
				transform.rotation = Quaternion.LookRotation(dirLook);
				MoveVector =  dirLook;
				
			}
			else if(Input.GetAxis("Horizontal") <= -.02f)
			{
				transform.rotation = Quaternion.LookRotation(dirLook2);
				MoveVector =  -1 *dirLook2;
			}
			
		}
		
		//normalize moveVector if magnitude > 1
		if(MoveVector.magnitude > 1){
			MoveVector = Vector3.Normalize(MoveVector);
		}
		
		//multiply moveVector by moveSpeed
		MoveVector *= MoveSpeed;
		
		// mod . Register keystroke if its not here it automaticaly move
		MoveVector *= Input.GetAxis("Horizontal");
		
		
		//reapply vertical velocity to moveVector.y
		MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);
		
		//apply gravity
		applyGravity();
		
		//move character in world-space
		CharacterController.Move(MoveVector * Time.deltaTime);
	}
	
	void applyGravity(){
		
		
		if(MoveVector.y > -TerminalVelocity){
			MoveVector = new Vector3(MoveVector.x, (MoveVector.y - Gravity * Time.deltaTime), MoveVector.z);
		}
		
		if(CharacterController.isGrounded && MoveVector.y < -1){
			MoveVector = new Vector3(MoveVector.x, (-1), MoveVector.z);
		}
	}
	
	IEnumerator JumpRight(){	
		HorizontalInput = -2;	
		VerticalVelocity = JumpSpeed;
		WallJumping = true;
		LockInput = true;	
		yield return new WaitForSeconds(.15f);
		LockInput = false;	
		
	}
	
	IEnumerator JumpLeft(){	
		HorizontalInput = 2;	
		VerticalVelocity = JumpSpeed;
		WallJumping = true;
		LockInput = true;	
		yield return new WaitForSeconds(.15f);
		LockInput = false;	
		
	}	
	
	public void Jump(){
		
		if(CharacterController.isGrounded){
			VerticalVelocity = JumpSpeed;
			
		}
	}
	
	public void JumpJump(){
		
		VerticalVelocity = JumpSpeed;
		
	}

	public void Respawn(){
		if(respawnPoint!= null)
		transform.position = respawnPoint;
	}
	public void setRespawnPoint(Vector3 newRespawnPoint){
		respawnPoint = newRespawnPoint;
	}
	
	
}