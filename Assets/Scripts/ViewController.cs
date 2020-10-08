﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float speed = 1;
    public float mouseSpeed = 1200;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(mouse);
        transform.Translate(new Vector3(h * speed, -1*mouse * mouseSpeed, v * speed) * Time.deltaTime,Space.World);
    }
}
