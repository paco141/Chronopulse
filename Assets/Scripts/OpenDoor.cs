using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject TopDoor;
	public GameObject BotDoor;
	private bool Unlocked = false;
	private float TimeMod;	
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	TimeMod = TimeModifier.SimulateTime;	
		
	if(Unlocked){
		TopDoor.transform.position += transform.up * TimeMod * 10;
		BotDoor.transform.position += transform.up * TimeMod * -10;
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Data")){
			other.gameObject.SetActive(false);
			Unlocked = true;	
		}
	}
	

}
