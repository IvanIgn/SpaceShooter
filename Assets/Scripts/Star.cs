﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
    }
}