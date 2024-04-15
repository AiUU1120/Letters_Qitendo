using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSceneChange : MonoBehaviour
{
    bool Ishere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag && Ishere)
        {
            ProcessController.Instance.GoNextScene("2-1");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision != null)
        {
            Debug.Log("123");
            Ishere = true;
        }
    }
}
