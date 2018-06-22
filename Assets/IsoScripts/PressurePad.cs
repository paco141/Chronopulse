using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {
	public GameObject Spark;
	public GameObject Switch;
	
	public bool forward;
	public bool back;
	public bool left;
	public bool right;
	
	public bool SparkPad;
	public bool SwitchPad;
	
	private Sparker sparker;
	private Switch switcher;
	// Use this for initialization
	void Start () {

	
	switcher = Switch.GetComponent<Switch>();
	sparker = Spark.GetComponent<Sparker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other ) {
		if(other.tag.Equals("Player")){
			
			if(SparkPad){
			if(back){
				sparker.Back();	
			}
			
			if(left){
				sparker.Left();	
			}
			
			if(right){
				sparker.Right();	
			}
			
			if(forward){
				sparker.Forward();	
				}
			}
			
		if(SwitchPad){
			if(back){
				switcher.Back();	
			}
			
			if(left){
				switcher.Left();	
			}
			
			if(right){
				switcher.Right();	
			}
			
			if(forward){
				switcher.Forward();	
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag.Equals("Player")){	
		if(SwitchPad){
		switcher.Deactivate();	
			}
		}
	}
}
