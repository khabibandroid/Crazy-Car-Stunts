using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelSelectionHandler : MonoBehaviour
{
	public static LevelSelectionHandler Instance = null;
	eMENU_STATE _previousState = eMENU_STATE.None;
	public List<int> City1 = new List<int> ();
	public List<int> Village1 = new List<int> ();

	public GameObject unloclllvlpopup;
	public Text lvlinapp;
	public GameObject unlocllcarspopup;
	public Text carsinapp;


	void Awake ()
	{
		Instance = this;
		StaticVAriables.mCurrentScene = eSCENE_STATE.CarSelection;
	}

	void Start ()
	{
		ShowLevelSelectionPage ();
		SoundManager.staticscript_soundMgr.SelectionPage ();
		HideUnlockButton ();
		if (AchivementHandlerScript.Instance) {
			AchivementHandlerScript.Instance.UnLockAllLevels ();
			AchivementHandlerScript.Instance.UnlockFifithLevel ();
			AchivementHandlerScript.Instance.UnlockTwelthLevel ();
			AchivementHandlerScript.Instance.UnlockTwentythLevel ();

		}



		/*if (StaticVAriables.carSelectioncount < 7 && PlayerPrefs.GetInt ("UnlockedLevels") <= 24){
			//StaticVAriables.carSelectioncount++;
			if (StaticVAriables.carSelectioncount == 6) {
				//print (StaticVAriables.carSelectioncount + "StaticVAriables.carSelectioncount");
				StaticVAriables.carSelectioncount = 0;
				unloclllvlpopup.SetActive(true);
				lvlinapp.text = PlayerPrefs.GetString (InAppPurchaseManager.allSkus [2], "Buy");
			}
		}*/



	}

	void OnEnable ()
	{
		if (Instance == null) {
			Instance = this;

		}

	}

	void OnDisable ()
	{
		if (Instance != null)
			Instance = null;
	}

	public void OnButtonClick (string _btnName)
	{
		switch (StaticVAriables.mMenuState) {
		case eMENU_STATE.LevelSelection:
			if (_btnName == "Home") {
                   // Application.LoadLevel("Menu Scene");

				StaticVAriables.mMenuState = eMENU_STATE.None;
				OnMenuClick ();
			} else if (_btnName == "UnlockLevels") {
//				Debug.Log ("UNlocked all levels");
			//	PlayerPrefs.SetInt ("UnlockedLevels", 25);
				LevelUnlockSystem.Instance.SetUnlockedLevels ();
			} else if (_btnName == "More") {

				StaticVAriables.mMenuState = eMENU_STATE.None;
			} else if (_btnName == "Play") {

				StaticVAriables.mMenuState = eMENU_STATE.None;
				Invoke ("OnSelectedLevel", 0);
			}
			break;
		case eMENU_STATE.CarSelection:
			if (_btnName == "Back") {

				StaticVAriables.mMenuState = eMENU_STATE.None;
				CloseCarSelcectionPage ();
				ShowLevelSelectionPage ();
			} else if (_btnName == "Home") {

				StaticVAriables.mMenuState = eMENU_STATE.None;
				OnMenuClick ();
			} else if (_btnName == "Unlockcar") {
				//StaticVAriables.mMenuState = eMENU_STATE.None;
//				Debug.Log ("UNlocked all levels");
				PlayerPrefs.SetInt ("UnlockedCar",5);
				CarSelectionHandler.Instance.SetcarlockSysyetm ();
			} else if (_btnName == "More") {

				StaticVAriables.mMenuState = eMENU_STATE.None;
			}
			break;
		}
		
	}



	#region Level Selection

	[Header ("Level Selection")]

	public GameObject _goLevelSelction;
	public GameObject _goUnlockAllLevelButton;

	public void EnableLevelSelection ()
	{
		Invoke ("ShowLevelSelsctionPage", 1.0f);
        

	}

	public void ShowLevelSelectionPage ()
	{
		_goLevelSelction.SetActive (true);
		StartCoroutine (_goLevelSelction.GetComponent <MenuPopupAnimationEffect> ().OnEntryAnimation (eMENU_STATE.LevelSelection));

		if (StaticVAriables.carSelectioncount < 6 && PlayerPrefs.GetInt ("UnlockedLevels") <= 24){
			//StaticVAriables.carSelectioncount++;
			if (StaticVAriables.carSelectioncount == 5) {
				//print (StaticVAriables.carSelectioncount + "StaticVAriables.carSelectioncount");
				StaticVAriables.carSelectioncount = 0;
				unloclllvlpopup.SetActive(true);
                //lvlinapp.text = PlayerPrefs.GetString (InAppPurchaseManager.allSkus [0], "Buy");
               
			}
		}

	}

	public void CloseLevelSelectionPage ()
	{
		StartCoroutine (_goLevelSelction.GetComponent<MenuPopupAnimationEffect> ().OnExitAnimation ());
        
	}


	void OnSelectedLevel ()
	{


		StaticVAriables.mMenuState = eMENU_STATE.None;
		LevelSelectionHandler.Instance.CloseLevelSelectionPage ();
		LevelSelectionHandler.Instance.EnableCarSelection ();
		//Debug.Log (Scenetoload);
	}

	#endregion



	#region  Car Selection

	[Header ("Car Selection")]

	public GameObject _goCarSElection;
	public GameObject _gocar;
	public GameObject _goUnlockAllCarButton;

	public void EnableCarSelection ()
	{
		Invoke ("ShowCarSelection", 0.1f);
		if (AchivementHandlerScript.Instance) {
			AchivementHandlerScript.Instance.ThirdCarUnlock ();
			AchivementHandlerScript.Instance.UnLockAllcar ();
		}
	}

	public void CloseCarSelcectionPage ()
	{
		StartCoroutine (_goCarSElection.GetComponent <MenuPopupAnimationEffect> ().OnExitAnimation ());
		_gocar.SetActive (false);

	}

	void ShowCarSelection ()
	{
		_goCarSElection.SetActive (true);
		_gocar.SetActive (true);
		StartCoroutine (_goCarSElection.GetComponent <MenuPopupAnimationEffect> ().OnEntryAnimation (eMENU_STATE.CarSelection));

	}

	#endregion;

	public void OnPlayClick ()
	{
		SceneManager.LoadScene ("LoadingScene");
	}

	string Scenetoload;

	public void SceneSelectionToLoad (int val)
	{
		StaticVAriables._iCurrentLevel = val;
		for (int i = 0; i < City1.Count; i++) {
			if (City1 [i] == val) {
				Scenetoload = "Village" + StaticVAriables._iCurrentWorld;
//				StaticVAriables._iCurrentLevel = i;
			}
		}
		for (int i = 0; i < Village1.Count; i++) {
			if (Village1 [i] == val) {
				Scenetoload = "City" + StaticVAriables._iCurrentWorld;
//				StaticVAriables._iCurrentLevel = i;
                

			}
		}
			
		StaticVAriables._SceneToLoad = Scenetoload;

	}

	public void OnMenuClick ()
	{
		StaticVAriables._SceneToLoad = "Menu Scene";
		SceneManager.LoadScene ("LoadingScene");

	}

	void HideUnlockButton ()
	{
		if (PlayerPrefs.GetInt ("UnlockedCar") >= 5) {
			_goUnlockAllCarButton.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("UnlockedLevels") >= 25) {
			_goUnlockAllLevelButton.SetActive (false);
             


		}
	}


	public void closelvlpopup(){
		unloclllvlpopup.SetActive(false);

	}

	public void buyalllvls(){
		//GoogleIAB.purchaseProduct (InAppPurchaseManager.allSkus [0]);
		//AdsManager.myScript.UnlockAll_GunsnLevels();
		unloclllvlpopup.SetActive(false);
	}
}
