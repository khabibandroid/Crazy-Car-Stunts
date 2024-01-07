using UnityEngine;
using System.Collections;

public class CharacterAnimSelector : MonoBehaviour {
	public bool run,walk,dead,idle,dancing,sitting,crouch,climbingRope,shoot,withGun,psycoRun,slowRun,sitOnRoad,yelling,talkingOnPhone,girlTalking,tellingSecret,hanging;
	public bool _changeState;
	[HideInInspector]
	public Animator _animator;

	void Start () 
	{
		_animator = this.GetComponent<Animator> ();
	}
	
 
	void Update () 
	{
		if(_changeState)
		{
			ChangeState();
			_changeState = false;
		}

	}
	void ChangeState()
	{
		_animator.SetBool ("WithGun", withGun);
		_animator.SetBool ("ClimbingRope", climbingRope);
		_animator.SetBool ("Dancing", dancing);
		_animator.SetBool ("Sitting", sitting);
		_animator.SetBool ("PsycoRun", psycoRun);
		_animator.SetBool ("TalkingOnPhone", talkingOnPhone);
		_animator.SetBool ("GirlTalking", girlTalking);
		_animator.SetBool ("TellingSecret", tellingSecret);
		_animator.SetBool ("SittingOnRoad", sitOnRoad);
		_animator.SetBool ("Yelling", yelling);
		_animator.SetBool ("Hanging", hanging);
		_animator.SetBool ("Run", run);
		_animator.SetBool ("Walk", walk);
		_animator.SetBool ("Dead", dead);
		_animator.SetBool ("Idle", idle);
		_animator.SetBool ("Crouch", crouch);
		_animator.SetBool ("Shoot", shoot);
		_animator.SetBool ("SlowRun", slowRun);
	}
}
