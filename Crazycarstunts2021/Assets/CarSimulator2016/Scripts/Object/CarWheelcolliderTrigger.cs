using UnityEngine;
using System.Collections;

public class CarWheelcolliderTrigger : MonoBehaviour 
{
	public bool mbIsonSignal;
	void OnTriggerEnter(Collider col)
	{
		if(col.tag =="SignalTrigger")
		{
			if(!mbIsonSignal)
			  mbIsonSignal = true;


		}
	}

	void Update()
	{
		//Signelfunction ();
	}
	void Signelfunction()
	{
		RaycastHit hit;
		Ray ray;
		Debug.DrawRay (this.transform.position, Vector3.down* 3,Color.green);
//		if (Physics.Raycast (_origin.transform.position, _origin.transform.forward, out _hit, 3)
		if (Physics.Raycast (this.transform.position, Vector3.down*3, out hit))
		{
//			Debug.Log (" am on road");
			if(hit.transform.tag=="SignalTrigger")
			{
				Debug.Log (" am on road");
			}
		}
	}
}
