// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Example3DObjectCharacter : MonoBehaviour {
	public static Example3DObjectCharacter mee;
	public SwipeControl swipeCtrl;
	public Transform[] obj = new Transform[0];
	public float minXPos = 0; //min x position of the camera
	public float maxXPos = 115; //max x position of the camera
	private float xDist; //distance between camMinXPos and camMaxXPos
	private float xDistFactor; // = 1/camXDist
	private float swipeSmoothFactor = 1.0f; // 1/swipeCtrl.maxValue
	private float rememberYPos;

	[SerializeField] GameObject CameraObj;

	void  Start (){
		mee = this;
		xDist = maxXPos - minXPos;
		xDistFactor = 1.0f / xDist;
		
		if(!swipeCtrl)// swipeCtrl = gameObject.AddComponent<SwipeControl>();
			swipeCtrl	= GetComponent<SwipeControl>();


		swipeCtrl.skipAutoSetup = false; //skip auto-setup, we'll call Setup() manually once we're done changing stuff
		swipeCtrl.clickEdgeToSwitch = false; //only swiping will be possible
		swipeCtrl.SetMouseRect(new Rect(0, 0, Screen.width, Screen.height)); //entire screen
		swipeCtrl.maxValue = obj.Length - 1; //max value
		swipeCtrl.currentValue = swipeCtrl.maxValue; //current value set to max, so it starts from the end
		swipeCtrl.startValue = 2;//Mathf.RoundToInt(swipeCtrl.maxValue * 0.5f); //when Setup() is called it will animate from the end to the middle

		swipeCtrl.partWidth = Screen.width  / swipeCtrl.maxValue; //how many pixels do you have to swipe to change the value by one? in this case we make it dependent on the screen-width and the maxValue, so swiping from one edge of the screen to the other will scroll through all values.
		swipeCtrl.Setup();
		
		swipeSmoothFactor = 1.0f/swipeCtrl.maxValue; //divisions are expensive, so we'll only do this once in start

//		rememberYPos = obj[0].position.y;
		SetOpacityBasedOnEnabledLevels();

	}
	void SetOpacityBasedOnEnabledLevels()
	{
//		int totalUnlockedLevel	= PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels);

//		int totalUnlockedLevel1=PlayerPrefs.GetInt(MyGamePrefs.Unlocked_Levels1);

//		if(totalUnlockedLevel <= 0)
//		{
//			totalUnlockedLevel	= 1;
//			PlayerPrefs.SetInt(MyGamePrefs.Unlocked_Levels,totalUnlockedLevel);
//		}
//
//	
//		for(int i = 0 ; i < obj.Length ; i++)
//		{
//			if(i < totalUnlockedLevel)
//				continue;
//	
//			Image _img	 = obj[i].gameObject.GetComponent<Image>();
//			_img.color	= new Color(1,1,1,0.5f);
//		}
	}
	void InvokeAfterSomeDelay()
	{
		swipeCtrl.currentValue	= 0;
	}

	float aa = 0.5f;
	float xx;
	float zz,zz1,yy,sca;
	void  Update ()
	{
		for(int i = 0; i < obj.Length; i++) 
		{
			xx = minXPos + i * (xDist * swipeSmoothFactor) - swipeCtrl.smoothValue*swipeSmoothFactor*xDist;
			zz = 1.5f * (4f - Mathf.Clamp(Mathf.Abs(i - swipeCtrl.smoothValue), 0.0f, 4.0f)); //move selected one up a little
//			yy = 0.4f * (1 - Mathf.Clamp(Mathf.Abs(i - swipeCtrl.smoothValue), 0.0f, 2.0f)); //move selected one up a little  to move up a little

			zz1 = (110f - Mathf.Clamp(Mathf.Abs(i - swipeCtrl.smoothValue), 0.0f, 4.0f)); //move selected one up a little


			obj[i].transform.localPosition = new Vector3(xx-1f,yy+50,zz1);	
			
//			obj[i].transform.localScale = new Vector3(zz/7f,zz/7f,zz); for scaling effect
		}	
	}

}