using UnityEngine;
using System.Collections;

public class State_Attack : IState {
	
	
	
	// Use this for initialization
	public virtual void Update(Brain _brain  ){
		
	
	_brain.transform.Rotate(Vector3.forward * TimeModifier.SimulateTime * 1000);
		
		
		
	if(_brain.Dist >3){
		_brain.ChangeState( new State_Run() );	
		}
	}
	
	public virtual void OnTriggerEnter( Brain _brain  ){

	}

	public virtual void OnTriggerExit( Brain _brain  ){
	
	}
}
