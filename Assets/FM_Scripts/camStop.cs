using UnityEngine;
using System.Collections;

public class camStop : MonoBehaviour {
	public CamTest cam;
	public bool pause;
	void OnTriggerEnter(Collider other)
	{
		if(other){
			if(pause)
				cam.pause(true);

			else
				cam.pause(false);

		}

	}
	

}
