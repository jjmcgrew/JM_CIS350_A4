/*
 * Josh McGrew
 * Assignment 4: Prototype 3
 * repeat background script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //save starting position as a Vector3
        startPosition = transform.position;

        //set repeat width to half of background's width
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if background is farther to the left than the repeatWidth,
        //reset it to the startPosition
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
