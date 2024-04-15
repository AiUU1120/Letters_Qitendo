using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public Button b_Start, Continue, Options, Exit, AboutUs;

    private void Awake()
    {
        b_Start?.onClick.AddListener(StartNewGame);
        Continue?.onClick.AddListener(ContinueGame);
        Options?.onClick.AddListener(OpenOption);
        Exit?.onClick.AddListener(ExitGame);
        AboutUs?.onClick.AddListener(OpenAbout);
    }

    private void Start()
    {
        AudioController.Instance?.PlayMusic("n75");
    }

    void StartNewGame()
    {
        ProcessController.Instance?.GoNextScene("0-1");
    }

    void ContinueGame()
    {
        var phase = OptionController.Instance?.data.Progress;
        if(phase!= null && phase != "MainMenu")
        {
			ProcessController.Instance?.GoNextScene(phase);
		}
        else
        {
            //Continue.interactable = false;
        }
	}

    void OpenOption()
    {
        OptionController.Instance.StartMenu();
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OpenAbout()
    {
        SceneManager.LoadScene("About");
    }

}
