using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    public Image BG;
    public DialogueData_SO DS1,DS2;
    private int num = 1;
    private void Awake()
    {
        BG.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(DS1);
        DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);

        AudioController.Instance.PlayMusic("See The Light_Piano Loop_01");
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
                    DialogueUI.Instance.UpdateDialogue(DS2);
                    DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
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
