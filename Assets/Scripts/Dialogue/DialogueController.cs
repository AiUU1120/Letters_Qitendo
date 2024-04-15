using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO currentData;

    private bool canTalk = false;

    [SerializeField]
    private bool isInteract;//是否为互动触发对话（若不是则玩家碰撞触发器自动触发对话）

    private bool isTrigger; //是否为需要触发器生成对话（不是则在进入场景后直接进行调用）

    private void Update()
    {
        if (canTalk && !isInteract)
        {
            OpenDialogue();
            canTalk = false;
        }

        if (canTalk && isInteract && Input.GetKeyDown(KeyCode.E))
        {
            OpenDialogue();
        }
    }

    public void OpenDialogue()
    {
        //InputDeviceDetection.GameplayUIController.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
        DialogueUI.Instance.UpdateDialogue(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }

    //void OnButtonClick()
    //{
    //    DialogueUI.Instance.UpdateDialogue(currentData);
    //    DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
        }
    }
}
