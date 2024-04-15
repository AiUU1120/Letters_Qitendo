using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl_21 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance?.PlayMusic("C2");
    }
}
