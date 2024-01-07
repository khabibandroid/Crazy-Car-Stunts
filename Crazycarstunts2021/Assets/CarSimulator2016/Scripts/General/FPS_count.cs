using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS_count : MonoBehaviour {

	float timeleft,fps;
	int frames;
	public Text mText_fpsDisplay;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		timeleft -= Time.deltaTime;
		++frames;

		if (timeleft <= 0.0) 
		{
			fps = frames;
			timeleft = 1;
			frames = 0;
		}

		mText_fpsDisplay.text ="FPS: "+fps.ToString();
	}
}
