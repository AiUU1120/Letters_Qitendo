using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control2 : MonoBehaviour
{
    private int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance.PlayMusic("Casual - Level 1 (Loop_01)");

	}

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    ProcessController.Instance?.GoNextScene();
                    break;
            }
        }
    }
}
