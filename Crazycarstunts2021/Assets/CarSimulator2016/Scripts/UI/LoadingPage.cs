using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingPage : MonoBehaviour {

	public Image _goProgressBar;
	public Text _goLoadingText;
	AsyncOperation _AsyncProcess;
	void Start ()
	{
		StaticVAriables.mCurrentScene = eSCENE_STATE.Loading;
		GameObject _obj = new GameObject ();
		iTween.MoveTo (_obj,iTween.Hash ("x",10,"time",1f));
		_goProgressBar.fillAmount = 0;
		StartCoroutine (ChangeScenewithDelay (2f));

	}
	

	IEnumerator ChangeScenewithDelay(float Delay)
	{
		yield return new WaitForSeconds ((Delay));
		_AsyncProcess = SceneManager.LoadSceneAsync (StaticVAriables._SceneToLoad);
		_AsyncProcess.allowSceneActivation = true;

	}
	void Update()
	{
		if(_AsyncProcess!=null)
		{
			_goProgressBar.fillAmount = _AsyncProcess.progress / 0.09f;
			_goLoadingText.text="Loading  "+Mathf.FloorToInt ((_AsyncProcess.progress/0.9f)*100) +"%"; 
		}
	}
}
