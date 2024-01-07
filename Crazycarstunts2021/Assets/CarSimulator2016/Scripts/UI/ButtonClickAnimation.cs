using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickAnimation : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
	Image _img;


	// Use this for initialization

	void Start()
	{
		
		_img = GetComponent<Image>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//  transform.localScale = new Vector3(1.05f,1.05f,1.05f);
		if (!GetComponent<Image>().raycastTarget || !GetComponent<Button>().IsInteractable())
			return;

		if (GetComponent<iTween>())
		{
			iTween[] _itweenObj = GetComponents<iTween>();
			for (int i = _itweenObj.Length - 1; i >= 0; i--)
			{
				Destroy(_itweenObj[i]);
			}
		}
		SoundManager.staticscript_soundMgr.ButtonSound ();
		//        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one * 1.1f, "time", 0.5f, "delay", 0f, "easetype", iTween.EaseType.easeOutElastic));
		//        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one, "time", 0.1f, "delay", 0.35f, "easetype", iTween.EaseType.linear));

		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.95f, "y", 0.95f, "time", 0.1f, "delay", 0, "easetype", iTween.EaseType.easeInOutExpo));
		iTween.ScaleTo(gameObject, iTween.Hash("y", 0.95f, "x", 0.95f, "time", 0.1f, "delay", 0, "easetype", iTween.EaseType.easeInOutExpo));
		iTween.ScaleTo(gameObject, iTween.Hash("y", 1f, "x", 1f, "time", 0.1f, "delay", 0.25, "easetype", iTween.EaseType.easeInOutExpo));
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		//        if (GetComponent<iTween>())
		//        {
		//            iTween[] _itweenObj = GetComponents<iTween>();
		//            for (int i = _itweenObj.Length - 1; i >= 0; i--)
		//            {
		//                Destroy(_itweenObj[i]);
		//            }
		//        }
		//        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one, "time", 0.1f, "delay", 0.35f, "easetype", iTween.EaseType.linear));

	}


	void OnDisable()
	{
		if (gameObject.GetComponent<iTween>())
			Destroy(gameObject.GetComponent<iTween>());

		gameObject.transform.localScale = Vector3.one;
	}
}
