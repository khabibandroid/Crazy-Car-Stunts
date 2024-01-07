using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SavePoint : MonoBehaviour {

	private bool hasEntered = true;
	private bool hasEnteredTruckTrailer = true;

	public GameObject[] lightMaterials;


	private Vector3 YDisplacementCompensation = Vector3.zero;

	void Start(){
		
	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.tag == "Player" && hasEntered) {
			//SavePointHandler._instance.LastSavePointTransform = gameObject.transform;
		//	YDisplacementCompensation = SavePointHandler._instance.LastSavePointTransform.position;
			YDisplacementCompensation.y = Coll.transform.position.y;
		//	SavePointHandler._instance.LastSavePointTransform.position = YDisplacementCompensation;
			hasEntered = false;
			foreach (GameObject light in lightMaterials) {
				light.GetComponent<Renderer> ().material = Resources.Load ("GreenLight", typeof(Material)) as Material;
			}

//			if (StaticVariables.sv_ilevelSelected == 1 || StaticVariables.sv_ilevelSelected == 2) {
			//	GameManager.staticscript.checkPointText.SetActive(true);
//				Invoke ("DisableText",1.3f);
				Invoke ("DisableText",1f);
//			}
		}
	}



	void DisableText()
	{
		//GameManager.staticscript.checkPointText.SetActive(false);
		gameObject.GetComponent<BoxCollider> ().enabled = false;
	}

}
