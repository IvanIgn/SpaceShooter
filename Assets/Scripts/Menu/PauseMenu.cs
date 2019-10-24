using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool Pause = false;
	public bool sound = false;
	public Color[] soundColors;
	public Text soundBtn;
	public GameObject PausePanel;

	void Start()
	{
		if(AudioListener.volume <= 0)
		{
			sound = false;
			soundBtn.color = soundColors[1];
		}
		else
		{
			soundBtn.color = soundColors[0];
			sound = true;
		}
	}

	public void PauseM()
	{
		if(Pause == true)
		{
			PausePanel.SetActive(false);
			Time.timeScale = 1f;
			Pause = false;
			return;
		}
		if(Pause == false)
		{
			PausePanel.SetActive(true);
			Time.timeScale = 0f;
			Pause = true;
			return;
		}
	}
    
	public void Restart()
	    {
            SceneManager.LoadScene("Play");
	    }
    
	public void MainMenuBtn()
	    {
            SceneManager.LoadScene("MainMenu");
        }

	public void Sound()
	{
	    if(sound == true)
	    {
		    AudioListener.volume = 0;
		    soundBtn.color = soundColors[1];
		    sound = false;
		    return;
	    }
	    if(sound == false)
	    {
		    AudioListener.volume = 1;
		    soundBtn.color = soundColors[0];
		    sound = true;
		    return;
	    }
	}

}
