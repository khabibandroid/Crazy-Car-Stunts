using UnityEngine;
using System.Collections;

[AddComponentMenu ("Camera-Control/Smooth Follow CSharp")]

public class SmooothFollowCamera : MonoBehaviour
{
	public Transform PlayerPos;
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	public Transform MoveBackPos;

	bool isSideView;

	void Start ()
	{
		
	}

	void  LateUpdate ()
	{
//		if (GameplayManager.Instance.mGameState == eGAME_STATE.CameraChangeState)
//			return;

		// Early out if we don't have a target
//		if (!target && GameObject.Find ("CamLookAt"))
//		{
//			target = GameObject.Find ("CamLookAt").transform;
//		}
//		if (!MoveBackPos && GameObject.Find ("MoveBackPos"))
//		{
//			MoveBackPos = GameObject.Find ("MoveBackPos").transform;
//		}
//		if (!target)
//			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;


		isSideView	= true;//!GlobalVariables.g_bIsMoveBack;

		if (!isSideView)// || GameplayManager.Instance.mGameContoller != eGAME_CONTROLLER.Character)
		{
			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
			// Damp the height
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
			// Convert the angle into a rotation
			Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

			transform.position = target.position;

			transform.position = Vector3.Lerp (transform.position, target.position, 5 * Time.deltaTime);

			transform.position -= currentRotation * Vector3.forward * distance;
		
			// Set the height of the camera
			transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
		
		} else
		{
			transform.position = Vector3.Lerp (transform.position, MoveBackPos.position, 5 * Time.deltaTime);
		}
		// Always look at the target
		transform.LookAt (target);		             
	}
}