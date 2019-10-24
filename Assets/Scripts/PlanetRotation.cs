using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetRotation : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(0, 0, -1);
        transform.RotateAround(transform.position, axis, Time.deltaTime * speed);
    }
}


