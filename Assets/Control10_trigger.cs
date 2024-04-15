using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control10_trigger : MonoBehaviour
{
    public string SceneName;
    bool Interactable;
    InteractiveTips tips;
    private void Awake()
    {
        Interactable = false;
	}

    private void Update()
    {
        if (Interactable && Input.GetKey(KeyCode.E))
        {
            if (SceneName == "114514")
            {
                Control10.Instance.stage++;

			}
            else
            {
				Control10.Instance?.GoToNextScene(SceneName);
			}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		tips = GameObject.Find("InteractiveSystem")?.GetComponent<InteractiveTips>();
		Interactable = true;
        tips?.StartInteracting(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		Interactable = false;
		tips?.StopInteracting();
    }
}
