using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public SoundManager sm;
    public GameObject Ship;
    public float distToActive;
    public float Speed;
    public ShipController ship;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        Ship = GameObject.Find("shipPlayer");
        ship = GameObject.Find("shipPlayer").GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Ship.transform.position) <= distToActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ship.transform.position, Time.deltaTime * Speed);
        }

        if (Vector2.Distance(transform.position, Ship.transform.position) <= 0.3f)
        {
            Ship.GetComponent<ShipController>().Damage(3);

            Destroy(gameObject);
            sm.PlaySound(0);
        }

		if (transform.position.x <= -14)
		{
			Destroy(gameObject);
		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("shipB"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
            ship.AddScore(1);
            sm.PlaySound(0);

        }
    }
}
