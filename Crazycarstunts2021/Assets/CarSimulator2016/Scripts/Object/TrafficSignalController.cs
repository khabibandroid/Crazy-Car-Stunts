using UnityEngine;
using System.Collections;


public enum Signals
{
    None,
	Red,
	Yellow,
	Green

}
[System.Serializable]
public class SignalType
{
	public  Signals eSignalType=Signals.None;
}


public class TrafficSignalController : MonoBehaviour 
{
	public int Mypos;
	public SignalType eSignalTypeState;
	public GameObject _goRedLight,_goYellowLight,_goGreenLight,_goCrossLIne;
	public float miLightTimer;

	void Start()
	{
		LIghtningFunction ();
	}


	void LIghtningFunction()
	{
		if(eSignalTypeState.eSignalType==Signals.Yellow)
		{
			this.StartCoroutine (YellowLight ());
		}
		else
		{
			this.StartCoroutine (TrafficSingal(miLightTimer));
		}
	}
	IEnumerator YellowLight()
	{

		while (true)
		{
			yield return new WaitForSeconds (0.5f);
			_goYellowLight.SetActive (false);
			_goRedLight.SetActive (false);
			_goGreenLight.SetActive (false);
			yield return new WaitForSeconds (0.5f);
			_goYellowLight.SetActive (true);
			_goRedLight.SetActive (false);
			_goGreenLight.SetActive (false);

		}

	}
	IEnumerator TrafficSingal(float mfTime)
	{
//		while (true)
//		{
//			if (this.Mypos == 1)
//			{
//				this.Mypos = 0;
//				_goRedLight.SetActive (true);
//				this._goCrossLIne.GetComponent<Crossline> ().mbGreen = true;
//				this._goCrossLIne.GetComponent<Crossline> ().mbREd = false;
//				_goGreenLight.SetActive (false);
//				yield return new WaitForSeconds (mfTime);
//			}
//
//			else if (this.Mypos == 0)
//
//				this.Mypos = 1;
//				_goRedLight.SetActive (false);
//				this._goCrossLIne.GetComponent<Crossline> ().mbGreen = false;
//				this._goCrossLIne.GetComponent<Crossline> ().mbREd = true;
//				this._goGreenLight.SetActive (true);
//				yield return new WaitForSeconds (mfTime);
//			}
//
//
//
//		}
	while (true)
	{
			_goYellowLight.SetActive (false);
			if (this.Mypos == 1)
			{
				this.Mypos = 0;
				_goRedLight.SetActive (false);
				_goGreenLight.SetActive (true);
				_goCrossLIne.SetActive (false);
				_goYellowLight.SetActive (false);
				yield return new WaitForSeconds (mfTime);
			} else if (this.Mypos == 0)
			{

				this.Mypos = 1;
				_goRedLight.SetActive (true);
				this._goGreenLight.SetActive (false);
				_goCrossLIne.SetActive (true);
				_goYellowLight.SetActive (false);
				yield return new WaitForSeconds (mfTime);
			}
	}



}

}
