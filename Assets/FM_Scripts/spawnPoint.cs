using UnityEngine;
using System.Collections;

public class spawnPoint : MonoBehaviour {

	void OnTriggerEnter(Collider player)
	{
	if(player.tag == "Player")
			player.GetComponent<Controller>().setRespawnPoint(transform.position);
	}
}
