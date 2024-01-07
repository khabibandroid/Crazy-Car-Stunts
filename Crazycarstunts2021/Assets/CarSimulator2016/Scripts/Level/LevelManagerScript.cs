
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Cameras;
using UnityEngine.UI;
public class LevelManagerScript : MonoBehaviour
{
	public static LevelManagerScript Instance;
	[Header ("Level Planning:")]
	public GameObject[] _goLevelData;
	GameObject _goCurrentLevelObject;

	LevelTargets _curreLevelDatas;
	List<LevelObjects> _LevelTargetsobjects = new List<LevelObjects> ();

	public bool IsDummyLevelSelection;
	public int _iDummyLevelNO;
	public static float GamePlayTimer;
	public float TotalTimeForGame;
	//public static string TaskText;
	//AdmobAds amd;
	public GameObject[] _goCars;
	public  GameObject _goPlayerCar;
    
	void Awake ()
	{
		Cityvalues ();
		Villagevalue ();
		Instance = this;
		if (IsDummyLevelSelection)
			_goCurrentLevelObject = _goLevelData [_iDummyLevelNO];//StaticVAriables._iCurrentLevel-1
		else
			_goCurrentLevelObject = _goLevelData [SceneSelectionToLoad ()];
		
		_goCurrentLevelObject.SetActive (true);
		_curreLevelDatas = _goCurrentLevelObject.GetComponent<LevelData> ()._LevelTargets;
		LevelObjects[] _objects = _curreLevelDatas._levelObjects;
		StaticVAriables.mLevelstate = _objects [0]._LevelType;
		///// taking time
      //  hdfc 9603124212 


		if (_LevelTargetsobjects == null)
			_LevelTargetsobjects = new List<LevelObjects> ();
		if (_LevelTargetsobjects.Count > 0)
			_LevelTargetsobjects.Clear ();
            
		for (int i = 0; i < _objects.Length; i++) {
			_LevelTargetsobjects.Add ((_objects [i]));

			//amd = this.GetComponent<AdmobAds>();
            
		}


		_goPlayerCar = Instantiate (_goCars [StaticVAriables._icurrentCar]) as GameObject;                                                     ////// FOR CAR CHANGING
		_goPlayerCar.transform.position = _curreLevelDatas._StartPOS.transform.position;
		_goPlayerCar.transform.rotation = _curreLevelDatas._StartPOS.transform.rotation;
        

		DeactivateAllcheckpoint ();

        
		//AutoCam.Instance.SetTarget (_goPlayerCar.transform);

	}

