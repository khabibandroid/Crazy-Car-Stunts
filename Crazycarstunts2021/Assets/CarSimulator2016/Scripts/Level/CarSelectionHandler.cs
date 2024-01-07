using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CarSelectionHandler : MonoBehaviour
{
	public static CarSelectionHandler Instance = null;

	public GameObject _goCarstart, _gocarEndpos;
	public GameObject _goText;

	private bool mbRotate = false;
	int MYcarNo = 0;



	public static string[] UNLOCKALLCARS = new string[5]{ "c1", "c2", "c3", "c4", "c5" };
	private static string[] carsunlock = new string[5]{ "Unlock", "Lock", "Lock", "Lock", "Lock" };

	public bool caractivepage = false;
	void Awake ()
	{

		_Nextbutton.SetActive (true);
		_PrevButton.SetActive (false);
		Instance = this;
		SetCarvisible ();
		ActiveButton ();
		SetbuttonVisible ();
//		Selectioncar ();


	}

	void Start ()
	{
		/*if (StaticVAriables.carSelectioncount < 4) {
			StaticVAriables.carSelectioncount++;
			if (StaticVAriables.carSelectioncount >= 3) {
				NativePopUp.myScript.UnLockAllTrains ();
				print (StaticVAriables.carSelectioncount + "StaticVAriables.carSelectioncount");
				//StaticVAriables.LevelfailedCount = 0;
				StaticVAriables.carSelectioncount = 0;
			}
		}*/
		//PlayerPrefs.SetInt("UnlockedCar", 5);


		for (int i = 0; i < UNLOCKALLCARS.Length; i++) {
		
			if (PlayerPrefs.HasKey (UNLOCKALLCARS [i]) == false) {
				PlayerPrefs.SetString (UNLOCKALLCARS [i], carsunlock [i]);
			} else {
				carsunlock [i] = PlayerPrefs.GetString (UNLOCKALLCARS [i]);
			}
		}

		if (PlayerPrefs.HasKey (StaticVAriables.unlockcarscount) == false) {
			PlayerPrefs.SetInt (StaticVAriables.unlockcarscount, 1);
		}
		if (!PlayerPrefs.HasKey ("UnlockedCar")) {
			PlayerPrefs.SetInt ("UnlockedCar", 1);
		}
		Setupcarcenter ();
		SetcarlockSysyetm ();
		//Debug.Log ("my car" + PlayerPrefs.GetInt ("UnlockedCar"));
		//textfadeinfadeout ();

		CheckForVideoAvailablity ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Roatatecar ();
	}

	public void Onbuttonclick (string _btnName)
	{

		switch (StaticVAriables.mMenuState) {
		case eMENU_STATE.CarSelection:
			{
				if (_btnName == "Next") {
					
					Nextbutton ();

				} else if (_btnName == "Previous") {
					
					PreviousButton ();

				} else if (_btnName == "Play") {
						print ("play");
					StaticVAriables.mGameState = eGAME_STATE.None;
					LevelSelectionHandler.Instance.OnPlayClick ();
                    
				}
			}
			break;
		}
	}

	[Header ("CAR :")]


	public GameObject _PlayButton, _PrevButton, _Nextbutton;
	public  GameObject[] Mycars;
	public GameObject[] MySpec;

	public GameObject _McarParent;
	public Text DisplayText;
//	public GameObject _Textpanel;
	//public GameObject _goPlayButton;


	public GameObject _goNextbutton, _goPreviousButton;



	void SetCarvisible ()
	{
		for (int i = 0; i < Mycars.Length; i++) {
			//Mycars [i].SetActive (false);
			MySpec [i].SetActive (false);
		}
//		Mycars [MYcarNo].SetActive (true);
		MySpec [MYcarNo].SetActive (true);
		StaticVAriables._icurrentCar = MYcarNo;
		//SetbuttonVisible ();

	}

	void Selectioncar ()
	{
		HideButton ();
		float posX = 7;

		for (int i = 0; i < Mycars.Length; i++) {
			GameObject _obj = Mycars [i];
			if (i == (StaticVAriables._icurrentCar)) {
				iTween.MoveTo (_obj, iTween.Hash ("x", 0f, "time", 0.8f, "easetype", iTween.EaseType.linear, "islocal", true, "oncomplete", "ActiveButton", "oncompletetarget", gameObject));
			} else if (i < (StaticVAriables._icurrentCar)) {

				iTween.MoveTo (_obj, iTween.Hash ("x", -posX, "time", 0.8f, "easetype", iTween.EaseType.linear, "islocal", true, "oncomplete", "ActiveButton", "oncompletetarget", gameObject));
			} else {
				iTween.MoveTo (_obj, iTween.Hash ("x", posX, "time", 0.8f, "easetype", iTween.EaseType.linear, "islocal", true, "oncomplete", "ActiveButton", "oncompletetarget", gameObject));

			}
		}

		SetbuttonVisible ();
	}

	void HideButton ()
	{
		_goNextbutton.GetComponent<Button> ().interactable = false;
		_goPreviousButton.GetComponent<Button> ().interactable = false;
		mbRotate = false;

	}

	void ActiveButton ()
	{
		_goNextbutton.GetComponent<Button> ().interactable = true;
		_goPreviousButton.GetComponent<Button> ().interactable = true;
		mbRotate = true;

	}

	void Roatatecar ()
	{
		if (mbRotate) {
			Mycars [StaticVAriables._icurrentCar].transform.Rotate (0, -0.5f, 0, Space.Self);
		} else {
			for (int i = 0; i < Mycars.Length; i++) {
				//Mycars [i].SetActive (false);
				Mycars [i].transform.localEulerAngles = new Vector3 (0, 270f, 0);
			}
		}
		//Mycars [StaticVAriables._icurrentCar].transform.localEulerAngles = new Vector3 (0, 270f, 0);
	}


	void Setupcarcenter ()
	{
		float posX = 7;
		StaticVAriables._icurrentCar = PlayerPrefs.GetInt ("UnlockedCar") - 1;
		MYcarNo = StaticVAriables._icurrentCar;


		/*for (int i = 0; i < UNLOCKALLCARS.Length; i++) {
			if (PlayerPrefs.GetString (UNLOCKALLCARS [i]) == "Unlock") {
				GameObject _obj = Mycars [i];
				if (i == MYcarNo && PlayerPrefs.GetString (UNLOCKALLCARS [i]) == "Unlock") {
					_obj.transform.localPosition	= new Vector3 (0, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
				} else if (i < (PlayerPrefs.GetInt ("UnlockedCar") - 1)) {
					_obj.transform.localPosition	= new Vector3 (-posX, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
				} else {
					_obj.transform.localPosition	= new Vector3 (posX, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
					//				iTween.MoveTo(_obj, iTween.Hash("x",posX, "time", 0.8f, "easetype", iTween.EaseType.linear, "islocal", true,"oncomplete","ActiveButton","oncompletetarget",gameObject));

				}
			}
		}*/

	
	
		Debug.Log ("UNLOCK :" + PlayerPrefs.GetInt ("UnlockedCar"));
		for (int i = 0; i < Mycars.Length; i++)
        {
			GameObject _obj = Mycars [i];
			if (i == (PlayerPrefs.GetInt ("UnlockedCar") - 1) && PlayerPrefs.GetString (UNLOCKALLCARS [i]) == "Unlock") {
				_obj.transform.localPosition	= new Vector3 (0, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
			} else if (i < (PlayerPrefs.GetInt ("UnlockedCar") - 1))
            {
				_obj.transform.localPosition	= new Vector3 (-posX, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
			}
            else
            {
				_obj.transform.localPosition	= new Vector3 (posX, _obj.transform.localPosition.y, _obj.transform.localPosition.z);
				iTween.MoveTo (_obj, iTween.Hash ("x", posX, "time", 0.8f, "easetype", iTween.EaseType.linear, "islocal", true, "oncomplete", "ActiveButton", "oncompletetarget", gameObject));
                
			}
		}

		SetbuttonVisible ();

	}

	void Nextbutton ()
	{
		if (MYcarNo < Mycars.Length - 1)
        {
			MYcarNo++;
		}
		SetcarlockSysyetm ();
		SetCarvisible ();
		Selectioncar ();
        
	}

	void PreviousButton ()
	{
		if (MYcarNo > 0)
        {
			MYcarNo--;
		}
		SetcarlockSysyetm ();
		SetCarvisible ();
		Selectioncar ();

	}

	void SetbuttonVisible ()
	{
		if (MYcarNo > 0)
        {
			_PrevButton.SetActive (true);

		} else
			_PrevButton.SetActive (false);

		if (MYcarNo < Mycars.Length - 1)
			_Nextbutton.SetActive (true);
		else
			_Nextbutton.SetActive (false);

			
	}

	public GameObject mg_Btn_5Videos,mg_Btn_10Videos;
	public GameObject Car2_shareBtn,Car3_shareBtn, Car4_shareBtn,Car5_shareBtn;
	public void SetcarlockSysyetm ()
	{

		string SDisplay = "";
		for (int i = 0; i < Mycars.Length; i++)
        {
//			if (i < PlayerPrefs.GetInt ("UnlockedCar") ) {
			if (PlayerPrefs.GetString (UNLOCKALLCARS [i]) == "Unlock")
            {
				//_McarParent.GetComponent<BoxCollider>().enabled=true;
				//Debug.Log ("Car unlocked" + Mycars [i].name);
				_PlayButton.SetActive (true);
//				_Textpanel.SetActive (false);
				//mg_Btn_5Videos.SetActive (false);
				//mg_Btn_10Videos.SetActive(false);
				Car2_shareBtn.SetActive (false);
				Car3_shareBtn.SetActive (false);
				Car4_shareBtn.SetActive (false);
				Car5_shareBtn.SetActive (false);

				DisplayText.text = "";
			}
            else
            {
				
				//Debug.Log ("Car Locked" + Mycars [i].name);
//				if (MYcarNo == 1 && PlayerPrefs.GetInt ("UnlockedCar") < 2) {
				if (MYcarNo == 1 && PlayerPrefs.GetString (UNLOCKALLCARS [1]) == "Lock") {
//					_Textpanel.SetActive (true);
					Car2_shareBtn.SetActive(true);
					_PlayButton.SetActive (false);
					Car3_shareBtn.SetActive (false);
					Car4_shareBtn.SetActive (false);
					Car5_shareBtn.SetActive (false);
					//_McarParent.GetComponent<BoxCollider>().enabled=false;
//					SDisplay = "Clear  5th Level to Unlock this car";
//				} else if (MYcarNo == 2 && PlayerPrefs.GetInt ("UnlockedCar") < 3) {
				} else if (MYcarNo == 2 && PlayerPrefs.GetString (UNLOCKALLCARS [2]) == "Lock") {
					Car3_shareBtn.SetActive (true);              // venkat
					_PlayButton.SetActive (false);
					Car2_shareBtn.SetActive (false);
					Car5_shareBtn.SetActive (false);
					Car4_shareBtn.SetActive (false);
					//					DisplayText.text = "";
//					SDisplay = "Clear 10th Level to Unlock this car";

//					//_McarParent.GetComponent<BoxCollider>().enabled=false;
//					_Textpanel.SetActive (true);
//				} else if (MYcarNo == 3 && PlayerPrefs.GetInt ("UnlockedCar") < 4) {
				} else if (MYcarNo == 3 && PlayerPrefs.GetString (UNLOCKALLCARS [3]) == "Lock") {
//					SDisplay = "Clear 15th Level to Unlock this car";
					Car4_shareBtn.SetActive(true);
					_PlayButton.SetActive (false);
                    Car2_shareBtn.SetActive (false);
					Car3_shareBtn.SetActive (false);
					Car5_shareBtn.SetActive (false);
					//_McarParent.GetComponent<BoxCollider>().enabled=false;
//					_Textpanel.SetActive (true);
//				} else if (MYcarNo == 4 && PlayerPrefs.GetInt ("UnlockedCar") < 5) {
				} else if (MYcarNo == 4 && PlayerPrefs.GetString (UNLOCKALLCARS [4]) == "Lock") {
//					SDisplay = "Clear 20th Level to Unlock this car";
					Car5_shareBtn.SetActive(true);
					_PlayButton.SetActive (false);
					Car2_shareBtn.SetActive (false);
					Car3_shareBtn.SetActive (false);
					Car4_shareBtn.SetActive (false);
					//_McarParent.GetComponent<BoxCollider>().enabled=false;
//					_Textpanel.SetActive (true);
                    
				}

				DisplayText.text = SDisplay;
			}
		}
	}

	#region VideoAd

	public static string videosKey = "videosWatched";
	public static string VideosKey2="VideosWatched2";
	public Text Text_5Video,Text_10Video;

	void CheckForVideoAvailablity ()
	{
		if (!PlayerPrefs.HasKey (videosKey))
		{
			PlayerPrefs.SetInt (videosKey, 5);
		}
		if (!PlayerPrefs.HasKey (VideosKey2)) 
		{
			PlayerPrefs.SetInt (VideosKey2, 10);

		}


		SetVideoCount ();
	}

	void SetVideoCount ()
	{
		if (PlayerPrefs.GetInt (videosKey) > 0) {
			Text_5Video.text = "Watch " + PlayerPrefs.GetInt (videosKey, 5) + " Videos to\nUnlock the Car";
		}
	}

	void SetVideoCount2()
	{
		if (PlayerPrefs.GetInt (VideosKey2) > 0) {
			Text_10Video.text = "Watch " + PlayerPrefs.GetInt (VideosKey2, 10) + " Videos to\nUnlock the Car";
		}
	}
	public string watchSuccess ()
	{
		Debug.Log ("watchSuccess::");
		int val = PlayerPrefs.GetInt (videosKey, 5);
		if (val > 0)
			val -= 1;
		PlayerPrefs.SetInt (videosKey, val);
		SetVideoCount ();
		Debug.Log ("Videos To watch:: " + PlayerPrefs.GetInt (videosKey, 5) + "=:UnlockedCar:==" + PlayerPrefs.GetInt ("UnlockedCar"));
		if (PlayerPrefs.GetInt (videosKey, 5) <= 0) {
			//if (PlayerPrefs.GetInt ("UnlockedCar") <= 1) {
			PlayerPrefs.SetInt ("UnlockedCar", 3);
			PlayerPrefs.SetString (UNLOCKALLCARS [1], "Unlock");
			SetcarlockSysyetm ();
			//}
		}
		return PlayerPrefs.GetInt (videosKey, 5) + "";

	}

	public string watchSuccess_10 ()
	{
		Debug.Log ("watchSuccess::");
		int val = PlayerPrefs.GetInt (VideosKey2, 10);
		if (val > 0)
			val -= 1;
		PlayerPrefs.SetInt (VideosKey2, val);
		SetVideoCount2 ();
		Debug.Log ("Videos To watch:: " + PlayerPrefs.GetInt (VideosKey2, 10) + "=:UnlockedCar:==" + PlayerPrefs.GetInt ("UnlockedCar"));
		if (PlayerPrefs.GetInt (VideosKey2, 10) <= 0) {
			//if (PlayerPrefs.GetInt ("UnlockedCar") <= 1) {
			PlayerPrefs.SetInt ("UnlockedCar", 3);
			PlayerPrefs.SetString (UNLOCKALLCARS [3], "Unlock");
			SetcarlockSysyetm ();
			//}
		}
		return PlayerPrefs.GetInt (VideosKey2, 10) + "";

	}






	public void Car2UnlockShare()
	{
		Invoke ("Unlock2Car",2.0f);
		Debug.Log ("car2 unlocked");
//		GameConfigs2015.share ();
	//	BtnAct_AdsRelated.myScript.Call_Share();
		PlayerPrefs.SetInt (StaticVAriables.unlockcarscount, PlayerPrefs.GetInt (StaticVAriables.unlockcarscount) + 1);

	}
	void Unlock2Car()
	{
		Debug.Log ("car 2 unlocked");
		PlayerPrefs.SetString (UNLOCKALLCARS [1], "Unlock");
		SetcarlockSysyetm ();

	}

	public void Car3UnlockShare()
	{
		Invoke ("Unlock3Car",2.0f);
		Debug.Log ("car3 unlocked");
		//		GameConfigs2015.share ();
		//BtnAct_AdsRelated.myScript.Call_Share();
		PlayerPrefs.SetInt (StaticVAriables.unlockcarscount, PlayerPrefs.GetInt (StaticVAriables.unlockcarscount) + 1);

	}
	void Unlock3Car()
	{
		Debug.Log ("car 3 unlocked");
		PlayerPrefs.SetString (UNLOCKALLCARS [2], "Unlock");
		SetcarlockSysyetm ();

	}



	public void Car4UnlockShare()
	{
		Invoke ("Unlock4Car",2.0f);
		Debug.Log ("car4 unlocked");
//		GameConfigs2015.share ();
	//	BtnAct_AdsRelated.myScript.Call_Share();
		PlayerPrefs.SetInt (StaticVAriables.unlockcarscount, PlayerPrefs.GetInt (StaticVAriables.unlockcarscount) + 1);
	    



	}

	void Unlock4Car()
	{
		Debug.Log ("car 4 unlocked");
		PlayerPrefs.SetString (UNLOCKALLCARS [3], "Unlock");
		SetcarlockSysyetm ();

	}


	public void Car5UnlockShare()
	{
		Invoke ("Unlock5Car",2.0f);
		Debug.Log ("car5 unlocked");
		//		GameConfigs2015.share ();
		//BtnAct_AdsRelated.myScript.Call_Share();
		PlayerPrefs.SetInt (StaticVAriables.unlockcarscount, PlayerPrefs.GetInt (StaticVAriables.unlockcarscount) + 1);
	    

	}

	void Unlock5Car()
	{
		Debug.Log ("car 5 unlocked");
		PlayerPrefs.SetString (UNLOCKALLCARS [4], "Unlock");
		SetcarlockSysyetm ();

	}
	#endregion

	public void closeunlockpop()
    {
		LevelSelectionHandler.Instance.unlocllcarspopup.SetActive(false);
        
	}

	public void buyunlockall(){
	//	GoogleIAB.purchaseProduct (InAppPurchaseManager.allSkus [1]);
		//AdsManager.myScript.UnlockAll_Guns();
		LevelSelectionHandler.Instance.unlocllcarspopup.SetActive(false);

	}

}
