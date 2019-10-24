using UnityEngine;
using System.Collections;

public class RocketBonus : MonoBehaviour {

	public ShipController Ship;
    public SoundManager sm;
	void Start () {
	sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
	Ship = GameObject.Find("ShipPlayer").GetComponent<ShipController>();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("Ship")){
		Destroy(gameObject);
		Ship.rocketCount+=5;
		sm.PlaySound(4);
		}
	}
}