	void Start ()
	{
		AutoCam.Instance.SetTarget (_goPlayerCar.transform);
    //  PlayerPrefs.SetInt("UnlockedLevels", 12);

        //Debug.Log ("Camera : "+_goPlayerCar.name);

        //		if (MapHandler.Instance)
        //		{
        //			MapHandler.Instance.InitilaizeMapDatas (_curreLevelDatas._TargetsOnMap);
        //			//Debug.Log ("calling awake");
        //		}

        LevelObjects obj = _LevelTargetsobjects [0];
		TotalTimeForGame = obj._iTimeforLevel;
        
	}
	// ******************
	public void  CarParkingfunction ()/////// ..........     parking
	{
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {
			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.Parking) {
				if (_obj._iTargetCount > 0) {
					_obj._iTargetCount--;
                    

				}
				if (_obj._iTargetCount <= 0) {
					_LevelTargetsobjects.Remove ((_obj));
                     
                
				}
			}
		}
		CheckLevelComplition ();
        
	}

	public void  Hitbasedfunction ()////////.............  Hit based
	{
		
	}

	public void TimebasedFunction ()///////...............time based
	{
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {
			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.Time_Based) {
				if (_obj._iTimeforLevel <= 1) {
					_LevelTargetsobjects.Remove ((_obj));
					UI_handlerScript.Instance.ShowLevelFailed ();

				} else {
					_obj._iTimeforLevel -= Time.deltaTime;
					Debug.Log ("PLayer timer" + (int)_obj._iTimeforLevel);


				}
			}
		}
		CheckLevelComplition ();
	}

	public void TargetBased ()/////.....................taregt based
	{
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {

			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.Target_Based) {

				if (_obj._iTargetCount > 0) {
					_obj._iTargetCount--;
					//Debug.Log (_obj._iTargetCount);
				}
				if (_obj._iTargetCount <= 0) {
					_LevelTargetsobjects.Remove ((_obj));

                    
				}

			}
		}
		CheckLevelComplition ();
	}

	public void CheckPointFunction ()///////............ checkpoint function
	{
		
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {
			
			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.CheckPoint) {
				
				if (_obj._iTargetCount > 0) {
					_obj._iTargetCount--;
					//Debug.Log (_obj._iTargetCount);
				}
				if (_obj._iTargetCount <= 0) {
					_LevelTargetsobjects.Remove ((_obj));


				}
			}
		}


		CheckLevelComplition ();
		Debug.Log("check levelcompletion");

	}

	public void TimerRacegamePLay ()///////............ checkpoint function
	{

		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {

			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.Time_Based) {

				if (_obj._iTargetCount > 0) {
					_obj._iTargetCount--;
					//Debug.Log (_obj._iTargetCount);
				}
				if (_obj._iTargetCount <= 0) {
					_LevelTargetsobjects.Remove ((_obj));

                    Debug.Log("leveltargetobjects");


				}
			}
		}


		CheckLevelComplition ();

	}


	public void Tailingplayer ()
	{
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {

			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._LevelType == eLEVEL_TYPE.Tailing) {

				if (_obj._iTargetCount > 0) {
					_obj._iTargetCount--;
					//	Debug.Log (_obj._iTargetCount);
				}
				if (_obj._iTargetCount <= 0) {
					_LevelTargetsobjects.Remove ((_obj));


				}
			}
		}


		CheckLevelComplition ();
		Debug.Log("check levelcompletion");

	}

	void  CheckLevelComplition ()
	{
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
			return;

		if (_LevelTargetsobjects == null || _LevelTargetsobjects.Count <= 0) {
			StaticVAriables.mGameState = eGAME_STATE.None;
			UI_handlerScript.Instance.EnanbleLEvelCompleted ();
			if (StaticVAriables._iCurrentLevel < 25 && PlayerPrefs.GetInt ("UnlockedLevels") < StaticVAriables._iCurrentLevel + 1)
				PlayerPrefs.SetInt ("UnlockedLevels", StaticVAriables._iCurrentLevel + 1);
               StaticVAriables._iScore = Scoregiving ();
			   StaticVAriables._iStarNo = StarGivingPolicy ();
		
			//	Debug.Log ("My star  :"+ StaticVAriables._iStarNo+"  my score"+StaticVAriables._iScore );

			Debug.Log("ads working");

			//amd.ShowInterstitialAd();
		//	Admanager.instance.ShowFullScreenAd();




			if (!PlayerPrefs.HasKey (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel)) {
				PlayerPrefs.SetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel, StaticVAriables._iScore);
			}
            else if 
                (StaticVAriables._iScore > PlayerPrefs.GetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel))
            {
				PlayerPrefs.SetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel, StaticVAriables._iScore);
                
			}
            else
				PlayerPrefs.SetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel, PlayerPrefs.GetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel));
                
               

			StaticVAriables.iBestScore = PlayerPrefs.GetInt (StaticVAriables._BestLevelScore + StaticVAriables._iCurrentLevel);
			//	CarSelectionHandler.Instance.SetcarlockSysyetm ();
			if (PlayerPrefs.GetInt ("UnlockedLevels") == 12) {
				//Debug.Log (" car unlocked");
				PlayerPrefs.SetInt ("UnlockedCar", 2);
				PlayerPrefs.SetString (CarSelectionHandler.UNLOCKALLCARS [1], "Unlock");
			} else if (PlayerPrefs.GetInt ("UnlockedLevels") == 13) {
				PlayerPrefs.SetInt ("UnlockedCar", 3);
				PlayerPrefs.SetString (CarSelectionHandler.UNLOCKALLCARS [2], "Unlock");
			} else if (PlayerPrefs.GetInt ("UnlockedLevels") == 13) {
				PlayerPrefs.SetInt ("UnlockedCar", 4);
				PlayerPrefs.SetString (CarSelectionHandler.UNLOCKALLCARS [3], "Unlock");


			}
            else if (PlayerPrefs.GetInt ("UnlockedLevels") == 13)
            {

				PlayerPrefs.SetInt ("UnlockedCar", 5);
				PlayerPrefs.SetString (CarSelectionHandler.UNLOCKALLCARS [4], "Unlock");
                
			}

			StaticVAriables.LevelfailedCount = 0;
			//if (AdsManager.myScript != null) {
			//	AdsManager.myScript.CheckRate (StaticVAriables._iCurrentLevel, 1.5f);
			//	AdsManager.myScript.CheckShare (StaticVAriables._iCurrentLevel, 1.5f);
			//	AdsManager.myScript.CheckAch ();
			//	AdsManager.myScript.Push_LB (StaticVAriables._iScore);
			//	AdsManager.myScript.LevelCompAd (StaticVAriables._iCurrentLevel);
			//}
		}

