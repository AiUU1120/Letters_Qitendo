using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    public bool endFlag = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private DialogueData_SO currentData;//当前对话数据
    private int currentIndex;//对话序号

    [SerializeField]
    private Canvas dialogueCanvas;
    private bool canContinue;

    [Header("===== Dialogue Basic Element =====")]
    [SerializeField]
    private Image standA;//玩家立绘
    [SerializeField]
    private Image standB;//Npc立绘
    [SerializeField]
    private Text speakerName;//说话人名字
    [SerializeField]
    private Text mainText;//对话文本

    private void Update()
    {
        endFlag = false;
        if (canContinue && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < currentData.dialoguePieces.Count)
            {
                UpdateMainDialogue(currentData.dialoguePieces[currentIndex]);
            }
            else
            {
                canContinue = false;
                dialogueCanvas.enabled = false;
                endFlag = true;
            }
        }
    }

    public void UpdateDialogue(DialogueData_SO data)//此函数为每次开启对话的第一次刷新
    {
        currentData = data;
        currentIndex = 0;
    }
    public void UpdateMainDialogue(DialoguePiece piece)//此函数为每次继续对话时更新下一条本文
    {
        canContinue = true;
        dialogueCanvas.enabled = true;
        standA.enabled = false;
        standB.enabled = false;

        if (!piece.isNpc)
        {
            standA.enabled = true;
            standA.sprite = piece.image;
        }
        else if (piece.isNpc)
        {
            standB.enabled = true;
            standB.sprite = piece.image;
        }

        mainText.text = "";
        speakerName.text = "";
        speakerName.text = piece.speakerName;
        mainText.text = piece.text;

        if (currentData.dialoguePieces.Count > 0)
        {
            currentIndex++;
        }
    }
}
