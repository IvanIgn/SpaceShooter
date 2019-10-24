using UnityEngine;
using System.Collections;

public class StarMove : MonoBehaviour {

	public float Speed;
	public GameObject Ship;
	void Start () {
	Ship = GameObject.Find("ShipPlayer");
	}
	

	void Update () {
	transform.Translate(Vector2.left*Time.deltaTime*Speed,Space.World);
	if(transform.position.x < Ship.transform.position.x-10)
	{
		Destroy(gameObject);
	}

	}
}
