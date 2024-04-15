using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeChat9 : MonoBehaviour
{
    public DialogueData_SO DS1;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
		DialogueUI.Instance.UpdateDialogue(DS1);
		DialogueUI.Instance.UpdateMainDialogue(DS1.dialoguePieces[0]);
	}

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag)
        {
            Debug.Log("TODO-结束");
            ProcessController.Instance.GoNextScene();
        }
    }
}
