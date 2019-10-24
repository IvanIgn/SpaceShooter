﻿using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public SoundManager sm;
	void Start()
	{
		sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("enemy"))
		{
			coll.gameObject.GetComponent<SimpleEnemy>().Damage(10);
			Destroy(gameObject);
			sm.PlaySound(0);
			
		}
       
		if(coll.gameObject.CompareTag("enemyB"))
		{
			Destroy(coll.gameObject);
			//Destroy(gameObject);
			sm.PlaySound(0);
		}

        if (coll.gameObject.CompareTag("mine"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }

    }
}