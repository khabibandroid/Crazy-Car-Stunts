using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorJumpCollider : MonoBehaviour {

	public GameObject[] cameras;
	private GameObject mainCarCamera;


	void Start(){
		mainCarCamera = GameObject.Find ("Main Camera");
	}

	int randomCameraInt;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {

			randomCameraInt = Random.Range (0,cameras.Length);
			cameras [randomCameraInt].SetActive (true);

			mainCarCamera.SetActive (false);

//			Invoke ("TimeSlowDown", 0.5f);
//			Invoke ("TimeReset", 1.2f);
			Invoke ("ResetCamPos",2f);
		}
	}
	void TimeSlowDown()
	{
		Time.timeScale = 0.2f;

	}
	void TimeReset()
	{
		Time.timeScale = 1;

	}

	void ResetCamPos(){
		cameras [randomCameraInt].SetActive (false);

		mainCarCamera.SetActive (true);
	}
}
