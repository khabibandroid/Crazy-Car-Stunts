using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {

	public Animator anim_Char;
	public AnimationHandler Instance;
	// Use this for initialization
	void Start ()
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RandomIdle()
	{
		int AnimPlay = Random.Range (0,3);

		anim_Char.SetInteger ("IdleType",AnimPlay);
		anim_Char.SetTrigger ("Idle");
	}

	public void WalkToCar()
	{
		anim_Char.SetTrigger ("WalkState");
	}
}
