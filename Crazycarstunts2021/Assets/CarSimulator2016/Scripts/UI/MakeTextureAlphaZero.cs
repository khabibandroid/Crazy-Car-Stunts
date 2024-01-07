using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MakeTextureAlphaZero : MonoBehaviour 
{

	public Image mImg_FadeImage; 
	public float mf_fadeSpeed = 2,mf_fadeDelay =0;
	// Use this for initialization
	void Start () 
	{
		FadeSprite ();
	}

	public void FadeSprite()
	{
		iTween.ValueTo (gameObject, iTween.Hash ("from", 1f, "to", 0f, "OnUpdate", "FadeOut", "OnUpdateTarget", gameObject, "time", mf_fadeSpeed, "delay", mf_fadeDelay)); 
	}

	public void FadeOut(float _fadeValue)
	{
		mImg_FadeImage.color = new Color (mImg_FadeImage.color.r, mImg_FadeImage.color.g, mImg_FadeImage.color.b, _fadeValue);
	}


}
