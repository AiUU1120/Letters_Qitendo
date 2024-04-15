using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
	public Image Mask;
	[Range(0f, 10f)]
	public float alpha = 5f;

	private void Start()
	{
		StartCoroutine(EnterScene());
	}

	public IEnumerator EnterScene()
	{
		float alpha_tmp = alpha;
		while (alpha_tmp > 0)
		{
			alpha_tmp -= Time.deltaTime;

			Mask.color = new Color(0, 0, 0, alpha_tmp);
			yield return null;
		}
		gameObject.SetActive(false);
	}

	[Obsolete("该方法有缺陷，已弃用",true)]
	public IEnumerator QuitScene()
	{
		float alpha_tmp = 0;
		while (alpha_tmp < alpha)
		{
			alpha_tmp += Time.deltaTime;
			Mask.color = new Color(0, 0, 0, alpha_tmp);
			yield return null;
		}
	}
}
