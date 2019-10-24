using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float distToActive;
	public GameObject Ship;
	public float Speed;
	public SoundManager sm;


	void Start () {
	Ship = GameObject.Find("ShipPlayer");
	sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
  
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,Ship.transform.position) <= distToActive && !Ship.GetComponent<ShipController>().isOver)
		{
			transform.position = Vector2.MoveTowards(transform.position,Ship.transform.position,Time.deltaTime*Speed);
            Destroy(gameObject, 4);
            //sm.PlaySound(0);
        }
		if(Vector2.Distance(transform.position,Ship.transform.position) <= 0.75f && !Ship.GetComponent<ShipController>().isOver)
		{
			Ship.GetComponent<ShipController>().Damage(3);
			Destroy(gameObject);
            sm.PlaySound(0);
        }
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("shipB"))
		{
			Destroy(gameObject);
			Destroy(coll.gameObject);
			sm.PlaySound(0);
            
            
			Ship.GetComponent<ShipController>().AddScore(2);
		}
		if(coll.gameObject.CompareTag("enemyB"))
		{
			//Destroy(gameObject);
		    Destroy(coll.gameObject);
           
            //sm.PlaySound(0);
        }
        if (coll.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }
}
