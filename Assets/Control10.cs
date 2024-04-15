using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control10 : MonoBehaviour
{
	public static Control10 Instance { get; private set; }
    public int stage = 1;
	public GameObject Fruit, Cake, Key;
	public bool fruit, cake, key;
	bool IsNew;
	public DialogueData_SO ds,ds2;

    private void Awake()
    {
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
        DontDestroyOnLoad(gameObject);
		fruit = true;
		cake = true;
		key = false;
		IsNew = true;
	}

	private void Start()
	{
		if (IsNew)
		{
			DialogueUI.Instance.UpdateDialogue(ds);
			DialogueUI.Instance.UpdateMainDialogue(ds.dialoguePieces[0]);
		}
		IsNew = false;

		AudioController.Instance.PlayMusic("n148");
	}

	private void Update()
	{
		if(stage == 3)
		{
			key = true;
			Key.SetActive(true);
		}
		if(stage == 4)
		{
			StartCoroutine(CheckStage());
		}
	}

	public IEnumerator CheckStage()
    {
		if(stage == 4)
		{
			DialogueUI.Instance.UpdateDialogue(ds2);
			DialogueUI.Instance.UpdateMainDialogue(ds2.dialoguePieces[0]);
			yield return null;
			while(DialogueUI.Instance.endFlag)
			{
				yield return null;
			}
			SceneComplete();
		}
	}



    public void SceneComplete()
    {
		// TODO 10-2 当前剧情完成，前往下一节
		Debug.Log("走咯~");
		ProcessController.Instance.GoNextScene();
    }

	public void GoToNextScene(string sceneName)
	{
		// TODO 跳转下一个场景
		if(stage <= 2)
		{
			StartCoroutine(_GoNext(sceneName));
			if(sceneName == "10-2-1")
			{
				fruit = false;
				Fruit.SetActive(false);
			}
			else if(sceneName == "10-2-2")
			{
				cake = false;
				Cake.SetActive(false);
			}
			stage++;
		}
	}

	private IEnumerator _GoNext(string sceneName)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		while (async.progress < 0.9f)
		{
			yield return null;
		}
		async.allowSceneActivation = true;
		yield break;
	}
}
