using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cakeshop10 : MonoBehaviour
{
    public DialogueData_SO D1, D2, D3;
    public Button c1, c2, b1, b2, b3;
    private bool F_cake = false;
    private int num = 1;

    public void setCake()
    {
        F_cake = true;
    }

    private void Awake()
    {
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
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
        D_update();
    }

    private void D_update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    c1.gameObject.SetActive(true);
                    c2.gameObject.SetActive(true);
                    num++;
                    break;
                case 2:
                    DialogueUI.Instance.UpdateDialogue(D2);
                    DialogueUI.Instance.UpdateMainDialogue(D2.dialoguePieces[0]);
                    num++;
                    break;
                case 3:
                    b1.gameObject.SetActive(true);
                    b2.gameObject.SetActive(true);
                    b3.gameObject.SetActive(true);
                    num++;
                    break;
                case 4:
                    DialogueUI.Instance.UpdateDialogue(D3);
                    DialogueUI.Instance.UpdateMainDialogue(D3.dialoguePieces[0]);
                    num++;
                    break;
                case 5:
                    Debug.Log("TODO-结束");
                    ProcessController.Instance.GoNextScene();
                    num++;
                    break;
            }
        }
    }
}
