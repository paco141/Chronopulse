using UnityEngine;
using System.Collections;

public class turrent : MonoBehaviour {

	Vector3 aimDir;
	GameObject player;
	public GameObject cannon;
	public Rigidbody laser;
	//bool active;
	public float distanceToActivate;
	float playerDist;
	public float fireSpeed;
	float timer =0;

	// Use this for initialization
	void Start () {
		player = Controller.Player;
	
	}
	
	// Update is called once per frame
	void Update () {
		playerDist = Vector3.Distance(player.transform.position,cannon.transform.position);

		if(distanceToActivate >= playerDist)
		{
		aimDir = player.transform.position - cannon.transform.position;
		
			if (aimDir.normalized.x <= -0.5f)
			{
			
			Quaternion aimRot= Quaternion.LookRotation(aimDir);
			cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, aimRot, TimeModifier.SimulateTime *1 *20);

				timer += Time.deltaTime;
				if(timer >= fireSpeed){
					Rigidbody clone = Instantiate(laser,cannon.transform.position, cannon.transform.rotation)as Rigidbody;
					clone.GetComponent<Laser>().speedChange(5000);
					timer= 0;
				}
			}
		}
	
	}
}
