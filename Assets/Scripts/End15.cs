using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End15 : MonoBehaviour
{
    public Image BG2, BG3;
    public DialogueData_SO DS1, DS2, DS3;
    private int num = 1;
    // Start is called before the first frame update
    void Start()
    {
		BG2.gameObject.SetActive(false);
		BG3.gameObject.SetActive(false);
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
                    BG2.gameObject.SetActive(true);
                    DialogueUI.Instance.UpdateDialogue(DS2);
                    DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
                    num++;
                    break;
                case 2:
                    BG3.gameObject.SetActive(true);
                    DialogueUI.Instance.UpdateDialogue(DS3);
                    DialogueUI.Instance.UpdateMainDialogue(DS3.dialoguePieces[0]);
                    num++;
                    break;
                case 3:
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    num++;
                    break;
            }
            
            
        }
        
    }
}
