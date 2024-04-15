using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveTrigger : MonoBehaviour
{
	InteractiveTips system;

	public DialogueData_SO currentData;


	[Header("是否允许交互")]
	public bool EnableInteraction = true;

	private bool canTalk = false;

	[SerializeField]
	private bool isInteract;//是否为互动触发对话（若不是则玩家碰撞触发器自动触发对话）



	private void Awake()
	{
		system = GameObject.Find("InteractiveSystem").GetComponent<InteractiveTips>();
	}

	private void Update()
	{
		if (canTalk && !isInteract && EnableInteraction)
		{
			OpenDialogue();
			canTalk = false;
		}

		if (canTalk && isInteract && EnableInteraction && Input.GetKeyDown(KeyCode.E))
		{
			OpenDialogue();
		}
	}

	private void OpenDialogue()
	{
		//InputDeviceDetection.GameplayUIController.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
		DialogueUI.Instance.UpdateDialogue(currentData);
		DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(gameObject.name + "接触到了" + other.name);
		if (other.CompareTag("Player") && currentData != null)
		{
			canTalk = true;
			if (system != null)
			{
				system.StartInteracting(gameObject);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit");
		if (other.CompareTag("Player"))
		{
			canTalk = false;
			if (system != null)
			{
				system.StopInteracting();
			}
		}
	}

}
