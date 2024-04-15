using System.IO;
using UnityEngine;

internal static class FileUtility
{
    /// <summary>
    /// 默认配置文件储存路径
    /// </summary>
    public static readonly string DefaultPath = Application.streamingAssetsPath + "/config.json";

    /// <summary>
    /// 保存配置文件
    /// </summary>
    /// <param name="data">配置文件数据</param>
    /// <returns></returns>
    public static void SaveOptionDataToJson(OptionData data)
    {
        if (data == null) return;
        string json = JsonUtility.ToJson(data);
        if (File.Exists(DefaultPath))
        {
            File.WriteAllText(DefaultPath, json);
        }
        else
        {
            File.CreateText(DefaultPath);
            File.WriteAllText(DefaultPath, json);
        }
        //FileStream fs = new FileStream(DefaultPath, FileMode.OpenOrCreate, FileAccess.Write);
        //StreamWriter sw = new StreamWriter(fs);
        //sw.WriteLine(json);
        //sw.Flush();
        //sw.Close();
        //fs.Close();
    }

    /// <summary>
    /// 获取配置文件，当配置文件不存在时将会返回默认配置并创建新配置文件
    /// </summary>
    /// <returns></returns>
    public static OptionData LoadOptionDataFromJson()
    {
		OptionData optionData = null;
		if (File.Exists(DefaultPath))
        {
			string json = string.Empty;
            json = File.ReadAllText(DefaultPath);
			optionData = JsonUtility.FromJson<OptionData>(json);
			//FileStream fs = new FileStream(DefaultPath, FileMode.Open, FileAccess.Read);
			//if (fs.CanRead)
			//{
			//	StreamReader sr = new StreamReader(fs);
			//	json = sr.ReadToEnd();
			//	sr.Close();
			//	if (json != string.Empty)
			//	{
			//		optionData = JsonUtility.FromJson<OptionData>(json);
			//	}
			//}
			//fs.Close();
		}
		if (optionData == null)
        {
            optionData = new OptionData();
            SaveOptionDataToJson(optionData);
        }
        return optionData;
    }

	#region 默认配置
	public static readonly bool DefaultEnableAudio = true;
	public static readonly float DefaultMusicVolume = 50f;
	public static readonly float DefaultEffectVolume = 50f;

	public static readonly ResolutionOption DefaultResolution = ResolutionOption.r1920x1080;
	public static readonly bool DefaultFullScreen = true;
	#endregion

}


