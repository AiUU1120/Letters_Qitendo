using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital12 : MonoBehaviour
{
    public Image BG;
    public DialogueData_SO DS1, DS2, DS3;
    private int num = 1;
    private void Awake()
    {
        BG.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(DS1);
        DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    BG.gameObject.SetActive(false);
                    DialogueUI.Instance.UpdateDialogue(DS2);
                    DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
                    num++;
                    break;
                case 2:
                    DialogueUI.Instance.UpdateDialogue(DS3);
                    DialogueUI.Instance.UpdateMainDialogue(DS3.dialoguePieces[0]);
                    num++;
                    break;
                case 3:
                    num++;
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    break;
            }
        }
    }
}
