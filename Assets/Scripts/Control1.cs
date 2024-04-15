using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control1 : MonoBehaviour
{
    private int num = 1;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    num++;
                    break;
                case 2:
                    Debug.Log("123");
                    ProcessController.Instance.GoNextScene();
                    break;
            }
        }
    }
}
