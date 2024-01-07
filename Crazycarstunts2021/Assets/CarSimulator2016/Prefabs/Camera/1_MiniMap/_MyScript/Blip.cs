using UnityEngine;
using System.Collections;

public class Blip : MonoBehaviour
{

    public Transform mt_targetPosi;
    public bool mb_keepInBound = true;
    public bool mb_lockScale = false;
    public bool mb_lockRotation = false;

    private MiniMap mscript_map;
    private RectTransform mrect_posi;
    // Use this for initialization
    void Awake()
    {
		if (gameObject.name == "Player" && GAmeplayScript.Instance)
			mt_targetPosi = GAmeplayScript.Instance.transform;
		

    }

    void Start()
    {
//		mt_targetPosi = LevelManagerScript.Instance._goPlayerCar.transform;
        mscript_map = GetComponentInParent<MiniMap>(); 
        mrect_posi = GetComponent<RectTransform>();

		if (gameObject.name == "Player"&& GAmeplayScript.Instance)
			mt_targetPosi = GAmeplayScript.Instance.transform;
    }
	
    // Update is called once per frame
    void LateUpdate()
    {
        if (mt_targetPosi == null)
            return;

        Vector2 newPosi = mscript_map.TransformPosition(mt_targetPosi.position);

        if (mb_keepInBound)
        {
            newPosi = mscript_map.ClampInMap(newPosi);
        }

        if (!mb_lockScale)
        {
            mrect_posi.localScale = new Vector3(mscript_map.mf_zoomLevel, mscript_map.mf_zoomLevel, 1);
        }

        if (!mb_lockRotation)
        {
            mrect_posi.localEulerAngles = mscript_map.TransformRotation(mt_targetPosi.eulerAngles);
        }

        mrect_posi.localPosition = newPosi;
    }
}
