using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "ProcessData", menuName = "SOAssets/ProcessData")]
public class ProcessData : ScriptableObject
{
	public List<SceneData> sceneDatas = new List<SceneData>();
}
[System.Serializable]
public class SceneData
{
	[Header("场景名，唯一识别")]
	public string SceneName;
	//[Header("场景简述")]
	//public string SceneDescription;
	[Header("下一场景名")]
	public string nextScene;
	//[Header("是否为存档点")]
	//public bool IsSavePoint;
	[Header("场景类型")]
	public SceneType SceneType;
}

public enum SceneType
{
	玩家行动,
	CG对话,
	过场动画
}

