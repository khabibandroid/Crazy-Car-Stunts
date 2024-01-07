using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{


    public Transform mt_target;
    public float mf_zoomLevel;

    Vector2 xRot = Vector2.right;
    Vector2 yRot = Vector2.up;

    // Use this for initialization
    void Start()
    {
        if (mt_target == null)
			mt_target = GAmeplayScript.Instance.transform;
    }

    void Awake()
    {
		mt_target = LevelManagerScript.Instance._goPlayerCar.transform;
		
		if (GAmeplayScript.Instance)
			mt_target = GAmeplayScript.Instance.transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        xRot = new Vector2(mt_target.right.x, -mt_target.right.z);
        yRot = new Vector2(-mt_target.forward.x, mt_target.forward.z);
    }

    public Vector2 TransformPosition(Vector3 position)
    {
        Vector3 offset = position - mt_target.position;
        Vector2 newDisplayPosition = offset.x * xRot;                                                                        //new Vector2 (offset.x, offset.z); this without Rotation Value
        newDisplayPosition += offset.z * yRot;
        newDisplayPosition *= mf_zoomLevel;     
        return newDisplayPosition;
    }

    public Vector3 TransformRotation(Vector3 rotation)
    {
        return new Vector3(0, 0, mt_target.eulerAngles.y - rotation.y);
    }


    public Vector2 ClampInMap(Vector2 point)
    {
        Rect _mapRect = GetComponent<RectTransform>().rect;

        point = Vector2.Min(point, _mapRect.max);
        point = Vector2.Max(point, _mapRect.min);
      
        return point;
    }
}
