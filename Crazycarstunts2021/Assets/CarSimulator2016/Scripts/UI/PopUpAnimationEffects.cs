using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpAnimationEffects : MonoBehaviour 
{

	public GameObject[] PopUpObjects;
	public GameObject BG_panel;

	public IEnumerator  OnEntryAnimation(eGAME_STATE nextstat)
	{if (GetComponent<iTween>())
		Destroy(GetComponent<iTween>());
		for (int i = 0; i < PopUpObjects.Length; i++)
			PopUpObjects[i].transform.transform.localScale = Vector3.zero;

		if (BG_panel)
			BG_panel.GetComponent<Image>().color = new Color(1, 1, 1, 0);
		//        if (Btn_Next)
		//            Btn_Next.transform.localScale = Vector3.zero;

		yield return new WaitForSeconds(0.1f);
		//        SoundManager.Instance.PlayAnimationEffect();
		if (BG_panel)
			iTween.ValueTo(BG_panel, iTween.Hash("from", 0f, "to", 1f, "time", 0.1f, "onupdatetarget", gameObject, "onupdate", "OnPanelFade"));

		yield return new WaitForSeconds(0.15f);

		for (int i = 0; i < PopUpObjects.Length; i++)
		{
			iTween.ScaleTo(PopUpObjects[i], iTween.Hash("Scale", Vector3.one, "time", 0.05f, "easetype", iTween.EaseType.spring));
			yield return new WaitForSeconds(0.035f);
		}
	

		yield return new WaitForSeconds(0.05f);



		StaticVAriables.mGameState = nextstat;
	}

	public IEnumerator OnExitAnimation()
	{
		yield return new WaitForSeconds (0.3f);
		gameObject.SetActive (false);
	}

}
