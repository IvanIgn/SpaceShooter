using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject[] Enemies;
    public float minDelay;
    public float maxDelay;

    public float minYpos;
    public float maxYpos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); 
    }


    // Update is called once per frame
    void Repeat()
    {
        StartCoroutine(Spawn());
       
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minYpos, maxYpos));
        GameObject e = Instantiate(Enemies[Random.Range(0, Enemies.Length)], pos, Quaternion.identity) as GameObject;

        Repeat();
    }
}
