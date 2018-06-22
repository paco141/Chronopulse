using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public GameObject BackBeam;
	public GameObject LeftBeam;
	public GameObject RightBeam;
	public GameObject ForwardBeam;
	public GameObject Projectile;
	
	public bool Switching;
	private Quaternion ProjRot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Deactivate (){
		
		if(!Switching){
			RightBeam.SetActive(false);
			ForwardBeam.SetActive(false);
			BackBeam.SetActive(false);
			LeftBeam.SetActive(false);
		}
		
	}
	
	public void Forward (){
		ForwardBeam.SetActive(true);
	}
	
	public void Back (){
		BackBeam.SetActive(true);	
	}
	
	public void Left (){
		LeftBeam.SetActive(true);	
	}
	
	public void Right (){
		RightBeam.SetActive(true);	
	}
	
	IEnumerator Shoot (){
		Switching = true;
		yield return new WaitForSeconds(.2f);
		Instantiate(Projectile, transform.position, ProjRot);	
		yield return new WaitForSeconds(2);
		Switching = false;
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Key")){
			if(!Switching){
			Destroy(other.gameObject);
				
			if(ForwardBeam.activeSelf){	
				ProjRot = Quaternion.Euler(0, 0, 0);
				StartCoroutine(Shoot ());
				
				}
			if(BackBeam.activeSelf){	
				ProjRot = Quaternion.Euler(0, 180, 0);
				StartCoroutine(Shoot ());
				
				}
			if(LeftBeam.activeSelf){	
				ProjRot = Quaternion.Euler(0, -90, 0);
				StartCoroutine(Shoot ());
				
				}
			if(RightBeam.activeSelf){	
				ProjRot = Quaternion.Euler(0, 90, 0);
				StartCoroutine(Shoot ());
				
				}	
			}
		}
	}
}
