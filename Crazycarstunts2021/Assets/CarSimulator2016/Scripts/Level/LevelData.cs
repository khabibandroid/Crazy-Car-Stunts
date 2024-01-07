using UnityEngine;
using System.Collections.Generic;


public class LevelData : MonoBehaviour 
{
	public LevelTargets _LevelTargets;
	// display on screen task;

}
[System.Serializable]
public class LevelTargets
{
	public LevelObjects[] _levelObjects; 
	public  float _TimerForLevel=-9999;
	public GameObject _StartPOS;
	public List <GameObject> _TargetsOnMap=new List<GameObject>();
	//public string   Task;

}
[System.Serializable]
public class LevelObjects
{
	public eLEVEL_TYPE  _LevelType= eLEVEL_TYPE.None;
	public int _iTargetCount = 0;
	public float _iTimeforLevel=0;

}
