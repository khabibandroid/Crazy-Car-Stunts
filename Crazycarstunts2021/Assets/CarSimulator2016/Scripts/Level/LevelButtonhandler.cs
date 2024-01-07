using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelButtonhandler : MonoBehaviour 
{


	void Start ()
	{
	
		//gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (180, 244);
		gameObject.GetComponentInParent<LevelSelectionHandler>().SceneSelectionToLoad (PlayerPrefs.GetInt ("UnlockedLevels"));





	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnButtonClick(int _LevelNo)
	{
		for(int i=0;i<GetComponent <LevelUnlockSystem>().Mylevels.Count;i++)
		{
//			GetComponent <LevelUnlockSystem>().Mylevels[i].transform.localScale = Vector3.one;	
//			GetComponent <LevelUnlockSystem>().Mylevels[i].gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (200, 264);
		}

		if(StaticVAriables.mMenuState==eMENU_STATE.LevelSelection)
		{
			StaticVAriables._iCurrentLevel = _LevelNo;
			gameObject.GetComponentInParent<LevelSelectionHandler>().SceneSelectionToLoad (StaticVAriables._iCurrentLevel);
//			LevelUnlockSystem.Instance.SelelctedLevel ();
			//GetComponent <LevelUnlockSystem>().Mylevels[_LevelNo-1].transform.localScale = Vector3.one*1.2f;
//			iTween.ScaleTo (GetComponent <LevelUnlockSystem> ().Mylevels [_LevelNo - 1], iTween.Hash ("x", 1.2f, "y", 1.2f, "time", 0.2f, "delay", 0f, "easetype", iTween.EaseType.linear));
			Invoke ("LoadNextScene", 0.1f);
			//gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (240, 304);
		}
	}

	void LoadNextScene()
	{
		//CarSelectionHandler.Instance.caractivepage = true;
		StaticVAriables.mMenuState = eMENU_STATE.None;
		LevelSelectionHandler.Instance.CloseLevelSelectionPage ();
		LevelSelectionHandler.Instance.EnableCarSelection ();
		StaticVAriables.carSelectioncount++;
		if (StaticVAriables.carSelectioncount < 4 && PlayerPrefs.GetInt (StaticVAriables.unlockcarscount) <= 4){
			if (StaticVAriables.carSelectioncount == 3) {
				//NativePopUp.myScript.UnLockAllTrains ();
				print (StaticVAriables.carSelectioncount + "StaticVAriables.carSelectioncount");
				//StaticVAriables.LevelfailedCount = 0;
				//StaticVAriables.carSelectioncount = 0;
				LevelSelectionHandler.Instance.unlocllcarspopup.SetActive(true);
				//LevelSelectionHandler.Instance.carsinapp.text = PlayerPrefs.GetString (InAppPurchaseManager.allSkus [1], "Buy");
			}
		}
	}

}
