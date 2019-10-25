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

    public int poolSize;
	public GameObject rocket;
	public int rocketCount;
	public Text rocketCountT;
	public float shootDelay;
	public Transform[] shootPoints;
	public bool isFire;
	public bool isReadyToShoot;
	public int bulletDmg;
	public SoundManager sm;
	public int scoreCount;
	public Text scoreCountT;
	public bool isOver;
	public GameObject GameOverPanel;
	public ParticleSystem DeadFX;
    public ParticleSystem FireEngineFX;

    public int death_Count;
    public Image[] deathCountI;
    public Color[] turnColors;



    public AnimationClip respawn;
    Animation anim;
  



    void Start()
	{
        ///////

       
        InitObjectPool();

        ///////
        
        anim = GetComponent<Animation>();
        anim.clip = respawn;
        anim.Stop();
        isReadyToShoot = true;
		isFire = false;
        
	}

	void Update()
	{
        
        rocketCountT.text = rocketCount.ToString();
		scoreCountT.text = scoreCount.ToString();
		Vector2 curPos = transform.localPosition;
		curPos.y = Mathf.Clamp(transform.localPosition.y,minY,maxY);
		curPos.x = Mathf.Clamp(transform.localPosition.x,minX,maxX);
		transform.localPosition = curPos;

		if(isFire && isReadyToShoot)
		{
			Shoot();
		}
       

        //for (int c = 0; c<=3; c++)
       // {
            if (death_Count != 0 && Life_points <= 0 && !isOver)
            {
                Life_points = 10;
                ChangeLife();
                death_Count--;
                ChangeTurnCount();
                DeadFX.Play();
               
                anim.Play();

            }

            else if(death_Count == 0)
            {
                    GameOver();
                
            }

           
      //  }
        

	}

    void InitObjectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject shipBullet = Instantiate(bullet);
            shipBullet.SetActive(false);

           // Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
            //bullet.Add(rb);
        }


    }

   


    void GameOver()
	{
       
            isOver = true;
            DeadFX.Play();
            FireEngineFX.Stop();
            Hide();
            Save();
            GameOverPanel.SetActive(true);
            DeadFX.Stop();    

    }



    void Hide()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}

	public void ChangeLife()
	{
		for(int l = 0; l < lifePoints.Length; l++)
		{
			if(l < Life_points)
			{
				lifePoints[l].color = lifeColors[0];
			}
			else
			{
				lifePoints[l].color = lifeColors[1];
			}
		}
	}

    public void ChangeTurnCount()
    {
        for(int i = 0; i < deathCountI.Length; i++)
        {
            if (i < death_Count)
            {
                deathCountI[i].color = turnColors[0];
            }
            else
            {
                deathCountI[i].color = turnColors[1];
            } 
        }
    }


	void Save()
	{
		
		PlayerPrefs.SetInt("NewScore",scoreCount);
		if(!PlayerPrefs.HasKey("HS"))
		{
			PlayerPrefs.SetInt("HS",scoreCount);
		}
		else
		{
			int hs = PlayerPrefs.GetInt("HS");
			if(hs< scoreCount)
			{
				PlayerPrefs.SetInt("HS",scoreCount);
			}
		}
		
	}

	void OnApplicationQuit()
	{
		Save();
	}

	public void Move (Vector2 axis) 
	{
		transform.Translate(axis*Time.deltaTime*Speed,Space.Self);
	}

    void Shoot()
    {
        
        foreach (Transform sp in shootPoints)
        {
            GameObject b = Instantiate(bullet, sp.position, Quaternion.identity) as GameObject;
            Destroy(b, 6);

            if (sp == shootPoints[shootPoints.Length - 1])
            {
                StartCoroutine(ShootDelay());
            }
        }

        sm.PlaySound(3);
       

    }

   

    public void RocketShoot()
	{
        foreach (Transform sp in shootPoints)
        {
            if (rocketCount > 0)
            {
                GameObject r = Instantiate(rocket, sp.position, Quaternion.identity) as GameObject;
                rocketCount--;
                sm.PlaySound(2);
                Destroy(r, 3);
            }
        } 
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
		if(Life_points < 0)
		{
			Life_points = 0;
		}
		ChangeLife();
	}

	public void AddScore(int scoreToAdd)
	{
		scoreCount += scoreToAdd;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag("enemyB"))
		{
			Damage(1);
			Destroy(coll.gameObject);
            sm.PlaySound(1);
		}
     
		if(coll.gameObject.CompareTag("enemy"))
		{
			Damage(2);
			Destroy(coll.gameObject);
			sm.PlaySound(0);
		}
	}
}
