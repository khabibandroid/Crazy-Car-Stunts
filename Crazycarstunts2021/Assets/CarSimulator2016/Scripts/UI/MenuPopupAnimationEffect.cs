using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPopupAnimationEffect : MonoBehaviour 
{

	public GameObject go_BGpanel;
	public GameObject [] PouUpobjects;



	public IEnumerator  OnEntryAnimation(eMENU_STATE Nextstats)
	{
		for (int i = 0; i < PouUpobjects.Length; i++)
		{
			PouUpobjects[i].transform.localScale = Vector3.zero;
		}
		if (go_BGpanel)
			go_BGpanel.GetComponent<Image>().color = new Color(1, 1, 1, 0);

		yield return new WaitForSeconds(0.05f);
		transform.localPosition = Vector3.zero;
		//          SoundManager.Instance.PlayTitleEffect ();

		if (go_BGpanel)
			iTween.ValueTo(go_BGpanel, iTween.Hash("from", 0f, "to", 1f, "time", 0.5f, "onupdatetarget", gameObject, "onupdate", "OnPanelFade"));

		for (int i = 0; i < PouUpobjects.Length; i++)
		{
			iTween.ScaleTo(PouUpobjects[i], iTween.Hash("Scale", Vector3.one, "time", 0.65f, "easetype", iTween.EaseType.spring));
			yield return new WaitForSeconds(0.1f);
		}
		StaticVAriables.mMenuState = Nextstats;
	}

	public IEnumerator OnExitAnimation()
	{
		yield return new WaitForSeconds (0.1f);
		gameObject.SetActive (false);
	}
}
