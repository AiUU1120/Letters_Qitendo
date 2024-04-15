using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control0 : MonoBehaviour
{
    public Image BG;
    public DialogueData_SO D1, D2;
    private int num = 1;
    private void Awake()
    {
        BG.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(D1);
        DialogueUI.Instance.UpdateMainDialogue(D1.dialoguePieces[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    BG.gameObject.SetActive(true);
                    DialogueUI.Instance.UpdateDialogue(D2);
                    DialogueUI.Instance.UpdateMainDialogue(D2.dialoguePieces[0]);
					AudioController.Instance?.PlayMusic("Ambiance_City_Traffic_01");
					num++;
                    break;
                case 2:
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    break;
            }
        }
    }
}
