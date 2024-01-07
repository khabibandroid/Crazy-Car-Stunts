using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapHandler : MonoBehaviour
{
    public static MapHandler Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDisable()
    {
        if (Instance != null)
            Instance = null;
    }


    public GameObject _TargetPrefab;
    public GameObject _PlayerUI, _BaseUI;
    public Transform _parentTransform;
   

//    public Sprite _Crab, _SqubaDiver, _smallFishes, _Tutle, _stingRay, _Lobstar, _SpearFish, _Kobra, _Striped, _Dolphin, _Anglar, _Spuid, _Macreal, _BlowFish, _TreasureBox;
    List<GameObject> _ObjectsForMap = new List<GameObject>();
    List<GameObject> _UIObjectsIndicatingEnemies = new List<GameObject>();

    public void InitilaizeMapDatas(GameObject[] _TargetObjects)
    {
		
//        GameObject[] _AddedObj = _targetObjectsArray[getLevelVal() - 1]._LevelObjects[positionVal]._TargetObjects;

        for (int i = 0; i < _TargetObjects.Length; i++)
        {
            _ObjectsForMap.Add(_TargetObjects[i]);
            createIndicator(_TargetObjects[i]);
        }
    }

    bool isPause = false;

    void Update()
    {
		if (StaticVAriables.mGameState != eGAME_STATE.GamePlay )
        {
            isPause = true;
            _PlayerUI.SetActive(false);
            _BaseUI.SetActive(false);
            if (_UIObjectsIndicatingEnemies != null && _UIObjectsIndicatingEnemies.Count > 0)
            {
                for (int i = 0; i < _UIObjectsIndicatingEnemies.Count; i++)
                {
                    GameObject _obj = _UIObjectsIndicatingEnemies[i];
                    _obj.SetActive(false);
                }
            }
        }
		else if (isPause &&StaticVAriables.mGameState == eGAME_STATE.GamePlay)
        {
            isPause = false;
            _PlayerUI.SetActive(true);
            _BaseUI.SetActive(true);
            if (_UIObjectsIndicatingEnemies != null && _UIObjectsIndicatingEnemies.Count > 0)
            {
                for (int i = 0; i < _UIObjectsIndicatingEnemies.Count; i++)
                {
                    GameObject _obj = _UIObjectsIndicatingEnemies[i];
                    _obj.SetActive(true);
                }
            }
        }
    }

    void createIndicator(GameObject _ObjToTrack)
    {
        GameObject Obj = Instantiate(_TargetPrefab);
        Obj.transform.parent = _parentTransform;
        Obj.transform.localScale = Vector3.one;



        Obj.GetComponent<Blip>().mt_targetPosi = _ObjToTrack.transform;
        _UIObjectsIndicatingEnemies.Add(Obj);
        Obj.SetActive(true);
    }

    public void CheckForDestroyedObjects(GameObject _obj)
    {
        if (_ObjectsForMap.Contains(_obj))
        {
            int indexVal = _ObjectsForMap.IndexOf(_obj);

           
            GameObject Indicator = _UIObjectsIndicatingEnemies[indexVal];
//            if (Indicator.GetComponent<Behaviour_AiFish>() != null)
//            {
//                if (Indicator.GetComponent<Behaviour_AiFish>().enum_FishType == e_TYPES_OF_FISH.Smallfish)
//                {
//                    int DiverValue = PlayerPrefs.GetInt("KilledSmallFishes") + 1;
//                    PlayerPrefs.SetInt("KilledSmallFishes", DiverValue);
//                    AchivementHandler.Instance.CountNoOfSmallFishes();
//                }
//                if (Indicator.GetComponent<Behaviour_AiFish>().enum_FishType == e_TYPES_OF_FISH.Crab_Large)
//                {
//                    int DiverValue = PlayerPrefs.GetInt("BigCrabNO") + 1;
//                    PlayerPrefs.SetInt("BigCrabNO", DiverValue);
//                    AchivementHandler.Instance.EatFirstBigCrab();
//                }
//            }
            _UIObjectsIndicatingEnemies.RemoveAt(indexVal);
            Destroy(Indicator);
            _ObjectsForMap.RemoveAt(indexVal);


        }
    }

    void DestroyAll()
    {
        for (int i = _UIObjectsIndicatingEnemies.Count - 1; i >= 0; i--)
        {
            GameObject Indicator = _UIObjectsIndicatingEnemies[i];
            _UIObjectsIndicatingEnemies.RemoveAt(i);
            Destroy(Indicator);
        }
    }

    int getLevelVal()
    {
        int levelVal = 1;
        {
			levelVal = StaticVAriables._iCurrentLevel / 2;

			if (StaticVAriables._iCurrentLevel % 2 != 0)
                levelVal++;

        }
        //      Debug.Log ("LEVEL VAL IN MAP____ " + levelVal);
        return levelVal;
    }
}

//[System.Serializable]
//public class LevelGameObjects
//{
//    public TargetInPoitions[] _LevelObjects;
//}
//
//[System.Serializable]
//public class TargetInPoitions
//{
//    public GameObject[] _TargetObjects;
//}