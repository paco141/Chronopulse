
using UnityEngine;
using System.Collections;

public interface IState 
{	
	
	void Update( Brain _brain );
	void OnTriggerEnter( Brain _brain );
	void OnTriggerExit( Brain _brain  );
	
}
