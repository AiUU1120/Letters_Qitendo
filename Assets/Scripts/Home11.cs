using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home11 : MonoBehaviour
{
    public Image BG2, BG3;
    public DialogueData_SO D1, D3, D4;
    public Button button;
    public MoveAndAnimationController Qi;
    private int num = 1;
    private bool click = false;
    

    public void setClick()
    {
        click = true;
    }

    private void Awake()
    {
        BG2.gameObject.SetActive(true);
        BG3.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        Qi.EnableMove = false;
        Qi.EnableAnim = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.Instance.UpdateDialogue(D1);
        DialogueUI.Instance.UpdateMainDialogue(D1.dialoguePieces[0]);

        AudioController.Instance?.PlayMusic("n46");

	}

    // Update is called once per frame
    void Update()
    {
        D_update();
        if (click)
        {
            BG2.gameObject.SetActive(false);
            BG3.gameObject.SetActive(true);
            click = false;
        }
    }

    private void D_update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            switch (num)
            {
                case 1:
                    button.gameObject.SetActive(true);
                    Debug.Log("点蜡烛");
                    
                    num++;
                    break;
                case 2:
                    BG3.gameObject.SetActive(false);
                    DialogueUI.Instance.UpdateDialogue(D3);
                    DialogueUI.Instance.UpdateMainDialogue(D3.dialoguePieces[0]);
                    num++;
                    break;
                case 3:
                    
                    Qi.EnableMove = true;
                    Qi.EnableAnim = true;
                    num++;
                    break;
            }
            if (num > 3 && Qi.stayBed)
            {
                Debug.Log("TODO-结束");
                ProcessController.Instance.GoNextScene();
            }
        }
    }
}
