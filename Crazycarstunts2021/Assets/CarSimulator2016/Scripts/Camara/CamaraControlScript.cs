using UnityEngine;
using System.Collections;

public class CamaraControlScript : MonoBehaviour
{
	Vector2 _VmouseAbsolute;
	Vector2 _VsmoothMouse;

	public Vector2 _VclampIndegrees=new Vector2(360,180);
	public bool lockCursor;
	public Vector2 Vsensitivity = new Vector2 (2, 2);
	public Vector2 Vsmoothing=new Vector2(3,3);
	public Vector2 VtargetDirection;
	public Vector2 VtargetCharacterDirection;

	public GameObject Gtarget;

	void Start () 
	{
		VtargetDirection = transform.localRotation.eulerAngles;
		if (Gtarget)
			VtargetCharacterDirection = Gtarget.transform.localRotation.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Cursor.lockState = CursorLockMode.Locked;
		var targetOrientation = Quaternion.Euler (VtargetDirection);
		var tartgetCharacetrOrientation = Quaternion.Euler (VtargetCharacterDirection);
		var mousedelta=new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
		mousedelta = Vector2.Scale (mousedelta, new Vector2 (Vsensitivity.x * Vsmoothing.x, Vsensitivity.y * Vsmoothing.y));
		_VsmoothMouse.x = Mathf.Lerp (_VsmoothMouse.x, mousedelta.x, 1f / Vsmoothing.x);
		_VsmoothMouse.y = Mathf.Lerp (_VsmoothMouse.y, mousedelta.y, 1f / Vsmoothing.y);


		_VmouseAbsolute += _VsmoothMouse;
		if (_VclampIndegrees.x < 360)
			_VmouseAbsolute.x = Mathf.Clamp (_VmouseAbsolute.x, -_VclampIndegrees.x * 0.5f, _VclampIndegrees.x * 0.5f);


		var Xrotation = Quaternion.AngleAxis (-_VmouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = Xrotation;

		if (_VclampIndegrees.y < 360)
			_VmouseAbsolute.y = Mathf.Clamp (_VmouseAbsolute.y, -_VclampIndegrees.y * 0.5f, _VclampIndegrees.y* 0.5f);
		transform.localRotation *= targetOrientation;


			

		if (Gtarget) {
			var Yrotation = Quaternion.AngleAxis (_VmouseAbsolute.x, Gtarget.transform.up);
			Gtarget.transform.localRotation = Yrotation;
			Gtarget.transform.localRotation *= tartgetCharacetrOrientation;
		} 
		else
		{
			var Yrotation = Quaternion.AngleAxis (_VmouseAbsolute.x, transform.InverseTransformDirection (Vector3.up));
			transform.localRotation *= Yrotation;
		}

	}
}
