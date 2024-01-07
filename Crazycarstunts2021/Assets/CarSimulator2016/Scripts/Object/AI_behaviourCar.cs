using UnityEngine;
using System.Collections;

public class AI_behaviourCar : MonoBehaviour 
{
	Vector3 Vstartpos;
	float mzForward;
	public GameObject _origin;
	bool mbPause;
	private bool mbEnabled;
	void Awake()
	{
		


	}

	void Start () 
	{
		
	}
	

	void FixedUpdate () 
	{
		LineCastForColiision ();
		//Resetmypos ();
	}
	RaycastHit _hit;
	public void LineCastForColiision()
	{
		

		Debug.DrawRay (_origin.transform.position+_origin.transform.right*0.6f,_origin.transform.forward*3,Color.red);
		Debug.DrawRay (_origin.transform.position+(-_origin.transform.right)*0.6f,_origin.transform.forward*3,Color.red);
		Debug.DrawRay (_origin.transform.position,_origin.transform.forward*3,Color.red);
		if (Physics.Raycast (_origin.transform.position, _origin.transform.forward, out _hit, 3)||Physics.Raycast (_origin.transform.position+(-_origin.transform.right)*0.6f,_origin.transform.forward, out _hit, 3)
			||Physics.Raycast (_origin.transform.position+_origin.transform.right*0.6f,_origin.transform.forward, out _hit, 3))
		{
			//Debug.Log ("" + _hit.transform.name);
			this.gameObject.transform.GetComponent<hoMove> ().Pause ();
			this.mbPause = true;
		}
		else if(mbPause)
		{
			this.mbPause = false;
			this.gameObject.transform.GetComponent<hoMove> ().Resume ();
		}



			
	}

	private void Resetmypos()
	{
		if (LevelManagerScript.Instance._goPlayerCar != null&& StaticVAriables.mGameState==eGAME_STATE.GamePlay)
		{

			
			Vector3 Totarget = (LevelManagerScript.Instance._goPlayerCar.transform.position - transform.position);
			if (Vector3.Dot (Totarget, transform.forward) >0)
			{
				Debug.Log ("Am in front pos" + transform.name);
			}
			else if (Vector3.Dot (Totarget, transform.forward) <10)
			{
				if (gameObject.GetComponent <Renderer> ().isVisible == false)
				{
					Debug.Log ("Reseting pos" + transform.name);

				}
			}
		}
	}
}
