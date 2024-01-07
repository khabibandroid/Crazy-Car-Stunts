using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowUI : MonoBehaviour 
{

    public GameObject uiObject;
    public Image mud;
    void Start()
    {
        uiObject.SetActive(false);
        mud.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "mud1")
        {
            uiObject.SetActive(true);
            mud.gameObject.SetActive(true);
            StartCoroutine("WaitForSec");
            Debug.Log("mud");
            
        }
	}
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
        Destroy(mud);
        
    }
    
}
