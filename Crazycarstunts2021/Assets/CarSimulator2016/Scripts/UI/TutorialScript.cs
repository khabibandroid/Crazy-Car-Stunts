using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	public GameObject[] Arrows;
	public Text _Tutorialtext;
	int count=0;
	void Start () 
	{
		ChangeTutorial ();
	}
	
	public void Onbuttonclick(string _btnName)
	{
		if (_btnName == "OK")
		{
			if (count <7)
			{
				
				count++;
				ChangeTutorial ();
			}
			else
			{
				
				UI_handlerScript.Instance.CloseTutorial ();

			}
		}

	}

	void ChangeTutorial()
	{
		switch (count)
		{
		case 0:
			Arrows [0].SetActive (true);
			_Tutorialtext.text = " Steer to Move Around".ToString ();
		break;
		case 1:
			Arrows [0].SetActive (false);
			Arrows [1].SetActive (true);
			_Tutorialtext.text = "Accelerate to Pich Up Speed".ToString ();
		break;
		case 2:
			Arrows [1].SetActive (false);
			Arrows [2].SetActive (true);
			_Tutorialtext.text = " Tap and Hold to Apply Brake ".ToString ();
		break;
		case 3:
			Arrows [2].SetActive (false);
			Arrows [3].SetActive (true);
			_Tutorialtext.text = "Slide to Change  Gear".ToString ();
		break;
		case 4:
			Arrows [3].SetActive (false);
			Arrows [4].SetActive (true);
			_Tutorialtext.text = "  Tap to Change Control".ToString ();
		break;
		case 5:
			Arrows [4].SetActive (false);
			Arrows [5].SetActive (true);
			_Tutorialtext.text = "  Tap to Change Camera View".ToString ();
		break;
		case 6:
			Arrows [5].SetActive (false);
			Arrows [6].SetActive (true);
			_Tutorialtext.text = "  This panel Shows Time ".ToString ();
		break;
		case 7:
			Arrows [6].SetActive (false);
			Arrows [7].SetActive (true);
			_Tutorialtext.text = "  Tap To Pause Game ".ToString ();
		break;

		}

	}
}
