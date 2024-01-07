using UnityEngine;
using System.Collections;

public class pinpongeffects : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
//		StartCoroutine ("Pingpongbutton",1f);
		iTween.ScaleTo (gameObject,iTween.Hash ("x",0.8f,"y",0.8f,"time",0.5f,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.pingPong));
	}
	


}
