using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutScene : MonoBehaviour
{
    public Canvas aboutScene;
    public Button Return;

    private void Awake()
    {
        Return?.onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
