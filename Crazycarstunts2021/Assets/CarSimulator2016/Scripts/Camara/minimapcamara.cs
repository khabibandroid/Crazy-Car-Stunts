using UnityEngine;
using System.Collections;

public class minimapcamara : MonoBehaviour
{

	public Transform _goTarget;
	public float mfCamraHeight;
	public float mfPLayerRotation;
	public float _mfSpeed;
	void Start () 
	{
		_goTarget = LevelManagerScript.Instance._goPlayerCar.transform;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(_goTarget!=null)
		{
			Vector3 Newpos = _goTarget.position;
			Vector3 NeWrot = transform.eulerAngles;
			Newpos.y = mfCamraHeight;
			NeWrot.y = _goTarget.eulerAngles.y;
			transform.position = Vector3.Lerp (transform.position, Newpos, Time.deltaTime * _mfSpeed);
			transform.eulerAngles = NeWrot;

		}
	}
}
