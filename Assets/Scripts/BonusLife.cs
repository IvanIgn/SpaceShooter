using UnityEngine;
using System.Collections;

public class BonusLife : MonoBehaviour {

	public ShipController Ship;
	public SoundManager sm;
    



	void Start ()
    {
	sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
	Ship = GameObject.Find("ShipPlayer").GetComponent<ShipController>();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("Ship")){
		Destroy(gameObject);
		if(Ship.Life_points < 9)
		{
			Ship.Life_points+= 2;
		}
		else
		{
			Ship.Life_points = 10;
       
		}
            Ship.ChangeLife();
		sm.PlaySound(4);
		}
	}
	
}
