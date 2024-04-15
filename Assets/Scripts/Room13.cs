using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room13 : MonoBehaviour
{
    public Image BG;
    public DialogueData_SO DS1, DS2, DS3;
    public MoveAndAnimationController Qi;
    private int num = 1;
    private void Awake()
    {
        Qi.EnableMove = false;
        Qi.EnableAnim = false;
        BG.gameObject.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(DS1);
        DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);

        AudioController.Instance.PlayMusic("n60");
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
					AudioController.Instance.PlayMusic("Real Pianos - Defeat");
					BG.gameObject.SetActive(true);
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
                    BG.gameObject.SetActive(false);
                    Qi.EnableMove = true;
                    Qi.EnableAnim = true;
                    num++;
                    break;
                case 4:
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    num++;
                    break;
            }

        }
    }
}
