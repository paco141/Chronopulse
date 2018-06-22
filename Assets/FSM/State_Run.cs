using UnityEngine;
using System.Collections;

public class State_Run : IState {
	
	private Vector3 MoveVector;
	
	// Use this for initialization
	public virtual void Update(Brain _brain  ){
		
	_brain.renderer.material.color = Color.red;
	
	_brain.rigidbody.velocity = MoveVector * 10;	
	_brain.transform.rotation = Quaternion.Slerp(_brain.transform.rotation, Quaternion.Euler(0,0,0), TimeModifier.SimulateTime * 6);	
		
	if(_brain.Player.transform.position.x > _brain.transform.position.x){
		MoveVector = Vector3.Lerp(MoveVector, (Vector3.right), TimeModifier.SimulateTime * 3);
		}
		
	if(_brain.Player.transform.position.x < _brain.transform.position.x){
		MoveVector = Vector3.Lerp(MoveVector, (Vector3.left), TimeModifier.SimulateTime * 3);	
		}	
		
		
		
	if(_brain.Dist < 3){
		_brain.rigidbody.velocity = Vector3.zero;
		_brain.ChangeState( new State_Attack() );	
		}
		
	if(_brain.Dist > 15){
		_brain.rigidbody.velocity = Vector3.zero;	
		_brain.ChangeState( new State_Idle() );	
		}	
	}
	
	public virtual void OnTriggerEnter( Brain _brain  ){

	}

	public virtual void OnTriggerExit( Brain _brain  ){
	
	}
}
