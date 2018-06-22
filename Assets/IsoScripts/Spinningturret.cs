using UnityEngine;
using System.Collections;

public class Spinningturret : MonoBehaviour {
	public GameObject Projectile;
	private float timer;
	public float Speed;
	public bool up;
	public bool forward;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		
		if(up){
		transform.Rotate(Vector3.up * TimeModifier.SimulateTime * Speed);
		}
		
		if(forward){
		transform.Rotate(Vector3.forward * TimeModifier.SimulateTime * Speed);	
		}
		
 		timer += TimeModifier.SimulateTime;
		if(timer > .3	){
		timer = 0;
			Instantiate(Projectile, transform.position, transform.rotation);
		}
	}
}
