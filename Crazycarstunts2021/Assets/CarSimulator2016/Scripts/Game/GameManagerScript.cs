using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{

	public static GameManagerScript Instance;

	void Awake ()
	{
		StaticVAriables.mGameState = eGAME_STATE.GamePlay;
	}

	void Start ()
	{

		if (StaticVAriables._iCurrentLevel == 10)
			AchivementHandlerScript.Instance.firstatemptTenthlevel ();
		Instance = this;
		//Debug.Log (StaticVAriables.mGameState);

		//if (AdsManager.myScript != null)
		//{
		//	AdsManager.myScript.IngameAd (StaticVAriables._iCurrentLevel);
		//}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void StartGame ()
	{
		
	}
}
