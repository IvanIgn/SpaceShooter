using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {


    public float Speed;
    public Vector2 moveDir;
    public GameObject eff;


    void Update()
    {
        transform.Translate(moveDir*Time.deltaTime*Speed); 
    }

    
     void OnDestroy()
    {
        GameObject f = Instantiate(eff, transform.position, Quaternion.identity) as GameObject;
        //f.transform.SetParent(GameObject.Find("PlayZone").transform);
        f.GetComponent<ParticleSystem>().Play();
        Destroy(f, f.GetComponent<ParticleSystem>().main.duration);

    }
}
