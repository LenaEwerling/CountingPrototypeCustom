using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public GameObject ball;
    //private Spawner spawner;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Bouncing bouncingScript = other.GetComponent<Bouncing>();
        if (bouncingScript != null && !bouncingScript.scored)
        {
            bouncingScript.scored = true;
            UpdateCounter(1);
        }
    }

    public void UpdateCounter(int value)
    {
        Count += value;
        CounterText.text = "Count : " + Count;
    }
}
