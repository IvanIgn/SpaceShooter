using UnityEngine;
using System.Collections;

public class ShipBullet : MonoBehaviour
{

    public SoundManager sm;

    void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemyB"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            sm.PlaySound(1);
        }
    }

    


}

    

    
    


