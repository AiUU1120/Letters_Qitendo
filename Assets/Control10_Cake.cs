using UnityEngine.SceneManagement;
using UnityEngine;

public class Control10_Cake : MonoBehaviour
{
    bool jump;
    void Update()
    {
        jump = GetComponent<DialogueUI>().endFlag;
        if(jump)
        {
            SceneManager.LoadScene("10-2");
        }
    }
}
