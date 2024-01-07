using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUnlockSystem : MonoBehaviour
{
	public List<GameObject> Mylevels = new List<GameObject> ();
	public static LevelUnlockSystem Instance = null;
	public GameObject _ScrollViewContent;

	void Awake ()
	{
		if (!PlayerPrefs.HasKey ("UnlockedLevels"))
		{
			PlayerPrefs.SetInt ("UnlockedLevels", 1);//unlock all levels here
		}
	}

	void Start ()
	{
		Instance = this;
	//	PlayerPrefs.SetInt ("UnlockedLevels",12);  //venkat
	
	//	PlayerPrefs.DeleteAll ();


		SetUnlockedLevels ();

		SetLevelObjectsLock ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	  
	}

	public void SetUnlockedLevels ()
	{
		for (int i = 0; i < Mylevels.Count; i++)
		{
			if (i < PlayerPrefs.GetInt ("UnlockedLevels"))
			{
				Mylevels [i].transform.GetChild (1).gameObject.SetActive (false);
				Mylevels [i].transform.GetChild (0).gameObject.SetActive (true);
				Mylevels [i].GetComponent<Image> ().raycastTarget = true;
//				Mylevels [PlayerPrefs.GetInt ("UnlockedLevels") - 1].gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (240, 304);
				//Mylevels [PlayerPrefs.GetInt ("UnlockedLevels") - 1].gameObject.GetComponent<RectTransform> ().rect.height = 274;
				//Mylevels [i].GetComponent<Button> ().interactable = true;
			} else
			{
				Mylevels [i].transform.GetChild (1).gameObject.SetActive (true);
				Mylevels [i].transform.GetChild (0).gameObject.SetActive (false);
				Mylevels [i].GetComponent<Image> ().raycastTarget = false;
				//Mylevels [i].gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (180, 244);
				//Mylevels [i].GetComponent<Button> ().interactable = false;

			}
		}
	}


	void SetLevelObjectsLock ()
	{

		float Val = 1;
		int unlockedLvls = PlayerPrefs.GetInt ("UnlockedLevels") - 1;
		Val = (float)(unlockedLvls) / (float)25;
		if (_ScrollViewContent)
		{
			_ScrollViewContent.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((-5270 * Val), _ScrollViewContent.GetComponent<RectTransform> ().anchoredPosition.y);
			//_ScrollViewContent.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (, _ScrollViewContent.GetComponent<RectTransform> ().anchoredPosition.y);
		}
	}

	public void SelelctedLevel ()
	{

		for (int i = 0; i < Mylevels.Count; i++)
		{
			if (i < PlayerPrefs.GetInt ("UnlockedLevels"))
			{
				
				Mylevels [StaticVAriables._iCurrentLevel].gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (240, 304);
				//Mylevels [PlayerPrefs.GetInt ("UnlockedLevels") - 1].gameObject.GetComponent<RectTransform> ().rect.height = 274;
				//Mylevels [i].GetComponent<Button> ().interactable = true;
			} else
			{
		

				Mylevels [i].gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (180, 244);
				//Mylevels [i].GetComponent<Button> ().interactable = false;
			}
		}
	}
}
