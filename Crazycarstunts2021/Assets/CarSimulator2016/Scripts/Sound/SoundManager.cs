using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

	public AudioSource audio_menu, audio_btn, audio_selectionPage, audio_loading;
	//Menu UI
	public AudioSource audio_levelFail, audio_levelWin, audio_Forest, audio_City,audio_levelSelection;
	//Ingame
	public static SoundManager staticscript_soundMgr;

	void OnEnable ()
	{
		if (staticscript_soundMgr == null) {
			staticscript_soundMgr = this;
		}
	}

	void OnDisable ()
	{
		if (staticscript_soundMgr != null) {
			staticscript_soundMgr = null;
		}
	}

	// Use this for initialization
	void Start ()
	{
		if (MenuHAndler.Instance != null) {
			MenuMusic ();
		} else if (Application.loadedLevelName == "City1" || Application.loadedLevelName == "Village1" )
			{
			InGameMusic ();
		} else if (Application.loadedLevelName == "LoadingScene") {
			LoadingPage ();
		}

	}

	public void MenuMusic ()
	{
		//Debug.Log("Musics");
		audio_menu.Play (); 
	}

	public void InGameMusic ()
	{
		if(Application.loadedLevelName == "City1")
		{
			
			audio_City.Play (); 
		}
		else if(Application.loadedLevelName == "Village1")
		{
			audio_Forest.Play (); 
		}

	}

	public void LoadingPage ()
	{
		audio_loading.Play ();
	}

	public void ButtonSound ()
	{
		audio_btn.Play ();
	}

	public void SelectionPage ()
	{
		audio_selectionPage.Play ();
	}

	public void LevelSelectionPage()
	{
		audio_levelSelection.Play ();
	}

	public void LevelWin ()
	{
		audio_levelWin.Play ();
	}

	public void LevelFail ()
	{
		audio_levelFail.Play ();
	}
		
}
