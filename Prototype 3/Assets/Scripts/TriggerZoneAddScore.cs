﻿/*
 * Josh McGrew
 * Assignment 4: Prototype 3
 * add zone with trigger zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private UIManager ui;
    private bool triggered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ui.score++;
        }
    }
}
