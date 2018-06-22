using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class tempGUI : MonoBehaviour {

	public GUIStyle front;
	public GUIStyle back;
	public GUIStyle middle;

	public float height  = 50;
	public float width = 100;
	public float wB =100;
	public float barWidth;
	float barStartValue;
	public float percentOfBar; 
	public TimeModifier TMod;
	public bool reset;
	public bool countdown;
	// Use this for initialization
	void Start () {
		barWidth = TMod.duration;
		barStartValue = TMod.duration;
	}
	
	// Update is called once per frame
	void Update () {

		percentOfBar = barWidth / barStartValue;
		Bar();
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			countdown = true;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			countdown = false;
		}

	}

	void OnGUI(){
		GUI.BeginGroup(new Rect(0, 0, width, height));
		GUI.Box(new Rect(0, 0, width, height), "", back);
		GUI.EndGroup();

		GUI.BeginGroup(new Rect(0, 0, width, height));
		GUI.Box(new Rect(width, 0, -Mathf.Lerp(wB,0,percentOfBar), height), "", middle);
		GUI.EndGroup();

		GUI.BeginGroup(new Rect(0, 0, width, height));
		GUI.Box(new Rect(0, 0, width, height), "", front);
		GUI.EndGroup();


	}
	void Bar(){
		if(countdown){
			//Debug.Log("trolled");
			barWidth -= Time.deltaTime;
		}



		if(barWidth <= barStartValue &&!countdown){
		
			barWidth += Time.deltaTime ;
		}


	}

}
