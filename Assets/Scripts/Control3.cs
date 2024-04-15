using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control3 : MonoBehaviour
{
    bool Ishere = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance.PlayMusic("Casual - Level 1 (Loop_02)");
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueUI.Instance.endFlag && Ishere)
        {
            ProcessController.Instance.GoNextScene();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision != null)
        {
            Debug.Log("123");
            Ishere = true;
        }
    }
}
