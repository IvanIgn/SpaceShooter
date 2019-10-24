using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public GameObject[] bonuses;
	public int lifePoints = 4;
	public bool isDead = false;
	public SoundManager sm;
   


    void Start () {
	sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
	}

	void Update()
	{
		if(lifePoints == 0 && !isDead)
		{
			Boom();
		}

    }

	void Boom() 
	{
		isDead = true;
		GameObject bonus = bonuses[Random.Range(0,bonuses.Length)];
		GameObject b = Instantiate(bonus,transform.position,Quaternion.identity) as GameObject;
		Destroy(gameObject);
		sm.PlaySound(0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("shipB"))
        {
            lifePoints--;
            Destroy(coll.gameObject);
            sm.PlaySound(1);
        }
        if (coll.gameObject.CompareTag("shipR"))
        {
            lifePoints = 0;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.CompareTag("enemyB"))
        {
            // Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (coll.gameObject.CompareTag("mine"))
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


    }
}
