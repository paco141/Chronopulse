using UnityEngine;
using System.Collections;

/// <summary>
/// This script will be attached to one empty object in every scene. 
/// For any script, we will use the global variable "Simulate Time" instead of Time.deltatime.
/// </summary>

public class TimeModifier : MonoBehaviour {
	
	public static float SimulateTime;
	internal static float SimulateTime2;
	public float HeartRate; 
	public float duration;	
	
	private float HeartRateModifier;
	public float Pulse;

	private bool Repeat;
	

	void Start () {
		Pulse = 1;
		HeartRateModifier = Pulse;
	}
	

	void FixedUpdate () {
			
		
		
		SimulateTime = Time.deltaTime * HeartRateModifier;
		SimulateTime2 = Time.deltaTime;
		if(HeartRateModifier != Pulse){
		HeartRateModifier = Mathf.Lerp(HeartRateModifier, Pulse, Time.deltaTime*4);
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			StartCoroutine("TimeStop");
		//	StartCoroutine(TimeStopDuration());
		}
		
			if(Input.GetKeyUp(KeyCode.LeftShift)){
			StopCoroutine("TimeStop");
			Pulse = 1;
		//	StartCoroutine(TimeStopDuration());
		}
		
		
	}
	

	
	IEnumerator TimeStopDuration (){
		
		Repeat = true;
		yield return new WaitForSeconds(duration);
		Repeat = false;
	}
	
	IEnumerator TimeStop (){
		
		Pulse = 0.0f;
		yield return new WaitForSeconds(HeartRate+1);
		Pulse = 1;
		yield return new WaitForSeconds(HeartRate);
		
		if(Input.GetKey(KeyCode.LeftShift)){
			StartCoroutine("TimeStop");
		}
		
		else
		Pulse = 1;	
		yield return null;
		
	}
}
