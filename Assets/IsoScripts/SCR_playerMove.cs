using UnityEngine;
using System.Collections;
 
public class SCR_playerMove : MonoBehaviour {
	
	
	public bool dashing;
	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
    
	public bool clickToMove;  
	public float clickMoveSpeed;						// The Speed the character will move
 	public float keyMoveSpeed = 0.05F;
 
	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
	}
	
	IEnumerator Dash (){
	dashing = true;
		yield return new WaitForSeconds(.15f);
		dashing = false;
	}
 
	void FixedUpdate () {
 
		if(dashing){
		myTransform.position += transform.forward * Time.deltaTime * 50;	
		}
		
			if(Input.GetMouseButton(1)){
			clickToMove = false;
				destinationDistance = 5.0f;
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 5;
			
						
			
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
			
			StartCoroutine("Dash");
			
			}
		
		
        if(clickToMove==true){
			// keep track of the distance between this gameObject and destinationPosition
			destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
	 
			if(destinationDistance < .5f){		// To prevent shakin behavior when near destination
				clickMoveSpeed = 0;
				//animation.Play("idle");
			}
			else if(destinationDistance > .5f){			// To Reset Speed to default
				clickMoveSpeed = 15;
				//animation.Play("run");
			}
	 			
		
			// Moves the Player if the Left Mouse Button was clicked
			if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) {
	 
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
	 
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
			}
	 
			// Moves the player if the mouse button is hold down
			else if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
	 
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
	 
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
			//	myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
			}
			
			
	 
			// To prevent code from running if not needed
			if(destinationDistance > .5f){
				myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, clickMoveSpeed * Time.deltaTime);
			}
		}
		
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
		    clickToMove=false;	
			transform.position += new Vector3(1, 0, 1) * keyMoveSpeed * Time.deltaTime;
			//animation.Play("run");
		} 
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
		    clickToMove=false;
			transform.position += new Vector3(-1, 0, -1) * keyMoveSpeed * Time.deltaTime;
			//animation.Play("run");
		} else {
		    if(Input.GetMouseButtonDown(0)){
                clickToMove=true;
			}
			
			if(clickToMove==false&&Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			//	animation.Play("strafeLeft");
            }				
	
			else if(clickToMove==false&&Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			//	animation.Play("strafeRight");
            }	
	
		    else if(clickToMove==false){
			//	animation.Play("idle");
            }				
        }	
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 1) * keyMoveSpeed * Time.deltaTime;
			clickToMove=false;
		} 
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3(1, 0, -1) * keyMoveSpeed * Time.deltaTime;
			clickToMove=false;

		} 	

	}
}