using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBulletCollision : MonoBehaviour
{

    public SoundManager sm;

    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }


    void OnCollisionEnter2D(Collision2D coll)
   {
      if(coll.gameObject.CompareTag("enemyB"))
      {
          Destroy(coll.gameObject);
          Destroy(gameObject);
          sm.PlaySound(1);
      } 
   }
}
