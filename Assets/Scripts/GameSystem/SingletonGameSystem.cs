using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameSystem : MonoBehaviour
{
    static SingletonGameSystem instance;
    public static SingletonGameSystem Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SingletonGameSystem>();
                if(instance == null)
                {
                    //GameObject go = new GameObject("GameSystem");
                    GameObject go = Resources.Load<GameObject>("Prefabs/GameSystem");
                    GameObject newOB = Instantiate(go);
					instance = newOB.GetComponent<SingletonGameSystem>();
                    DontDestroyOnLoad(newOB);
                }
            }
            return instance;
        }
    }

    #region 相关属性
    public bool IsPause;

	#endregion

	//#region 各种管理器

	//public OptionController optionSystem { get; private set; }
 //   public AudioController audioController { get; private set; }
 //   public ProcessController processController { get; private set; }

	//#endregion

	private void Awake()
    {
        instance = this;
		//optionSystem = OptionController.Instance;
		//audioController = AudioController.Instance;
		//processController = ProcessController.Instance;
		//audioController.UpdateVolume();
		DontDestroyOnLoad(instance);

        IsPause = false;
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (IsPause)
			{
				StopPause();
			}
			else
			{
				StartPause();
			}
		}
	}

    public void StartPause()
    {
		Debug.Log("暂停菜单");
		Time.timeScale = 0;
        IsPause = true;
		OptionController.Instance.StartMenu();
	}

    public void StopPause()
    {
		Debug.Log("退出暂停菜单");
		Time.timeScale = 1;
        IsPause = false;
		OptionController.Instance.StopMenu();
	}
}
