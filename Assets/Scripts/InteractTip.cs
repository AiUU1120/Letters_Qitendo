using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTip : MonoBehaviour
{
    [SerializeField]
    private Canvas tip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tip.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tip.enabled = false;
        }
    }
}
