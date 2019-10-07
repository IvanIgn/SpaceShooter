using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

	public int Life_points;
	public GameObject bullet;
	public float shootDelay;
	public Transform shootPoint;
	public ShipController Ship;
	public bool isDead = false;
    //public AudioClip soundEffect;
	public SoundManager sm;
    
   

	void Start()
	{
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        Ship = GameObject.Find("shipPlayer").GetComponent<ShipController>();
		InvokeRepeating("Shoot",2,shootDelay);
        
	}

	void Update()
	{
		if(Life_points == 0 && !isDead)
		{
            Dies();
            
		}

		if (transform.position.x <= -14)
		{
			Destroy(gameObject);
		}
        ///////// works but not exactly ////////        
        
        if (Vector2.Distance(transform.position, Ship.transform.position) <= 1.2f)
        {
            Destroy(gameObject);
            sm.PlaySound(0);
        }
        
       
        
	}
    
	void Dies()
	{
		isDead = true;
		Destroy(gameObject);
        Ship.AddScore(1);
		sm.PlaySound(0);

		
	}
    
   
	void Shoot()
	{
		GameObject b = Instantiate(bullet,shootPoint.position,Quaternion.identity) as GameObject;
        sm.PlaySound(3);
		Destroy(b,6);
	}

	 void Damage(int dmg) 
	{
		Life_points -= dmg;
		if(Life_points < 0)
		{
			Life_points = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("shipB"))
		{
			Damage(Ship.bulletDmg);
			Destroy(coll.gameObject);
			sm.PlaySound(1);
			
		}
        
		if(coll.gameObject.CompareTag("enemyB"))
		{
			//Damage(1);
			Destroy(coll.gameObject);
			sm.PlaySound(1);
		}
    /*
       if(coll.gameObject.CompareTag("playerShip"))
        {
            Destroy(coll.gameObject);
            //Destroy(gameObject); 
           // Dies();
        }

    */
        
	}

}
