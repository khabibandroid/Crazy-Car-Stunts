using UnityEngine;
using System.Collections;


public enum  ePassengerState
{
	None,
	Pickup,
	Drop,
	Oncar
}

public class PassengerScript : MonoBehaviour
{

	public GameObject PickPoint, PickArea, DropPOint, DropArea;
	public GameObject _goPassenger;
	public GameObject _goGetpoint;
	public static ePassengerState mPassengerstate = ePassengerState.None;

	public GameObject _goCamarParent;

	void Awake ()
	{
		
	}

	void Start ()
	{
		_goCamarParent = GameObject.FindWithTag ("CamaraParent");
		_goGetpoint = GameObject.FindWithTag ("Getpoint");
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;
		
		
		PassengerBehaviuor ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void PassengerBehaviuor ()
	{
		if (!_goPassenger)
			return;


		if (mPassengerstate == ePassengerState.Pickup)
		{
			//Debug.Log ("pick up");
			_goCamarParent.GetComponent<CamaraSettings> ().PAssengerEntryCamara ();
			OnCompleteWalk ();
			iTween.MoveTo (_goPassenger, iTween.Hash ("position", _goGetpoint.transform.position, "easetype", iTween.EaseType.linear, "time", 3f, "oncomplete", "OnCompleteidle", "oncompletetarget", gameObject));
			_goPassenger.transform.LookAt (_goGetpoint.transform);
			mPassengerstate = ePassengerState.Oncar;
			Invoke ("CheckPaasengerState", 4f);


		} else if (mPassengerstate == ePassengerState.Drop)
		{
			//Debug.Log ("Drop");
			_goPassenger.transform.position = _goGetpoint.transform.position;
			_goCamarParent.GetComponent<CamaraSettings> ().PAssengerEntryCamara ();
			iTween.MoveTo (_goPassenger, iTween.Hash ("position", DropPOint.transform.position, "easetype", iTween.EaseType.linear, "time", 3f, "oncomplete", "OnCompleteidle", "oncompletetarget", gameObject));
			_goPassenger.transform.LookAt (DropPOint.transform);
			mPassengerstate = ePassengerState.None;
			Invoke ("CheckPaasengerState", 1f);

		}
	}

	void OnCompleteWalk ()
	{
		_goPassenger.GetComponent<AnimationHandler> ().WalkToCar ();

	}

	void OnCompleteidle ()
	{
		Debug.Log ("Moe Complete");
		_goPassenger.GetComponent<AnimationHandler> ().RandomIdle ();
	}

	public void CheckPaasengerState ()
	{
		if (mPassengerstate == ePassengerState.Oncar)
		{
			if (_goPassenger)
				_goPassenger.SetActive (false);
			_goCamarParent.GetComponent<CamaraSettings> ().ResetCAmarapos ();
			//	_goPassenger.transform.position = DropArea.transform.position;
		} else
		{
			_goPassenger.SetActive (true);
			OnCompleteWalk ();

		}
	}

}
