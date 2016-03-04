using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    private bool soundSwitch;
    public Slider soundSlider;
    public static AudioManager _instance;
    private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        soundSwitch = true;
	
	}
    void Update()
    {
        audioSource.volume = soundSlider.value;
    }
	    public void PlaySingle(AudioClip clip)
    {
        if (soundSwitch)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

        public void SwitchSound()
        {
            soundSwitch = !soundSwitch;
        }
}
