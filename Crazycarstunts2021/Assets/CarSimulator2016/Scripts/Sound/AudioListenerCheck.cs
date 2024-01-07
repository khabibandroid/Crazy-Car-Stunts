using UnityEngine;
using System.Collections;

public class AudioListenerCheck : MonoBehaviour 
{

	// Use this for initialization
	void OnEnable () 
	{
		if(StaticVAriables.sv_bsound) 
		{
			//Debug.Log("SoundOn");
			AudioListener.volume = 1;
		}
		else 
		{
			//Debug.Log("SoundOff");
			AudioListener.volume = 0;
		}
	}
	

}
