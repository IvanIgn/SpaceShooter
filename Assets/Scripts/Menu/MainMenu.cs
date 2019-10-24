using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public int hs;
	public Text PlayBtnT;
	public Text HS_T;
	
    // Use this for initialization
    void Start()
    {
       
 
        Time.timeScale = 1;
           
        hs = PlayerPrefs.GetInt("HS", 0);
       

    }


	void Update()
    {
		HS_T.text = "HIGHSCORE: " + hs.ToString();
        //Time.timeScale = 1;

    }





    public void PlayBtn()
	{

            SceneManager.LoadScene("Play");
     
	}

	public void Exit()
	{
		Application.Quit();
	}

}
