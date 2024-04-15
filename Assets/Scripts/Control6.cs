using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control6 : MonoBehaviour
{
    public Button b1;
    public Image meal, zhenban,livingroom;
    public DialogueData_SO DS1,DS2;
    public GameObject qi, mama;
    private int num = 1;
    private bool IsClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        b1.gameObject.SetActive(false);
        meal.gameObject.SetActive(false);
        zhenban.gameObject.SetActive(false);

        AudioController.Instance.PlayMusic("Casual - Level 1 (Loop_02)");

	}

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            if (IsClicked)
            {
                num++;
                IsClicked = false;
            }

            switch (num)
            {
                case 1:
                    zhenban.gameObject.SetActive(true);
                    livingroom.gameObject.SetActive(false);
                    qi.SetActive(false);
                    mama.SetActive(false);
                    DialogueUI.Instance.UpdateDialogue(DS1);
                    DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);
                    num++;
                    break;
                case 2:
                    b1.gameObject.SetActive(true);
                    break;
                case 3:
                    Debug.Log("TODO");
                    zhenban.gameObject.SetActive(false);
                    meal.gameObject.SetActive(true);
                    DialogueUI.Instance.UpdateDialogue(DS2);
                    DialogueUI.Instance.UpdateMainDialogue(DS2.dialoguePieces[0]);
                    num++;
                    break;
                case 4:
                    Debug.Log("123");
                    ProcessController.Instance.GoNextScene();
                    break;

            }
        }
    }

    public void ButtonOnclick()
    {
        IsClicked = true;
        b1.gameObject.SetActive(false);
    }
}
