using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control10_Main : MonoBehaviour
{
    public bool cake;
    public bool fruit;
    public bool key;
    public GameObject tipFruit, tipCake, tipKey;

    private void Start()
    {
		cake = Control10.Instance.cake;
		fruit = Control10.Instance.fruit;
        key = Control10.Instance.key;
	}

    private void Update()
    {
        tipFruit.SetActive(fruit);
        tipCake.SetActive(cake);
        tipKey.SetActive(key);
    }
}
