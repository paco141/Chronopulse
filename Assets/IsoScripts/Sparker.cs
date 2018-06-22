using UnityEngine;
using System.Collections;

public class Sparker : MonoBehaviour {
	public GameObject Projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	public void Forward (){
	Instantiate(Projectile, transform.position, Quaternion.Euler(0, 0, 0));		
	}
	
	public void Back (){
	Instantiate(Projectile, transform.position, Quaternion.Euler(0, 180, 0));		
	}
	
	public void Left (){
	Instantiate(Projectile, transform.position, Quaternion.Euler(0, -90, 0));		
	}
	
	public void Right (){
	Instantiate(Projectile, transform.position, Quaternion.Euler(0, 90, 0));		
	}
	
	
}
