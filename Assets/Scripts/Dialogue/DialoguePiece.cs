using UnityEngine;

//该脚本存储对话内容的数据
[System.Serializable]
public class DialoguePiece
{
    public string ID;

    public Sprite image;

    public string speakerName;

    [TextArea]
    public string text;

    public bool isNpc;//是否为Npc说话（影响立绘位置）
}
