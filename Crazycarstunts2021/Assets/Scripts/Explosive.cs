using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
	bool basted = false;
	GameObject  rb;
	public GameObject ExpEff;

	// Use this for initialization
	void Start () {
		//		rb = GameObject.Find("rigid_bike").GetComponent<Rigidbody>();

		//rb = GameManager.staticscript.mg_playerCarArray [StaticVariables.sv_iselectedCar - 1];
		//		if(_enterCol.gameObject.layer == LayerMask.NameToLayer ("Obstacles"))


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			print("Exp:"+other.name);
			if(basted) return;
			rb.GetComponent<Rigidbody>().AddExplosionForce(200000,transform.position,10);

			basted = true;
			GameObject eff = Instantiate(ExpEff);
			eff.transform.position = transform.position;
			Destroy(eff,2f);

			GetComponent<MeshRenderer>().enabled = false;

			Destroy(gameObject,2);

		}


	}
	

}
