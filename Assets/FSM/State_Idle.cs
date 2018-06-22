using UnityEngine;
using System.Collections;

public class State_Idle : IState {
	

	// Use this for initialization
	public virtual void Update(Brain _brain  ){
		
	_brain.renderer.material.color = Color.white;
	
		
	if(_brain.Dist < 15){
		_brain.ChangeState( new State_Run() );	
		}
	}
	
	public virtual void OnTriggerEnter( Brain _brain  ){

	}

	public virtual void OnTriggerExit( Brain _brain  ){
	
	}
}
