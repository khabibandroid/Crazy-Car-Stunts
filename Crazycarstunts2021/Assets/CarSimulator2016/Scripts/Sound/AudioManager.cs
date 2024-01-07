using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	public Image mImg_source;
	public Sprite msprite_soundOff,msprite_soundOn ;
	public Text mText_sound;
	public static AudioManager staticscript_audio;

	void OnEnable()
	{
		if(staticscript_audio == null)
		{
			staticscript_audio = this;
		}
		checkButtonshow ();
	}

	void OnDisable()
	{
		if(staticscript_audio != null)
		{
			staticscript_audio = null;
		}
	}

	// Use this for initialization
	void Start () 
	{
		if(StaticVAriables.sv_bsound)
		{
			mImg_source.sprite = msprite_soundOff;
			mText_sound.text="SOUND OFF";
			AudioListener.volume = 1;
		}
		else 
		{
			mImg_source.sprite = msprite_soundOn;
			mText_sound.text="SOUND ON";

			AudioListener.volume = 0;
		}
	}

	public void SoundClick()
	{
		if(StaticVAriables.sv_bsound)
		{
			StaticVAriables.sv_bsound = false;
			mImg_source.sprite = msprite_soundOn;
			mText_sound.text="SOUND ON";

			AudioListener.volume = 0;
		}
		else 
		{
			StaticVAriables.sv_bsound = true;
			mImg_source.sprite = msprite_soundOff;
			mText_sound.text="SOUND OFF";

			AudioListener.volume = 1;
            
		}
	}

	public void checkButtonshow ()
	{
		if(StaticVAriables.sv_bsound)
		{
			mImg_source.sprite = msprite_soundOff;
			mText_sound.text="SOUND OFF";

		}
		else 
		{
			mImg_source.sprite = msprite_soundOn;
			mText_sound.text="SOUND ON";

           
		}
	}

}
