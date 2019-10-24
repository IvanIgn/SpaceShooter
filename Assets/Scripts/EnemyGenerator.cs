using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public GameObject[] Enemys;
	public GameObject Bonus;
	public float minDelay;
	public float maxDelay;
	public float minYpos;
	public float maxYpos;

	void Start ()
    {

	    StartCoroutine(Spawn());

	}
	
	void Repeat () 
	{

	    StartCoroutine(Spawn());

	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
		Vector2 pos = new Vector2(transform.position.x,Random.Range(minYpos,maxYpos));
		GameObject e = Instantiate(Enemys[Random.Range(0,Enemys.Length)],pos,Quaternion.identity) as GameObject;
		int r = Random.Range(0,100);
		Vector2 Bonus_pos = new Vector2(transform.position.x,Random.Range(minYpos,maxYpos));
		Destroy(e,20);

		if(r<=15)
		{
			GameObject b = Instantiate(Bonus,Bonus_pos,Quaternion.identity) as GameObject;
			Destroy(b,35);
		}
		Repeat();
	}
}
