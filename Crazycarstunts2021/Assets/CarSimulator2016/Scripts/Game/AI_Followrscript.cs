using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AI_Followrscript : MonoBehaviour
{
	
	public Transform T_targetAI;
	float mfTotalDIstance;
	float mfTotalAngle;
	float TotalMoveArea;
	float NeedleX;

	public  GameObject _goNeedleBar;
	public  GameObject Needle;

	Vector3 mvNeedlePOs = Vector3.zero;



	public  float mfMaxDistance;
	private float mfmydistace;
	Vector3 _mvTarget = Vector3.zero;
	bool mbwarning;

	void Awake ()
	{
		if (StaticVAriables.mLevelstate != eLEVEL_TYPE.Tailing)
			return;
		       
		//Invoke ("InitializeItems",1f);
	}

	void Start ()
	{
		if (StaticVAriables.mLevelstate != eLEVEL_TYPE.Tailing)
			return;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;



		FindDistacetoAI ();

	}

	void FindDistacetoAI ()
	{
//		if (mbwarning)
//			return;
		
		if (T_targetAI != null) {
			_mvTarget = T_targetAI.transform.position - transform.position;
			mfTotalDIstance = Vector3.Distance (T_targetAI.transform.position, gameObject.transform.position);
			mfTotalAngle = Vector3.Angle (_mvTarget, transform.forward);
			FindAngle ();
			needleBarPositioning ();

			//Debug.Log ("calling");

		} else if (!mbwarning) {
			mbwarning = true;
			Debug.LogWarning ("Assign One Target Object  for");

		}


		
	}

	void FindAngle ()
	{
		//mfmydistace = mfMaxDistance;
		if (mfTotalAngle > 45) {
			mfmydistace = (mfMaxDistance) - 5;
		} else
			mfmydistace = mfMaxDistance;
		//Debug.Log (mfmydistace+"   "+mfTotalDIstance);
	}

	void needleBarPositioning ()
	{
		
		float val = ((mfTotalDIstance) / (mfmydistace)) - 1;

		if (val > 1)
			val = 1;
		else if (val < -1)
			val = -1;
//		
		NeedleX = (TotalMoveArea * val);
		//Debug.Log (""NeedleX);
		mvNeedlePOs.x = Mathf.Lerp (mvNeedlePOs.x, NeedleX, Time.deltaTime * 5);
		Needle.GetComponent<RectTransform> ().anchoredPosition3D = mvNeedlePOs;

		//Debug.Log (val);

		if (val > 0.99f && val < 1f || val < -0.99f) {
			//StaticVAriables.mGameState=eGAME_STATE.None;
//			UI_handlerScript.Instance.ShowLevelFailed ();//BSRR
			UI_handlerScript.Instance.ShowLevelFailed();
		}

		//Debug.Log (val);
	}

	public void InitializeItems ()
	{
		//Debug.Log ("car taking");
		T_targetAI = GameObject.Find ("FollowAI/AiCar").transform;
		_goNeedleBar = GameObject.FindWithTag ("NeedleBar");
		Needle = _goNeedleBar.transform.GetChild (0).transform.gameObject;
		TotalMoveArea =	_goNeedleBar.GetComponent<RectTransform> ().rect.width / 2;
		mvNeedlePOs = Needle.GetComponent<RectTransform> ().anchoredPosition3D;

	}

}
