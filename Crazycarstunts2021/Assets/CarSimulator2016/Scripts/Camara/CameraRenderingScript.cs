using UnityEngine;
using System.Collections;

public class CameraRenderingScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		float[] cullMaskArray;
		cullMaskArray = new float[32];
		cullMaskArray [24] = 200; 
		cullMaskArray [25] = 150; 
		cullMaskArray [26] = 100; 
		cullMaskArray [27] = 80; 
		cullMaskArray [28] = 50; 
		cullMaskArray [29] = 80; 
		cullMaskArray [30] = 50; 
		cullMaskArray [31] = 50; 
		Camera.main.layerCullDistances = cullMaskArray;
	}
}
