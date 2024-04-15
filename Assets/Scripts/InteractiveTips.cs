using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveTips : MonoBehaviour
{
    [SerializeField, Header("交互指示")]
    TextMeshProUGUI Tips;

    private void Awake()
    {
        if(Tips != null)
		    Tips.enabled = false;
    }

	#region APIs
	public void StartInteracting(GameObject obj)
    {
        if(obj != null)
        {
            Debug.Log("正在接触" + obj.name);
            if(Tips != null)
            {
				Tips.enabled = true;
			}
            else
            {
                Debug.Log("Tips没啦！");
            }
		}
    }

	public void StopInteracting()
    {
		if (Tips != null)
			Tips.enabled = false;
	}
	#endregion

}
