using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;
using UnityEngine.UI;

public class CamaraSettings : MonoBehaviour
{

	public GameObject gPivot;
	public GameObject gParentCAm;
	public Image CockpitView;


	public GameObject gFPS;
	public GameObject gTPS;
	public GameObject gTopViewCamera;
	public GameObject gParkPos;
	public GameObject gReverce;
	public Camera MyCam;
	public GameObject go_Mirror;
	public static CamaraSettings Instance = null;
	Vector3 Temppos;
	eCAMARA_TYPE _ePreviousCamarastate = eCAMARA_TYPE.None;

	private RCC_CarControllerV3 mscript_RCCref;
	private int camCount=1;
	void Awake ()
	{
		Instance = this;
		Temppos = gPivot.transform.position;
		CamaraPOsition ();
		StaticVAriables.mCamaraState = eCAMARA_TYPE.Cockpit;

	}

	void Start ()
	{
		Invoke ("ChangeCamaraFunction", 0.001f);
		Temppos = gPivot.transform.localPosition;
		mscript_RCCref = LevelManagerScript.Instance._goPlayerCar.GetComponent <RCC_CarControllerV3> (); 
	}

	public void ChangeCameraAngle()
	{
		camCount+=1;
		Debug.Log("CamCount::"+camCount);
		if(camCount==1)
		{
			go_Mirror.SetActive (false);
			gPivot.transform.localPosition = gTPS.transform.localPosition;
			gPivot.transform.localEulerAngles = gTPS.transform.localEulerAngles;
			gPivot.GetComponent <CameraTouchMovementControl> ().enabled = false;
			CockpitView.GetComponent <Image> ().enabled = false;
			UI_handlerScript.Instance.go_CarControls.GetComponent<Canvas> ().sortingOrder = -1;
		}
		if(camCount==2)
		{
			go_Mirror.SetActive (true);
			CockpitView.GetComponent <Image> ().enabled = true;
			gPivot.transform.localPosition = gFPS.transform.localPosition;
			gPivot.transform.localEulerAngles = gFPS.transform.localEulerAngles;
			gParentCAm.GetComponent<AutoCam> ().enabled = true;
			UI_handlerScript.Instance.go_CarControls.GetComponent<Canvas> ().sortingOrder = 1;
		}
		if(camCount==3)
		{
			go_Mirror.SetActive (false);
			gPivot.transform.localPosition = gTopViewCamera.transform.localPosition;
			gPivot.transform.localEulerAngles = gTopViewCamera.transform.localEulerAngles;
			gPivot.GetComponent <CameraTouchMovementControl> ().enabled = false;
			CockpitView.GetComponent <Image> ().enabled = false;
			UI_handlerScript.Instance.go_CarControls.GetComponent<Canvas> ().sortingOrder = -1;
			camCount=0;
		}
	}
	public void ChangeCamaraFunction ()
	{
//		camCount += 1;
		
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;
		if (StaticVAriables.mCamaraState == eCAMARA_TYPE.Cockpit) {
//			Debug.Log("CAmara calling And camcount::"+camCount);
			StaticVAriables.mCamaraState = eCAMARA_TYPE.ThirdPerson;
			go_Mirror.SetActive (false);
			gPivot.transform.localPosition = gTPS.transform.localPosition;
			gPivot.transform.localEulerAngles = gTPS.transform.localEulerAngles;
			gPivot.GetComponent <CameraTouchMovementControl> ().enabled = false;
			CockpitView.GetComponent <Image> ().enabled = false;
			UI_handlerScript.Instance.go_CarControls.GetComponent<Canvas> ().sortingOrder = -1;
			//Debug.Log("third person");
			return;
		} else if (StaticVAriables.mCamaraState == eCAMARA_TYPE.ThirdPerson) {
			StaticVAriables.mCamaraState = eCAMARA_TYPE.Cockpit;
			go_Mirror.SetActive (true);
			CockpitView.GetComponent <Image> ().enabled = true;
			gPivot.transform.localPosition = gFPS.transform.localPosition;
			gPivot.transform.localEulerAngles = gFPS.transform.localEulerAngles;
			gParentCAm.GetComponent<AutoCam> ().enabled = true;
			UI_handlerScript.Instance.go_CarControls.GetComponent<Canvas> ().sortingOrder = 1;
//			Debug.Log("Cockpit camera And camcount::"+camCount);
			//Debug.Log ("cockpit person");
		} else if (StaticVAriables.mCamaraState == eCAMARA_TYPE.TopViewCamera) {
			Debug.Log ("Top view camera angle activated");
		}

		_ePreviousCamarastate = StaticVAriables.mCamaraState;
		//Debug.Log("My state==="+_ePreviousCamarastate);
		gParkPos.SetActive (false);

	}

	public void CamaraPOsition ()
	{
		gFPS = GameObject.FindWithTag ("gFPS");
		gTPS = GameObject.FindWithTag ("gTPS");
		gTopViewCamera = GameObject.FindWithTag ("TopViewCamera");
		go_Mirror = GameObject.FindWithTag ("gMirror");
		gParkPos = GameObject.FindWithTag ("PPC");
		gReverce = GameObject.FindWithTag ("RVC");

		//gTPS.transform.localPosition = transform.localPosition;
	}

	public void PAssengerEntryCamara ()
	{
		
	
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;

		//Debug.Log ("Parking camara");
		StaticVAriables.mCamaraState = eCAMARA_TYPE.Parking;
		gParkPos.SetActive (true);
		gPivot.transform.localPosition = gParkPos.transform.localPosition;
		gPivot.transform.localEulerAngles = gParkPos.transform.localEulerAngles;
		mscript_RCCref.canControl = false;
		UI_handlerScript.Instance.DisableControl ();
	}

	public void ResetCAmarapos ()
	{

		Debug.Log ("Current State:" + _ePreviousCamarastate);
		gParkPos.SetActive (false);
		if (_ePreviousCamarastate == eCAMARA_TYPE.Cockpit)
			StaticVAriables.mCamaraState = eCAMARA_TYPE.ThirdPerson;
		else
			StaticVAriables.mCamaraState = eCAMARA_TYPE.Cockpit;
		ChangeCamaraFunction ();
		//Debug.Log ("New State:"+StaticVAriables.mCamaraState);
		mscript_RCCref.canControl = true;
		UI_handlerScript.Instance.Enablecontrol ();

	}

	public void ReverseCamara ()
	{
		if (StaticVAriables.mCamaraState == eCAMARA_TYPE.Cockpit)
			return;

		StaticVAriables.mCamaraState = eCAMARA_TYPE.Reverse;
		gPivot.transform.localPosition = gReverce.transform.localPosition;
		gPivot.transform.localEulerAngles = gReverce.transform.localEulerAngles;

	}

	public void Frontcam ()
	{
		ChangeCamaraFunction ();
		UI_handlerScript.Instance.Enablecontrol ();
	}

	public void Resetcamaraposfordirve ()
	{
		if (StaticVAriables.mCamaraState == eCAMARA_TYPE.Cockpit)
			return;

		if (StaticVAriables.mCamaraState == eCAMARA_TYPE.Reverse)
		{
			gPivot.transform.localPosition = gTPS.transform.localPosition;
			gPivot.transform.localEulerAngles = gTPS.transform.localEulerAngles;
			StaticVAriables.mCamaraState = eCAMARA_TYPE.ThirdPerson;
		}

	}



     
}
