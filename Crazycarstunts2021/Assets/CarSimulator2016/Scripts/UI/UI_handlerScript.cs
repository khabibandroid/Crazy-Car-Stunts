using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_handlerScript : MonoBehaviour
{
	public static UI_handlerScript Instance;
	public Text GameplayTimer;
	public Text Gametask;
	private RCC_CarControllerV3 mscript_RCCref;
	private RCC_UIDashboardButton MyuibuttonScript;
	//AdmobAds amd;
	void Awake ()
	{
		//MyuibuttonScript= GameObject.FindGameObjectWithTag ("Gear").gameObject.GetComponent <RCC_UIDashboardButton>();
		//go_CarControls.GetComponent<Canvas>().enabled=false;
		//amd = this.GetComponent<AdmobAds>();
	}

	void Start ()
	{
		
		Instance = this;
		SetTaskMission ();
		//EnableHUDcomponents ();
		mscript_RCCref = LevelManagerScript.Instance._goPlayerCar.GetComponent <RCC_CarControllerV3> (); 
		//MyuibuttonScript= GameObject.FindGameObjectWithTag ("Gear").gameObject.GetComponent <RCC_UIDashboardButton>();
		ChangingDrivedotton ();

		Invoke ("OnShowInstruction", 0.2f);
		mfGamePlayTime = LevelManagerScript.GamePlayTimer;
		//Debug.Log ("Total time"+mfGamePlayTime);

	}
	public void menu()
    {
		Application.LoadLevel("Menu Scene");
	}

	public void OnButtonclick (string _btnName)
	{
//		if (_btnName == "Pause")
//		{
//
//			StaticVAriables.mGameState = eGAME_STATE.None;
//			Invoke ("OnPauseClick",0);
//		}

		if (_btnName == "Instruction") {
			StaticVAriables.mGameState = eGAME_STATE.None;
			Invoke ("OnShowInstruction", 0);

		}
//		else if(_btnName =="Drive")
//		{
//			MyuibuttonScript.ChangeGear (0);
//			ChangingDrivedotton ();
//
//
//		}
//		else if(_btnName =="Reverse")
//		{
//			//Debug.Log ("caling reverce");
//
//			MyuibuttonScript.ChangeGear (1);
//			ChangingReversebutton ();
//
//		}
		switch (StaticVAriables.mGameState) {
		case eGAME_STATE.GamePlay:
			if (_btnName == "Pause") {
				
				StaticVAriables.mGameState = eGAME_STATE.None;
				Invoke ("OnPauseClick", 0);
			} else if (_btnName == "Instruction") {
				StaticVAriables.mGameState = eGAME_STATE.None;
				Invoke ("OnShowInstruction", 0);
			} else if (_btnName == "Drive") {
				MyuibuttonScript.ChangeGear (0);
				ChangingDrivedotton ();
				CamaraSettings.Instance.Resetcamaraposfordirve ();
//				if(StaticVAriables.mCamaraState!=eCAMARA_TYPE.Cockpit)
//					CamaraSettings.Instance.go_Mirror.SetActive (false);
                

			} else if (_btnName == "Reverse") {
				Debug.Log ("caling reverce");
				MyuibuttonScript.ChangeGear (1);
				ChangingReversebutton ();
				//CamaraSettings.Instance.go_Mirror.SetActive (true);
				CamaraSettings.Instance.ReverseCamara ();
                
			}
			break;
		case eGAME_STATE .Pause:
			if (_btnName == "Resume") {
				StaticVAriables.mGameState = eGAME_STATE.None;
				Invoke ("OnResume", 0);
			} else if (_btnName == "Retry") {
				StaticVAriables.mGameState = eGAME_STATE.None;
				Invoke ("OnRetryClick", 0);
                   Application.LoadLevel("Village1");
                } else if (_btnName == "Home") {
				StaticVAriables.mGameState = eGAME_STATE.None;
				Invoke ("OnMenuClick", 0);
					// Application.LoadLevel("Menu Scene");
					//   StaticVAriables._SceneToLoad = "Menu Scene";
					//  SceneManager.LoadScene("Menu Scene");
					Application.LoadLevel("Menu Scene");
                } else if (_btnName == "SoundOn")
				{
				SoundOnbutton ();
                
			}
			break;
		case eGAME_STATE.LevelComplete:
			{
				if (_btnName == "Retry") {
					StaticVAriables.mGameState = eGAME_STATE.None;
					Invoke ("OnRetryClick", 0);
                        Application.LoadLevel("Village1");
                    } else if (_btnName == "Next") {
					StaticVAriables.mGameState = eGAME_STATE.None;
					Invoke ("OnNextLevelClick", 0);
				} else if (_btnName == "Home") {
					//StaticVAriables.mGameState = eGAME_STATE.None;
					Invoke ("OnMenuClick", 0);
						// StaticVAriables._SceneToLoad = "Menu Scene";
						SceneManager.LoadScene("Menu Scene");
						//   SceneManager.LoadScene("LoadingScene");

					}
			}
			break;
		case eGAME_STATE.LevelFailed:
			{
				if (_btnName == "Retry") {
					StaticVAriables.mGameState = eGAME_STATE.None;
                        Application.LoadLevel("Village1");

					Invoke ("OnRetryClick", 0);
				} else if (_btnName == "Home") {
				//	StaticVAriables.mGameState = eGAME_STATE.None;

					Invoke ("OnMenuClick", 0);
						  Application.LoadLevel("Menu Scene");
						//  StaticVAriables._SceneToLoad = "Menu Scene";
					//	SceneManager.LoadScene("Menu Scene");
						//   SceneManager.LoadScene("LoadingScene");


					}
			}
			break;
		case eGAME_STATE.Instruction:
			{
				if (_btnName == "Close") 
					{
					StaticVAriables.mGameState = eGAME_STATE.None;

					Invoke ("CloseInstruction", 0);
                    
                   }
			}
			break;
		case eGAME_STATE.Tutorial:
			{
				StaticVAriables.mGameState = eGAME_STATE.None;
                
			}
			break;
		}
	}



	#region HUD

	[Header ("In GAME HUD")]
	public GameObject go_HUDbuttons;
	public GameObject go_CarControls;
	public GameObject go_instruction;
	public GameObject go_tutorial;
	public GameObject go_AIfollowBar;
	public GameObject _goDrive, _goReverce;
	public Sprite SActivedrive, SActivereverse, SdisDrive, SdisReverse;

	public GameObject RedSignal, Greensignal;

	//public GameObject steering,acclerator,brake,gear;

	void DisableHUDcomponents ()
	{
		go_HUDbuttons.SetActive (false);
		go_CarControls.SetActive (false);
//		if(go_AIfollowBar.activeSelf)
		go_AIfollowBar.SetActive (false);
	}

	void EnableHUDcomponents ()
	{
		//Debug.Log (StaticVAriables.mGameState+"         "+StaticVAriables.mLevelstate);

		
		go_HUDbuttons.SetActive (true);
		go_CarControls.SetActive (true);
		go_CarControls.GetComponent<Canvas> ().enabled = true;

//		iTween.MoveTo (steering.transform.gameObject, iTween.Hash ("x",-412f,"islocal",true,"time",0f, "easetype", iTween.EaseType.linear));
//		iTween.MoveTo (acclerator.transform.gameObject, iTween.Hash ("x",-125f,"islocal",true,"time",0f, "easetype", iTween.EaseType.linear));
//		iTween.MoveTo (brake.transform.gameObject, iTween.Hash ("x",-346f,"islocal",true,"time",0f, "easetype", iTween.EaseType.linear));
//		iTween.MoveTo (gear.transform.gameObject, iTween.Hash ("x",-105.5f,"islocal",true,"time",0f, "easetype", iTween.EaseType.linear));
		//iTween.MoveTo (steering.transform.gameObject, iTween.Hash ("x",0,"y",0,"islocal",true,"time",0f, "easetype", iTween.EaseType.linear));

		if (StaticVAriables.mLevelstate != eLEVEL_TYPE.Tailing) {
			go_AIfollowBar.SetActive (false);
		} else {
			//Debug.Log ("Tailing Assign");
			go_AIfollowBar.SetActive (true);
			LevelManagerScript.Instance._goPlayerCar.GetComponent<AI_Followrscript> ().InitializeItems ();
		}

	}

	public void SetTaskMission ()
	{
		Gametask.text = "" + LevelManagerScript.Instance.GetTargetText ();
	}

	void OnShowInstruction ()
	{
		StaticVAriables.mGameState = eGAME_STATE.None;
		DisableHUDcomponents ();

		go_instruction.SetActive (true);
		mscript_RCCref.canControl = false;
		StartCoroutine (go_instruction.GetComponent <PopUpAnimationEffects> ().OnEntryAnimation (eGAME_STATE.Instruction));
		LevelManagerScript.Instance.AIcarStateChange ();

	}

	void CloseInstruction ()
	{
		StartCoroutine (go_instruction.GetComponent<PopUpAnimationEffects> ().OnExitAnimation ());
		StaticVAriables.mGameState = eGAME_STATE.None;
		if (PlayerPrefs.HasKey ("Tutorial")) {
			Invoke ("ChangeState", 0);
			Invoke ("EnableHUDcomponents", 0.2f);
			//Debug.Log ("gameplay");
		} else {
			//ShowTutorial ();
			Invoke ("ShowTutorial", 0.4f);
		}
	}




	/// <summary>
	/// show tutorial pages
	/// </summary>




	public void SetuiSignal (bool val)
	{
		if (val) {
			RedSignal.SetActive (false);
			Greensignal.SetActive (true);
		} else {
			RedSignal.SetActive (true);
			Greensignal.SetActive (false);
		}
	}

	public void deacivateSignal ()
	{
		RedSignal.SetActive (false);
		Greensignal.SetActive (false);


	}

	#endregion

	#region TUTORIAL

	void ShowTutorial ()
	{
		StaticVAriables.mGameState = eGAME_STATE.None;
		go_tutorial.SetActive (true);
		//StartCoroutine (go_tutorial.GetComponent <PopUpAnimationEffects>().OnEntryAnimation (eGAME_STATE.Tutorial));
		Invoke ("EnableHUDcomponents", 0.2f);

	}

	public void CloseTutorial ()
	{
		PlayerPrefs.SetInt ("Tutorial", 1);
		StartCoroutine (go_tutorial.GetComponent<PopUpAnimationEffects> ().OnExitAnimation ());
		StaticVAriables.mGameState = eGAME_STATE.None;

		Invoke ("ChangeState", 0);
		//Invoke ("EnableHUDcomponents",0.2f);
	}

	#endregion


	/////****PAUSE STATE*****/////////


	#region PAUSE
	[Header ("Pause component:")]
	public GameObject _goPause;
	private int min = 0;
	private int sec = 0;
	public GameObject _SoundOn;
	public Sprite[] soundButton;

	void OnPauseClick ()
	{
		DisableHUDcomponents ();
		_goPause.SetActive (true);
		mscript_RCCref.canControl = false;
		//go_CarControls.SetActive (false);
		StartCoroutine (_goPause.GetComponent <PopUpAnimationEffects> ().OnEntryAnimation (eGAME_STATE.Pause));
		LevelManagerScript.Instance.AIcarStateChange ();
		SoundOnbutton ();

	}

	void OnclosePause ()
	{
		//EnableHUDcomponents ();
		StartCoroutine (_goPause.GetComponent<PopUpAnimationEffects> ().OnExitAnimation ());

	}

	void OnResume ()
	{
		OnclosePause ();
		StaticVAriables.mGameState = eGAME_STATE.None;
		Invoke ("EnableHUDcomponents", 0);
		Invoke ("ChangeState", 0);

	}

	void ChangeState ()
	{
		StaticVAriables.mGameState = eGAME_STATE.GamePlay;
		mscript_RCCref.canControl = true;
		LevelManagerScript.Instance.AIcarStateChange ();
	}

	void Update ()
	{
		//GameplayTimer.text = "00:"+LevelManagerScript.GamePlayTimer.ToString ("00");
		//GameplayTimer.text = Mathf.Floor (LevelManagerScript.GamePlayTimer / 60).ToString ("0");
		if (LevelManagerScript.GamePlayTimer > 0) {
			//TimerTimeInSec-= Time.deltaTime;
			min	= Mathf.CeilToInt (LevelManagerScript.GamePlayTimer) / 60;
			sec	= Mathf.CeilToInt (LevelManagerScript.GamePlayTimer) % 60;
			GameplayTimer.text = "" + min.ToString ("00") + ":" + sec.ToString ("00");
            
               




		}

	}

	int sound = 0;

	void SoundOnbutton ()
	{
		if (sound == 0) {
			_SoundOn.GetComponent<Image> ().sprite = soundButton [0];
			sound = 1;
		} else {
			sound = 0;
			_SoundOn.GetComponent<Image> ().sprite = soundButton [1];

		}
		
	}

	#endregion

	////*****LEVEL FAILED*****/////

	#region Level Failed
	[Header ("Level faild components")]
	public GameObject _goLevelfailed;
	private float mfGamePlayTime;
	public GameObject mg_LifeObj;

	public void Call_AddLife ()
	{
		//mg_LifeObj.SetActive (true);
		ShowLevelFailed();
		Invoke ("StopTime", 0.5f);
//		DisableHUDcomponents ();

	}

	void StopTime()
	{
		Time.timeScale = 0;
	    
	}
	public void OnBtn_Click (string BtnName)
	{
		switch (BtnName) {
		case "Close":
			mg_LifeObj.SetActive (false);
			Time.timeScale = 1;
			ShowLevelFailed ();
				//	amd.showVideoAd();
		//	Admanager.instance.ShowFullScreenAd();
				Debug.Log("ads working");
				break;
		case "Continue":

				 //	Admanager.instance.ShowRewardedAd();    
				//GoogleMobileAdsDemoScript.myScript.SelectedRewardVideoType = 1;
				//	amd.showVideoAd();
				//	GoogleMobileAdsDemoScript.myScript.ShowRewardBasedVideo ();
				//venkat

			//	ResetAfterVidoe();
				
				//	LevelManagerScript.Instance.Call_AddLifeAfterVideoSuccess ();  //venkat
				//   mg_LifeObj.SetActive(false);

				break;
		}
	}
    
    

	public void ShowLevelFailed ()
	{
		AchivementHandlerScript._ThreeStarCount = 0;
		mg_LifeObj.SetActive (false);
		if (StaticVAriables.mGameState != eGAME_STATE.LevelFailed) 
		{
			LevelManagerScript.Instance.AIcarStateChange ();
			StaticVAriables.mGameState = eGAME_STATE.None;
			mscript_RCCref.canControl = false;
			_goLevelfailed.SetActive (true);
			StartCoroutine (_goLevelfailed.GetComponent<PopUpAnimationEffects> ().OnEntryAnimation (eGAME_STATE.LevelFailed));
			//amd.showVideoAd();

			Debug.Log ("Level failed");
			DisableHUDcomponents ();
	//	Admanager.instance.ShowFullScreenAd();
      


			if (StaticVAriables.LevelfailedCount < 6) {
				StaticVAriables.LevelfailedCount += 1;
				if (StaticVAriables.LevelfailedCount >= 5) {
				//	NativePopUp.myScript.UnLockAllLevels ();
					StaticVAriables.LevelfailedCount = 0;
				}
			}
			//if (AdsManager.myScript != null) {
			//	AdsManager.myScript.LevelFailAd (StaticVAriables._iCurrentLevel);
			//}
			//amd.ShowInterstitialAd();
			SoundManager.staticscript_soundMgr.LevelFail ();
		}
//		Debug.Log ("levelfailed count" + StaticVAriables.LevelfailedCount);
	}

	#endregion

	/////*******LEVEL COMPLETED***********////

	#region Level Completed
	[Header ("Level completed components")]
	public GameObject go_Levelcompleted;
	public Text mtMyscore;
	public Text mtBestScore;
	public GameObject _goStar1, _goStar2, _goStar3;

	public void EnanbleLEvelCompleted ()
	{
		//Debug.Log ("LEvel complete;;");
		StaticVAriables.mGameState = eGAME_STATE.None;
		mscript_RCCref.canControl = false;
		Invoke ("ShowLevelcompleted", 2);

	}

	void ShowLevelcompleted ()
	{
		go_Levelcompleted.SetActive ((true));
		StartCoroutine (go_Levelcompleted.GetComponent<PopUpAnimationEffects> ().OnEntryAnimation (eGAME_STATE.LevelComplete));
		DisableHUDcomponents ();
		ShowScore ();
		ShowStarAndScore ();

		LevelManagerScript.Instance.AIcarStateChange ();
		SoundManager.staticscript_soundMgr.LevelWin ();
	//	amd.showVideoAd();
		Debug.Log("levelcompletead");
	//	Admanager.instance.ShowFullScreenAd();
	}

	void OnNextLevelClick ()
	{
		if (StaticVAriables._iCurrentLevel < 25)
			StaticVAriables._iCurrentLevel++;

		StaticVAriables._SceneToLoad = "LevelSelection";
		SceneManager.LoadScene ("LoadingScene");

	}

	void ShowStarAndScore ()
	{
		if (StaticVAriables._iStarNo == 3) {
			AchivementHandlerScript._ThreeStarCount++;
//			_goStar1.SetActive (true);
//			_goStar2.SetActive (true);
//			_goStar3.SetActive (true);

			if (StaticVAriables._iCurrentLevel == 25)
				AchivementHandlerScript.Instance.ThreeStarOnLastLevel ();

		} else if (StaticVAriables._iStarNo == 2) {
			AchivementHandlerScript._ThreeStarCount = 0;
//			_goStar1.SetActive (true);
//			_goStar2.SetActive (true);
//			_goStar3.SetActive (false);
		} else if (StaticVAriables._iStarNo == 1) {
			AchivementHandlerScript._ThreeStarCount = 0;
//			_goStar1.SetActive (true);
//			_goStar2.SetActive (false);
//			_goStar3.SetActive (false);
		}

		if (AchivementHandlerScript.Instance)
			AchivementHandlerScript.Instance.ThreeStarContinuesly ();
		    
	}

	void ShowScore ()
	{
		//print ("calling");
		mtMyscore.text = StaticVAriables._iScore.ToString ();
		mtBestScore.text = StaticVAriables.iBestScore.ToString ();

	}

	#endregion

	///////////*************************COMMON BUTTON***********************////////////

	void OnRetryClick ()
	{
		SceneManager.LoadScene ("LoadingScene");
		//mscript_RCCref.canControl = ture;

	}

	void OnMenuClick ()
	{
		StaticVAriables._SceneToLoad = "Menu";
		SceneManager.LoadScene ("LoadingScene");

	}

	void ChangingDrivedotton ()
	{
		_goDrive.GetComponent<Image> ().sprite = SActivedrive;
		_goReverce.GetComponent<Image> ().sprite = SdisReverse;
         
	}

	void ChangingReversebutton ()
	{
		 Debug.Log ("calling");
		_goDrive.GetComponent<Image> ().sprite = SdisDrive;
		_goReverce.GetComponent<Image> ().sprite = SActivereverse;
         

	}

	public void Enablecontrol ()
	{
		go_CarControls.SetActive (true);

	}


	public void DisableControl ()
	{
		go_CarControls.SetActive (false);
	}

	public void ResetAfterVidoe ()
	{
		mg_LifeObj.SetActive (false);  //venkat
		LevelManagerScript.Instance.Call_AddLifeAfterVideoSuccess ();  //venkat

	}
}
