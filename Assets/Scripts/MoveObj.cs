using UnityEngine;
using System.Collections;

public class MoveObj : MonoBehaviour {

    public float Speed;
    public float rotateSpeed;
    public Vector2 moveDir;
    public GameObject fx;
    private bool isQuit;
    public ShipController Ship;

    void Start()
    {
        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipController>();
    }
    void Update() {

        transform.Translate(moveDir * Time.deltaTime * Speed);

    }


    void OnApplicationQuit()
    {
        isQuit = true;
    }

	void OnDestroy()
	{	if(!isQuit && Time.timeScale == 1 && !Ship.isOver){
		GameObject p = Instantiate(fx,transform.position,Quaternion.identity) as GameObject;
		p.GetComponent<ParticleSystem>().Play();
		Destroy(p,p.GetComponent<ParticleSystem>().main.duration);
	}
	}
    
}
