using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该ScriptObject存储每一次对话的资源
[CreateAssetMenu(fileName = "New Dialogue", menuName = "SOAssets/Dialogue Data")]
public class DialogueData_SO : ScriptableObject
{
    public List<DialoguePiece> dialoguePieces = new List<DialoguePiece>();//一次剧情对话的所有单条文本
}
