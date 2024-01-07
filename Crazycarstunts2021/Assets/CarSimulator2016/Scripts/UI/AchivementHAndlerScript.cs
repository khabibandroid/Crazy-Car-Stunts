using UnityEngine;
using System.Collections;
//using Prime31;

public class AchivementHandlerScript : MonoBehaviour
{
	//	public static AchivementHandlerScript Instance;

	public static int _ThreeStarCount = 0;

	//	AchivementHandlerScript

	private static AchivementHandlerScript _instance;

	public static  AchivementHandlerScript Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<AchivementHandlerScript> ();
			}
			return _instance;
		}



	}

	void Awake ()
	{
		_instance = this;
//		DontDestroyOnLoad (transform.gameObject);
	}


	public void UnlockFifithLevel ()
	{
		if (PlayerPrefs.GetInt ("UnlockedLevels") > 4) {
			Debug.Log ("Unlocked 5th Level achivement ");
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_1);
		}
	}

	public void UnlockTwelthLevel ()
	{
		if (PlayerPrefs.GetInt ("UnlockedLevels") > 11) {
			Debug.Log ("Unlocked 12th Level achivement ");
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_2);
		}
	}

	public void UnlockTwentythLevel ()
	{
		if (PlayerPrefs.GetInt ("UnlockedLevels") > 19) {
			Debug.Log ("Unlocked 20th Level achivement ");
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_3);
		}
	}

	public void FacebookShare ()
	{
		
		Debug.Log ("FaceBook share achivement ");
	//	PlayGameServices.unlockAchievement (GSConfig.ACH_4);

	}

	public void UnLockAllLevels ()
	{
		Debug.Log ("Unlockall level achivement ");
	//	if (PlayerPrefs.GetInt ("UnlockedLevels") >= 25)
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_5);

	}

	public void UnLockAllcar ()
	{
		Debug.Log ("Unlockall  car achivement ");
		//if (PlayerPrefs.GetInt ("UnlockedCar") >= 5)
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_6);
	}

	public void ThreeStarContinuesly ()
	{
		if (_ThreeStarCount > 2) {
			Debug.Log ("three star collected  achivement ");
		//	PlayGameServices.unlockAchievement (GSConfig.ACH_7);
		}
	}

	public void ThirdCarUnlock ()
	{
		if (PlayerPrefs.GetInt ("UnlockedCar") >= 3) {
			Debug.Log ("car 3 unlocked ");
			//PlayGameServices.unlockAchievement (GSConfig.ACH_8);
		}
	}

	public void ThreeStarOnLastLevel ()
	{
		if (StaticVAriables._iCurrentLevel > 25) {
			if (StaticVAriables._iStarNo > 2) {
				Debug.Log ("25th level 3 star ");
			//	PlayGameServices.unlockAchievement (GSConfig.ACH_9);
			}
		}
	}

	public void  firstatemptTenthlevel ()
	{
		//PlayGameServices.unlockAchievement (GSConfig.ACH_10);
	}
}
