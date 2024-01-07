//using UnityEngine;
//using System.Collections;
//
//public class AiFindingCollision : MonoBehaviour 
//{
//	public Transform go_Myparent;
//	bool mbmoveAi = true;
//	public GameObject go_Signal;
//	//SignalType eSignatype= Signals.None;
//
//	void Start()
//	{
//		go_Myparent = this.gameObject.transform.parent;
//	}
//
//	bool isPause	= false;
//
//	void OnTriggerEnter(Collider col)
//	{
//		
//		if (col.gameObject.tag == "AICARS"  || col.gameObject.tag == "Player")
//		{
//			this.mbmoveAi = false;
//			this.go_Myparent.GetComponent<hoMove> ().Pause ();
//			//Debug.Log ("Am hited back");
//		}
//		if (col.gameObject.tag == "CrossLIne")
//		{
//			
//			if (col.gameObject.GetComponent<Crossline> ().mbREd)
//				
//			{
//				go_Signal = col.gameObject;
//				isPause = true;
//				this.go_Myparent.GetComponent<hoMove> ().Pause ();
//
//			}
//			else if (col.gameObject.GetComponent<Crossline> ().mbGreen)
//			{
//				
//				this.go_Myparent.GetComponent<hoMove> ().Resume ();
//			}
//		}
//
//	}
//	void Update()
//	{
//		if (go_Signal != null)
//		{
//			if (go_Signal.GetComponent<Crossline> ().mbREd && isPause == false)
//			{
//				isPause	= true;
//				this.go_Myparent.GetComponent<hoMove> ().Pause ();
//			}
//			else if (go_Signal.GetComponent<Crossline> ().mbGreen && isPause)
//			{
//				isPause	= false;
//				this.go_Myparent.GetComponent<hoMove> ().Resume ();
//				go_Signal	= null;
//			}
//		}
//	}
//	void OnTriggerExit(Collider col)
//	{
//		if (col.gameObject.tag == "Player" || col.gameObject.tag == "AICARS")
//		{
//			this.go_Myparent.GetComponent<hoMove> ().Resume ();
//
//		
//		}
//
//			
////		this.mbmoveAi = true;    // Senthil
////		this.go_Myparent.GetComponent<hoMove> ().Resume ();
//
//
////		if (col.gameObject.GetComponent<Crossline> ())
////		{
////			if(col.gameObject.GetComponent<Crossline>().mbGreen)
////			    this.go_Myparent.GetComponent<hoMove> ().Resume ();
////			else
////				this.go_Myparent.GetComponent<hoMove> ().Pause ();
////		}
////		else
////			this.go_Myparent.GetComponent<hoMove> ().Resume ();
//
//	}
//	void OnTriggerStay(Collider col)
//	{
//		return;
//		Debug.Log ("Inside Trigger stay");
//		if (col.gameObject.tag == "CrossLIne")
//		{
//			
//			if (col.gameObject.GetComponent<Crossline> ().mbREd)
//			{
//				
//				go_Signal = col.gameObject;
//				this.go_Myparent.GetComponent<hoMove> ().Pause ();
//
//			} 
//			else if (col.gameObject.GetComponent<Crossline> ().mbGreen)
//			{
//				go_Signal =null;
//				this.go_Myparent.GetComponent<hoMove> ().Resume ();
//
//			}
//			
//		}
//		if( col.gameObject.tag == "Player"||col.gameObject.tag == "AICARS")
//		{
//			this.go_Myparent.GetComponent<hoMove> ().Pause ();
//		}
//	}
//
//
//
//}