//		PlayerPrefs.SetInt (MyGamePrefs.TotalScore,(PlayerPrefs.GetInt()+Total_Reward));
//		if(PlayerPrefs.GetInt(MyGamePrefs.TotalScore)>PlayerPrefs.GetInt(MyGamePrefs.TotalHighScore))
//		{
//			PlayerPrefs.SetInt(MyGamePrefs.TotalHighScore,PlayerPrefs.GetInt(MyGamePrefs.TotalScore));
//		}

		//Debug.Log ("levelfailed count in gamecompleted" + StaticVAriables.LevelfailedCount);



	}

	public void TimeBasedgameplay ()
	{

		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {

			LevelObjects _obj = _LevelTargetsobjects [i];
			if (_obj._iTimeforLevel <= 1) {
				StaticVAriables.mGameState = eGAME_STATE.None;
				Debug.Log ("---- Add Life PopUp Time");
				UI_handlerScript.Instance.ShowLevelFailed();
				//				UI_handlerScript.Instance.ShowLevelFailed ();
				Debug.Log("Game play followbased");
			} 
			if (StaticVAriables.mGameState == eGAME_STATE.GamePlay) 
			{
				_obj._iTimeforLevel -= Time.deltaTime;
				GamePlayTimer = _obj._iTimeforLevel;
			//	Debug.Log("ad working timebase");

			}
		}
	}

	public void Call_AddLifeAfterVideoSuccess ()
	{
		Time.timeScale = 1;
	//	StaticVAriables.mGameState = eGAME_STATE.GamePlay;
		//		GamePlayTimer = 15f;
		Debug.Log ("---- After Add Life");
		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {
			LevelObjects _obj = _LevelTargetsobjects [i];
			Debug.Log ("CurrentTime:==" + _obj._iTimeforLevel);
			if (_obj._iTimeforLevel < 20)
				_obj._iTimeforLevel = 20f;
			    
		}

//		TotalTimeForGame = obj._iTimeforLevel;
	//TotalTimeForGame = 15f;
		StaticVAriables.mGameState = eGAME_STATE.GamePlay;
		TimeBasedgameplay ();

	}

	int star = 0;
	int score = 0;

	public int   StarGivingPolicy ()                                            /////////////////// star collection 
	{
		float myTime = TotalTimeForGame - GamePlayTimer;


		if (myTime < (TotalTimeForGame / 3)) {
			star = 3;
		} else if (myTime > (TotalTimeForGame / 3) && myTime < (TotalTimeForGame / 2)) {
			star = 2;
		} else
        {
			star = 1;
		}
		//	Debug.Log ("my time" + myTime);
		return star;
	}

	public int Scoregiving ()
	{
		//float myTime = TotalTimeForGame - GamePlayTimer;

		score = (int)GamePlayTimer * 100;
		//print ("myscore"+score+"  my timer "+GamePlayTimer);
		return score;
	}


	public void PlayerhitAiFunction ()
	{
		StaticVAriables.mGameState = eGAME_STATE.None;
	//	UI_handlerScript.Instance.ShowLevelFailed ();//venkat
		UI_handlerScript.Instance.ShowLevelFailed();
		Debug.Log("playerhit");

	}

	//////// Text Department/////////

	public string GetTargetText ()
	{
		string _TAskText = "";

		for (int i = _LevelTargetsobjects.Count - 1; i >= 0; i--) {
			LevelObjects _obj = _LevelTargetsobjects [i];
			switch (_obj._LevelType)
            {
			case  eLEVEL_TYPE.Parking:
				_TAskText += "You have to cross Checkpoint before you run out of time.";
				break;
			case eLEVEL_TYPE.CheckPoint:
				_TAskText += "You have to cross Checkpoint before you run out of time.";
				break;
			case eLEVEL_TYPE.Time_Based:
				_TAskText += "Make sure you reach your destination on time. ";
				break;
			case eLEVEL_TYPE.Target_Based:
				_TAskText += "You have to cross Checkpoint before you run out of time.";//
				break;
			case eLEVEL_TYPE.Tailing:
				_TAskText += "You have to cross Checkpoint before you run out of time. ";

				break;
                
			}
		}

		return _TAskText;


	}

	public Component[] ChildObj;

	public void AIcarStateChange ()
	{
		//Debug.Log (_goCurrentLevelObject.name);


		if (_goCurrentLevelObject.GetComponentInChildren<hoMove> ()) {
			ChildObj = _goCurrentLevelObject.GetComponentsInChildren<hoMove> ();
			if (StaticVAriables.mGameState != eGAME_STATE.GamePlay) {
				foreach (hoMove obj in ChildObj)
					obj.Pause ();
			} else {
				foreach (hoMove obj in ChildObj)
					obj.Resume ();
                    


			}
		}

	}

	public void DeactivateAllcheckpoint ()
	{
		LevelObjects obj = _LevelTargetsobjects [0];
		if (obj._LevelType == eLEVEL_TYPE.CheckPoint) {
			for (int i = 0; i < _curreLevelDatas._TargetsOnMap.Count; i++)
            {
				_curreLevelDatas._TargetsOnMap [i].SetActive (false);
			}
			_curreLevelDatas._TargetsOnMap [0].SetActive (true);

			Debug.Log("deactivate all check points");
            







		}

	}

	public void ActivateCheckpoint ()
	{

		if (_LevelTargetsobjects.Count <= 0)
			return;
		LevelObjects obj = _LevelTargetsobjects [0];

		if (obj._LevelType == eLEVEL_TYPE.CheckPoint) {
			if (_curreLevelDatas._TargetsOnMap.Count > 0) {
				_curreLevelDatas._TargetsOnMap.RemoveAt (0);
				if (_curreLevelDatas._TargetsOnMap.Count > 0) {
					_curreLevelDatas._TargetsOnMap [0].SetActive (true);



                
				}
			}
		}
	}

	List<int> City1 = new List<int> ();
	List<int> Village1 = new List<int> ();

	public int SceneSelectionToLoad ()
	{
		int LevelNO = 0;
		for (int i = 0; i < City1.Count; i++) {
			if (City1 [i] == StaticVAriables._iCurrentLevel)
            {
							//	StaticVAriables._iCurrentLevel = i;  // venkat uncomment
				LevelNO = i;

			}
		}
		for (int i = 0; i < Village1.Count; i++) {
			if (Village1 [i] == StaticVAriables._iCurrentLevel) {
						//	StaticVAriables._iCurrentLevel = i;     //venkat uncomment
				LevelNO = i;
				Debug.Log("scene load");


			}
		}

		return LevelNO;
	}

	void Cityvalues ()
	{
		City1.Add (1);
		City1.Add (2);
		City1.Add (3);
		City1.Add (7);
		City1.Add (8);
		City1.Add (9);
		City1.Add (13);
		City1.Add (14);
		City1.Add (15);
		City1.Add (19);
		City1.Add (20);
		City1.Add (21);
		City1.Add (25);
	}

	void Villagevalue ()
	{
		Village1.Add (4);
		Village1.Add (5);
		Village1.Add (6);
		Village1.Add (10);
		Village1.Add (11);
		Village1.Add (12);
		Village1.Add (16);
		Village1.Add (17);
		Village1.Add (18);
		Village1.Add (22);
		Village1.Add (23);
		Village1.Add (24);

	}
}

