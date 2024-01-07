using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trigger : MonoBehaviour
{
    public GameObject mytargetobject;
   
    // Use this for initialization
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (mytargetobject.activeSelf)
        {
            mytargetobject.SetActive(true);
        }
        else
        {
            mytargetobject.SetActive(false);
        }
    }
}
