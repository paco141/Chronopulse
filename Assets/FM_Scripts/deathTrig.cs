using UnityEngine;
using System.Collections;

public class deathTrig : MonoBehaviour {


	void OnTriggerEnter(Collider player){
		if(player.tag =="Player"){
			player.GetComponent<Controller>().Respawn();
		}
		
	}
}
