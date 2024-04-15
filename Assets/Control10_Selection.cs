using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control10_Selection : MonoBehaviour
{
	public Button b1, b2, b3;
	public bool IsClicked = false;
	public DialogueData_SO DS1, DS2;
	private int num = 1;
	// Start is called before the first frame update
	private void Awake()
	{
		b1.gameObject.SetActive(false);
		b2.gameObject.SetActive(false);
		b3.gameObject.SetActive(false);
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (DialogueUI.Instance.endFlag)
		{
			if (IsClicked)
			{
				num++;
				IsClicked = false;
			}

			switch (num)
			{
				case 1:
					b1.gameObject.SetActive(true);
					b2.gameObject.SetActive(true);
					b3.gameObject.SetActive(true);
					num++;
					break;
				case 2:
					break;
				case 3:
					StartCoroutine(LoadScene("10-2"));
					break;
			}
		}
	}

	IEnumerator LoadScene(string name)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(name);
		async.allowSceneActivation = false;
		yield return null;
		while(!async.isDone)
		{
			if(async.progress >= 0.9f)
			{
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}

	public void ButtonOnclick()
	{
		IsClicked = true;

		b1.gameObject.SetActive(false);
		b2.gameObject.SetActive(false);
		b3.gameObject.SetActive(false);
	}
}
