using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour {
	public GameObject Player;
	
	internal float Dist;
	

	public void ChangeState( IState newState ){
		
		m_curState = newState;
		
	}	

	private void Awake(){
		
		
		m_curState = new State_Idle();	
	
	}

	   
	private void Update() {
		
		m_curState.Update(this);
		Dist = Vector3.Distance(transform.position, Player.transform.position);
	}
	
	

	
	private void OnTriggerEnter(){ 
		
		m_curState.OnTriggerEnter(this);	
		
	}


	private void OnTriggerExit(){
		
		m_curState.OnTriggerExit(this);	
		
	}
	

	

	private IState m_curState;
}