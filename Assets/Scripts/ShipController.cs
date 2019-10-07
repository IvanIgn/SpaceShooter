using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public int Life_points;
	public Image[] lifePoints;
	public Color[] lifeColors;
	public float Speed; 
	public float minY;
	public float maxY;
	public float minX;
	public float maxX;

	public GameObject bullet;
	public float shootDelay;
	public Transform[] shootPoints;
	public bool isFire;
	public bool isReadyToShoot;
	public int bulletDmg;
	public SoundManager sm;

	public int scoreCount;
	//public Text scoreCountT;

	//public bool isOver;
	
	//public int DeathCount = 0;
	void Start()
	{
		
		isReadyToShoot = true;
		isFire = false;
	
	}
	void Update()
	{
		
		//scoreCountT.text = scoreCount.ToString();
		Vector2 curPos = transform.localPosition;
		curPos.y = Mathf.Clamp(transform.localPosition.y,minY,maxY);
		curPos.x = Mathf.Clamp(transform.localPosition.x,minX,maxX);
		transform.localPosition = curPos;

		if(isFire && isReadyToShoot)
		{
			Shoot();
		}
		//if(Life_points <= 0 && !isOver)
		//{
		//	GameOver();
		//}
	}
    
    void ChangeLife()
    {
        for (int l = 0; l < lifePoints.Length; l++)
        {
            if (l < Life_points)
            {
               
                lifePoints[l].color = lifeColors[0];
            }
            else
            {
               
                lifePoints[l].color = lifeColors[1];
            }
        }
    }

    
    public void Move (Vector2 axis) 
	{
		transform.Translate(axis*Time.deltaTime*Speed,Space.Self);
	}

	void Shoot()
	{
		foreach(Transform sp in shootPoints){
		GameObject b = Instantiate(bullet,sp.position,Quaternion.identity) as GameObject;
		Destroy(b,5);
		    if(sp == shootPoints[shootPoints.Length-1])
		    {
			    StartCoroutine(ShootDelay());
		    }
		}
		  sm.PlaySound(2);
	}
  
	IEnumerator ShootDelay()
	{
		isReadyToShoot = false;
		yield return new WaitForSeconds(shootDelay);
		isReadyToShoot = true;
	}

	public void Fire(bool fire)
	{
		isFire = fire;
	}

    public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points < 0)
        {
            Life_points = 0;
        }
        
            ChangeLife(); 
    }
    
	public void AddScore(int scoreToAdd)
	{
		scoreCount += scoreToAdd;
        //scoreCountT == scoreCount.To
	}
    
    void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("enemyB"))
		{
			Damage(1);
			Destroy(coll.gameObject);
            sm.PlaySound(1);
		}
        /*
        if (coll.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
            //sm.PlaySound(1);

        }
        */
        /*
		if(coll.gameObject.CompareTag("coin"))
		{
			Destroy(coll.gameObject);
			//coinsCount++;
			//sm.PlaySound(4);
		}
        */

    }
}
