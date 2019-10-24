using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

	public int Life_points;
	public GameObject bullet;
	public float shootDelay;
	public Transform shootPoint;
	public ShipController Ship;
	public bool isDead = false;
	public SoundManager sm;

	void Start()
	{
		sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
		Ship = GameObject.Find("ShipPlayer").GetComponent<ShipController>();
		InvokeRepeating("Shoot",2,shootDelay);
	}

	void Update()
	{
		if(Life_points == 0 && !isDead)
		{
			Boom();
		}
	}

	void Boom()
	{
		isDead = true;
		Destroy(gameObject);
		sm.PlaySound(0);
		Ship.AddScore(1);
	}
    
	void Shoot()
	{
		GameObject b = Instantiate(bullet,shootPoint.position,Quaternion.identity) as GameObject;
        sm.PlaySound(5);
        Destroy(b,6);
	}

	public void Damage(int dmg) 
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
        

        if(coll.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

       

    }

}
