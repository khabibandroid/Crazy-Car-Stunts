using UnityEngine;
using System.Collections;

public class CarRotationScript : MonoBehaviour 
{

	bool MbTouched;

	private bool forMobile;

	void Start () 
	{
		#if UNITY_EDITOR
		forMobile = false;
		#else
		forMobile = true;
		#endif
		//_temp = new GameObject();
		//canRotate = true;
		MbTouched=false;
	}
	


	void Update () 
	{

		if(Input.GetMouseButtonDown (0))
		{
			MbTouched = true;
		}
		if(Input.GetMouseButtonUp (0))
		{
			MbTouched = false;
		}
		RotateCar ();
//		Debug.Log ("I am pressing");
	}

	void RotateCar()
	{
		if(!MbTouched)
		   transform.Rotate (0,-0.5f,0,Space.Self);
		
	}

//	void OnMouseDown()
//	{
//		StaticVAriables.mGameState = eGAME_STATE.None;
//		LevelSelectionHandler.Instance.OnPlayClick ();
//	}
}
