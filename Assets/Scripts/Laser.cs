using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	private float Simtime;
	private Vector3 dir ;
	private float speed;
	private bool b_destory;
	// Use this for initialization
	void Start () {
		speed = 9000;
		dir = this.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
	Simtime = TimeModifier.SimulateTime;	

	rigidbody.velocity = dir * speed * Simtime;
	
	}

	public void Reflect(Vector3 dir_r){
		dir= dir_r;
		transform.eulerAngles = new Vector3(0,90,0);

	}
	public void speedChange( float newSpeed)
	{
		b_destory= true;
		speed = newSpeed;
	}
	void OnTriggerEnter(Collider player){
		if(player.tag =="Player"){
		//	player.GetComponent<Controller>().Respawn();
		}

	}
}
