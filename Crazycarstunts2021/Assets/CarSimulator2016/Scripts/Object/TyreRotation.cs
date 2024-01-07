using UnityEngine;
using System.Collections;
using System .Collections.Generic;

public class TyreRotation : MonoBehaviour 
{

	public Transform Tvehicle;
	public List<Transform> myTyre=new List<Transform>();
	void Awake()
	{
		Tvehicle = this.transform;

	}
	void Start () 
	{
		foreach(Transform obj in Tvehicle)
		{
			if (obj.tag == "Tyre")
				myTyre.Add (obj.gameObject.transform);
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;
		for(int i=0;i<myTyre.Count;i++)
		{
			myTyre[i]. transform.Rotate(Vector3.right *10);
		}
	
	}
}
