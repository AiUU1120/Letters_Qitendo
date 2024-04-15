using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control5 : MonoBehaviour
{
    public DialogueData_SO D1, D2;
    private int num = 1;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(D1);
        DialogueUI.Instance.UpdateMainDialogue(D1.dialoguePieces[0]);

        AudioController.Instance?.PlayMusic("n99");
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    DialogueUI.Instance.UpdateDialogue(D2);
                    DialogueUI.Instance.UpdateMainDialogue(D2.dialoguePieces[0]);
                    num++;
                    break;
                case 2:
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    num++;
                    break;
              
            }
        }
    }
}
