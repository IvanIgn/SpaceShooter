using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour {

	public GameObject[] SpaceStuff;
	public float maxSpeed;
	public float minSpeed;
	public float maxScale;
	public float minScale;
	public Color[] colors;
	public float maxDelay;
	public float minDelay;
	public float minYpos;
	public float maxYpos;

	void Start () 
	{
	StartCoroutine(CreateStar());
	}

	void Repeat () 
	{
	StartCoroutine(CreateStar());
	}

	IEnumerator CreateStar()
	{
		yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
		Vector2 pos = new Vector2(transform.position.x,Random.Range(minYpos,maxYpos));
		float speed = Random.Range(minSpeed,maxSpeed);
		float scale = Random.Range(minScale,maxScale);
		Color color = colors[Random.Range(0,colors.Length)];
		GameObject star = Instantiate(SpaceStuff[Random.Range(0,SpaceStuff.Length)],pos,Quaternion.identity) as GameObject;
		StarMove sm = star.GetComponent<StarMove>();
		sm.Speed = speed;
		star.transform.localScale = new Vector3(scale,scale,scale);
		star.GetComponent<SpriteRenderer>().color = color;
		Repeat();
	}
}
