using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ProcessController : MonoBehaviour
{
    public static ProcessController Instance { get; private set; }

    public string processName = "MainProcess";
    public ProcessData data;
    public string CurrentSceneName;
    public string NextSceneName;
    public Scene scene;

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
        UpdateInf();
    }

    #region APIs

    public void UpdateInf()
    {
		data = LoadProcessData();
        //Debug.Log(data.ToString());
		scene = SceneManager.GetActiveScene();
		CurrentSceneName = scene.name;
		NextSceneName = data?.sceneDatas?.Find((SceneData sd) => { return sd.SceneName == CurrentSceneName; })?.nextScene;
	}

	public void GoNextScene()
    {
        UpdateInf();
		if (NextSceneName != CurrentSceneName && NextSceneName != null && NextSceneName != string.Empty)
        {
            UpdateInf();
            StartCoroutine(LoadScene(NextSceneName));
        }
    }

	public void GoNextScene(string nextScene)
	{
        UpdateInf();
		if (nextScene != CurrentSceneName && nextScene != null && nextScene != string.Empty)
		{
			StartCoroutine(LoadScene(nextScene));
		}
	}

	#endregion

	#region Utility
	private ProcessData LoadProcessData()
    {
        ProcessData data = Resources.Load<ProcessData>("ProcessData/" + processName);
        return data;
    }

    private IEnumerator LoadScene(string sceneName, UnityAction doBeforeLoad = null, UnityAction doWhenLoad = null, UnityAction doAfterLoad = null)
    {
        if(doBeforeLoad != null)
        {
            doBeforeLoad.Invoke();
        }
        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while(async.progress < 0.9f)
        {
            yield return null;
        }
        if(doAfterLoad != null)
        {
            doAfterLoad.Invoke();
        }
		async.allowSceneActivation = true;
		yield break;
    }
	#endregion

}
