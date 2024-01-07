using UnityEngine;
using System.Collections;

public class ArrowMArk : MonoBehaviour {

	public GameObject go_arrow;
	public float Delay;


	void Start ()
	{
		//if(StaticVAriables.mGameState==eGAME_STATE.GamePlay)
			StartCoroutine (ArrowGlimp ());
	}
	

	IEnumerator ArrowGlimp()
	{

		while (true)
		{
			yield return new WaitForSeconds (Delay);
			go_arrow.SetActive (false);
			yield return new WaitForSeconds (Delay);
			go_arrow.SetActive (true);

		}

	}
}
