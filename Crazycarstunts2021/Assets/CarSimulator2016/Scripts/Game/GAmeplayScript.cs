using UnityEngine;
using System.Collections;

public class GAmeplayScript : MonoBehaviour
{
	public static GAmeplayScript Instance;
	bool mbFrontpark,mbBackpark;
	bool mbpicked,mbdroped;
	bool mbCheckpoint;
	bool mbStart,mbEnd;
	float mitimer=0;
	float miCarpicktime=0;
	float miCarDroptime=0;

	public Transform DeletingObjct;
	public Transform DeletePArkingArea;
	Transform go_PassengerParent;
	Transform  go_passenger;
	public GameObject go_CamaraParent;
	bool mbSignal;


	void Start()
	{
		go_CamaraParent = GameObject.FindWithTag ("CamaraParent");

	}
	void Update()
    {
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay)
		{
			return;
		}




		Targetbasedgameplay ();
		ParkingCheck ();
		CheckPonit ();
		TimebasedPLay ();
		TimebasedRaceGAmeplay ();
		TAilinggameplay ();
	}
	void OnTriggerEnter(Collider col)
	{
		if(StaticVAriables.mGameState== eGAME_STATE.GamePlay)
		{
			if(col.gameObject.tag=="AICARS")
			{
				LevelManagerScript.Instance.PlayerhitAiFunction ();
			}

			if(col.gameObject.tag=="SignalTrigger")
			{
				if(col.gameObject.transform.GetComponentInParent<TrafficSignalController>().Mypos!=1)
				{
					mbSignal = true;
					UI_handlerScript.Instance.SetuiSignal (mbSignal);
				}
				else if(col.gameObject.transform.GetComponentInParent<TrafficSignalController>().Mypos!=0)
				{
					     mbSignal = false;
						UI_handlerScript.Instance.SetuiSignal (mbSignal);
				}
			}
		}
		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Parking)
		{
			if (col.gameObject.name == "Front")
			{
				mbFrontpark = true;
				DeletingObjct = col.gameObject.transform.parent;
			}
			if (col.gameObject.name == "Back")
			{
				DeletingObjct = col.gameObject.transform.parent;
				mbBackpark = true;
			}
		}
		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.CheckPoint)
		{
			if (col.gameObject.tag == "Checkpoint")
			{
				if (!mbCheckpoint)
					mbCheckpoint = true;
				DeletingObjct = col.gameObject.transform.parent;

			}
		}

		//// target based game play





		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Target_Based)
		{
			if(col.gameObject.name=="PickupArea")
			{
				//Debug.Log ("am in pickup Area");
				go_PassengerParent = col.gameObject.transform.parent;
				mbpicked = true;
				DeletePArkingArea = col.gameObject.transform;
			
			}
			if(col.gameObject.name=="DropArea")
			{
				mbdroped = true;
				DeletePArkingArea = col.gameObject.transform;
			}

			if(col.gameObject.name=="Passenger")
			{
				go_passenger = col.gameObject.transform;
				go_passenger.gameObject.SetActive (false);
				go_passenger.GetComponent<BoxCollider> ().enabled = false;
				DeletingObjct = col.gameObject.transform;

			}
		}

		//timebased  game play            


		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Time_Based)
		{
			if(col.gameObject.tag=="Start")
			{
				mbStart = true;
				//Debug.Log ("Am started");
			}
			if(col.gameObject.tag=="End")
			{
				
				if(mbStart)
				{
					//Debug.Log ("Am reached");
					mbEnd = true;
				}
			}
		}
		//tailing gameplay
		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Tailing)
		{
			if(col.gameObject.tag=="Start")
			{
				mbStart = true;
				//Debug.Log ("Am started");
			}
			if(col.gameObject.tag=="End")
			{

				if(mbStart)
				{
					//Debug.Log ("Am reached");
					mbEnd = true;
				}
			}
		}


	}
	void OnTriggerExit(Collider col)
	{
		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Parking)
		{
			if (col.gameObject.name == "Front")
			{
			
				mbFrontpark = false;
				mitimer = 0;
			}
			if (col.gameObject.name == "Back")
			{
				mbBackpark = false;
				mitimer = 0;
			}
		}
		if (StaticVAriables.mLevelstate == eLEVEL_TYPE.Target_Based)
		{
			if(col.gameObject.name=="PickupArea")
			{
				//Debug.Log ("am in pickup Area");
				mbpicked = false;
			}
			if(col.gameObject.name=="DropArea")
			{
				mbdroped = false;
			}
		}

		if(col.gameObject.tag=="SignalTrigger")
		{
			

			Invoke ("Signalfunction",0.1f);

		}

	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag=="SignalTrigger")
		{
			if(col.gameObject.transform.GetComponentInParent<TrafficSignalController>().Mypos!=1)
			{
				mbSignal = true;
				UI_handlerScript.Instance.SetuiSignal (mbSignal);
			}
			else if(col.gameObject.transform.GetComponentInParent<TrafficSignalController>().Mypos!=0)
			{
				mbSignal = false;
				UI_handlerScript.Instance.SetuiSignal (mbSignal);
			}
		}

	}
	void ParkingCheck()
	{
		if (mbBackpark && mbFrontpark)
		{
			if (mitimer < 10)
			{
				mitimer += Time.deltaTime*10 ;
				//Debug.Log (mitimer);
			} 
			else
			{
				//Debug.Log ("parkinf done");
				mbBackpark = false;
				mbFrontpark = false;
				LevelManagerScript.Instance.CarParkingfunction ();
				//Destroy ((DeletingObjct.gameObject));
				DeletingObjct.gameObject.SetActive (false);


			}

		}
		else if (!mbBackpark || !mbFrontpark)
		{
			//Debug.Log ("reset");
			mitimer = 0;
		}
	}

	void Signalfunction()/// signal ui distroy
	{
		
		UI_handlerScript.Instance.deacivateSignal();
	}
	void CheckPonit()
	{
		if(mbCheckpoint)
		{
			mbCheckpoint = false;
			LevelManagerScript.Instance.CheckPointFunction ();
			LevelManagerScript.Instance.ActivateCheckpoint ();
			//Destroy ((DeletingObjct.gameObject.SetActive (false)));
			DeletingObjct.gameObject.SetActive (false);
			//Debug.Log ("Lagging");

		}
	}
	void TimebasedPLay()
	{
		LevelManagerScript.Instance.TimeBasedgameplay ();

	}

	void Targetbasedgameplay()
	{
		if (mbpicked)
		{
			if (miCarpicktime < 30)
			{
				miCarpicktime += Time.deltaTime * 10;
			} 
			else
			{
				
				//Destroy (DeletePArkingArea.gameObject);
				DeletePArkingArea.gameObject.SetActive (false);
//				Debug.Log ("Getin");
				//go_CamaraParent.GetComponent<CamaraSettings>().PAssengerEntryCamara ();///camara Seffect
				mbpicked = false;
				PassengerScript.mPassengerstate = ePassengerState.Pickup;
				go_PassengerParent.GetComponent<PassengerScript> ().PassengerBehaviuor ();



			}
		}
		else
			miCarpicktime = 0;


		if (mbdroped)
		{
			if (miCarDroptime < 30)
			{
				miCarDroptime += Time.deltaTime * 10;
				//Debug.Log (miCarDroptime);
			} 
			else
			{
				if (PassengerScript.mPassengerstate == ePassengerState.Oncar)
				{
					//Destroy (DeletePArkingArea.gameObject);
					DeletePArkingArea.gameObject.SetActive (false);
					mbdroped = false;
					PassengerScript.mPassengerstate = ePassengerState.Drop;
					go_PassengerParent.GetComponent<PassengerScript> ().PassengerBehaviuor ();
					LevelManagerScript.Instance.TargetBased ();
				}
				else
				{
					Debug.Log ("You should pickup passenger");
				}

			}
		} 
		else
			miCarDroptime = 0;

		
	}
	void TimebasedRaceGAmeplay()
	{
		if(mbEnd)
		{
			LevelManagerScript.Instance.TimerRacegamePLay ();
		}
		
	}
	void TAilinggameplay()
	{
		if(mbEnd)
		LevelManagerScript.Instance.Tailingplayer ();
	}


	void AiCarCollision()
	{
		LevelManagerScript.Instance.PlayerhitAiFunction ();
	}

}
