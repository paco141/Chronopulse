using UnityEngine;
using System.Collections;

public class resetPos : MonoBehaviour {
	public GameObject L;
	public GameObject R;
	public GameObject L_reset;
	public GameObject R_reset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey(KeyCode.Q))
	{
			L.transform.position = L_reset.transform.position;
			R.transform.position = R_reset.transform.position;

	}
	}
}
