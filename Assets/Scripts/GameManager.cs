using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager: MonoBehaviour {

    private   bool soundSwitch;
    public Slider soundSlider;
    private AudioSource audioSource;
	// Use this for initialization
	void Awake () {
        soundSwitch = true;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!soundSwitch)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }

        audioSource.volume = soundSlider.value;
	}

    public void NewGame()
    {
        Application.LoadLevel("001-Play");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SoundSwitch()
    {
        soundSwitch = !soundSwitch;
    }
}
