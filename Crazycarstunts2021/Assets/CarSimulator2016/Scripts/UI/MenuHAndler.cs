using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Prime31;


public class MenuHAndler : MonoBehaviour
{
	public static MenuHAndler Instance;
	[Header ("DELETE ALL PLAYER PREFERENCE")]
	public  bool DELETE_ALL_SAVED_DATA = false;

	void Awake ()
	{
//		if (DELETE_ALL_SAVED_DATA)
//			PlayerPrefs.DeleteAll ();
		StaticVAriables.mCurrentScene = eSCENE_STATE.Menu;// changed for   game play
		StaticVAriables.mMenuState = eMENU_STATE.Menu;
		Instance = this;


		Input.multiTouchEnabled = true;
		ShowMenupage ();

	
	}

	public GameObject Btn_Sign;
	public Sprite[] SignTex;

	public Text[] InAppTexts;

	void Start ()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//		if (AdsManager.myScript != null)
		//		{
		//			for (int i = 0; i < InAppTexts.Length; i++)
		//			{
		//				InAppTexts [i].text = PlayerPrefs.GetString (InAppPurchaseManager.allSkus [i], "Buy");
		//			}

		//			AdsManager.myScript.MenuAd (StaticVAriables._iCurrentLevel);
		//			AdsManager.ShowGPlusBtn ();
		//			//Invoke ("FirstTimeAuthentication", 1.5f);
		////			Invoke ("CheckSignInDelay", 3);
		//		}
		HideBuyButtons ();
	}

	void FirstTimeAuthentication ()
	{
		//AdsManager.myScript.GP_Authentication ();
	}

	//void CheckSignInDelay ()
	//{
	//	if (GameConfigs2015.CSignIn)
	//	{
	//		Btn_Sign.GetComponent<Image> ().sprite = SignTex [1];// SING OUT
	//	} else
	//	{
	//		Btn_Sign.GetComponent<Image> ().sprite = SignTex [0];// SIGN IN
	//	}
	//	Invoke ("CheckSignInText", 4);
	//}

	//public void CheckSignInText ()
	//{
	//	if (PlayGameServices.isSignedIn ())
	//	{
	//		Btn_Sign.GetComponent<Image> ().sprite = SignTex [1];// SING OUT
	//	} else
	//	{
	//		Btn_Sign.GetComponent<Image> ().sprite = SignTex [0];// SIGN IN
	//	}
	//}

	public void Onbuttonclick (string _btnName)
	{
		
		switch (StaticVAriables.mMenuState)
		{
		case eMENU_STATE.Menu:
			{
				if (_btnName == "Play")
				{
					StaticVAriables.mMenuState = eMENU_STATE.None;
					OnPLayclick ();
				} else if (_btnName == "Settings")
				{
					StaticVAriables.mMenuState = eMENU_STATE.None;
					Invoke ("CloseMenupage", StaticVAriables._FbuttonClickDelay);
					Invoke ("ShowSettingsPage", 1);
				} else if (_btnName == "More")
				{
                
				} else if (_btnName == "Store")
				{
					StaticVAriables.mMenuState = eMENU_STATE.None;
					Invoke ("CloseMenupage", StaticVAriables._FbuttonClickDelay);
					Invoke ("ShowStorePage", 1);
				}
                    else if (_btnName == "LeaderBoard")

				{
                     
				}
                    else if (_btnName == "Achivement")
				{

				}
                    else if (_btnName == "SignIn")
				{
                  
				}
			}
			break;
		case eMENU_STATE.Settings:
			{
				if (_btnName == "Home")
				{
					StaticVAriables.mMenuState = eMENU_STATE.None;
					Invoke ("OnHomeClick", StaticVAriables._FbuttonClickDelay); 
				}
                    else if (_btnName == "More")
				{

				}
                    else if (_btnName == "SoundOn")
				{
					soundButtonFunction ();
                    

				}

			}

			break;
		case eMENU_STATE.Store:
			{
				if (_btnName == "Home")
				{
					StaticVAriables.mMenuState = eMENU_STATE.None;
					Invoke ("CloseStorePage", StaticVAriables._FbuttonClickDelay); 
				} else if (_btnName == "UnlockCar")
				{

				} else if (_btnName == "UnlockAll")
				{

				} else if (_btnName == "UnLockLevel")
				{

				} else if (_btnName == "More")
				{

				}

			}

			break;
		}
	}

	void OnEnable ()
	{
		if (Instance == null)
			Instance = this;
	}

	public void moregames()
	{
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Mortal+Games");
	}

	public void rateus()
    {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.MortalGames.impossiblecrazycarstunts2021");
	}
    public void Quit1()
    {
		Application.Quit();
	}

    void OnDisable ()
	{
		if (Instance != null)
			Instance = null;
	}

	///////**********Menu Items********///////


	#region MENU Items
	[Header ("Menu items")]
	public GameObject _goMenuPage;

	void ShowMenupage ()
	{
		_goMenuPage.SetActive (true);
		StartCoroutine (_goMenuPage.GetComponent<MenuPopupAnimationEffect> ().OnEntryAnimation (eMENU_STATE.Menu));
	}

	void CloseMenupage ()
	{
		StartCoroutine (_goMenuPage.GetComponent<MenuPopupAnimationEffect> ().OnExitAnimation ());

	}

	void OnLeaderBoardClick ()
	{
		Debug.Log ("LeaderBoard");

	}

	void OnAchivementClick ()
	{
		Debug.Log ("Achivement");

	}

	void OnsignInClick ()
	{
		Debug.Log ("Signin");

	}

	void OnPLayclick ()
	{
		StaticVAriables._SceneToLoad = "LevelSelection";
		SceneManager.LoadScene ("LoadingScene");

	}

	#endregion

	#region STORE items

	[Header ("Store Items")]

	public GameObject _GoStorePage;
	public GameObject _goAllLevel, _goAllCar, _goBoth;

	void ShowStorePage ()
	{
		StaticVAriables.mMenuState = eMENU_STATE.None;
		_GoStorePage.SetActive (true);
		StartCoroutine (_GoStorePage.GetComponent<MenuPopupAnimationEffect> ().OnEntryAnimation (eMENU_STATE.Store)); 
	}

	void CloseStorePage ()
	{
		StartCoroutine (_GoStorePage.GetComponent <MenuPopupAnimationEffect> ().OnExitAnimation ());
		Invoke ("ShowMenupage", 0.75f);

	}

	void HideBuyButtons ()
	{
		if (PlayerPrefs.GetInt ("UnlockedCar") >= 5)
		{
			_goAllCar.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("UnlockedLevels") >= 25)
		{
			_goAllLevel.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("UnlockedCar") >= 5 && PlayerPrefs.GetInt ("UnlockedLevels") >= 25)
		{
			_goBoth.SetActive (false);

		}
	}

	#endregion;

	#region Settings  items

	[Header ("SETTINGS")]

	public GameObject _goSettings;
	public GameObject _goSoundOn;
	public Sprite[] Soundbuttons;

	void ShowSettingsPage ()
	{
		StaticVAriables.mMenuState = eMENU_STATE.None;
		_goSettings.SetActive (true);
		StartCoroutine (_goSettings.GetComponent <MenuPopupAnimationEffect> ().OnEntryAnimation (eMENU_STATE.Settings));
		soundButtonFunction ();

	}

	void CloseSettingsPage ()
	{
		StartCoroutine (_goSettings.GetComponent <MenuPopupAnimationEffect> ().OnExitAnimation ()); 

	    
	}

	void OnHomeClick ()
	{
		CloseSettingsPage ();
		Invoke ("ShowMenupage", 0.75f);

	}

	public void ShareBtnClicked()
	{
		Debug.Log ("Share btn clicked");
		//gameConfigs.NativeShare ();
        
	}

	#endregion



	#region Common functions

	int sound = 0;

	void soundButtonFunction ()
	{
		if (sound == 0)
		{
			_goSoundOn.GetComponent<Image> ().sprite = Soundbuttons [1];
			sound = 1;
		} else
		{
			_goSoundOn.GetComponent<Image> ().sprite = Soundbuttons [0];
			sound = 0;

		}
	}



	#endregion


}
