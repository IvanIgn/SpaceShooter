using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float Speed;
    public Vector2 direction;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }
}
