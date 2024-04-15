using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneFlowController : MonoBehaviour
{
    public List<Action> actionList = new List<Action>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Action
{
    public DialogueData_SO dialogue;        //每一个动作需要读取的对话文件

    public GameObject button;               //


}
