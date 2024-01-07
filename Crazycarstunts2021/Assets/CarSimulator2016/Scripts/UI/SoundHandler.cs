using UnityEngine;
using System.Collections;

public class SoundHandler : MonoBehaviour 
{
	public static SoundHandler Instance=null;
	public GameObject _goSoundOn,_goSoundOff;



	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		Instance = this;
		if(!PlayerPrefs.HasKey ("GameSound"))
		{
			PlayerPrefs.SetInt ("GameSound",1);
		}
	}
	void Start () 
	{
		//SoundButtonFunction ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SoundButtonFunction()
	{
		Debug.Log ("Sound Function");
		int mysoundOn = PlayerPrefs.GetInt ("GameSound");
		if(mysoundOn==0)
		{
			PlayerPrefs.SetInt ("GameSound", 1);
			_goSoundOn.SetActive (false);
			_goSoundOff.SetActive (true);

		}
		else
		{
			PlayerPrefs.SetInt ("GameSound", 0);
			_goSoundOn.SetActive (true);
			_goSoundOff.SetActive (false);

		}
	}

}
