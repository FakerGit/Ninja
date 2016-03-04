using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Follow : MonoBehaviour {
    private bool bgmSwitch;
    public Slider soundVol;
    public GameObject target;
    private AudioSource audioSource;
    void Awake()
    {
        bgmSwitch = true;
        audioSource = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {
        Vector3 pos = GetComponent<Transform>().position;
        pos.x = target.transform.position.x;
        GetComponent<Transform>().position = pos;
        audioSource.volume = soundVol.value;
        if (!bgmSwitch)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
	}

    public void BgmSwitch()
    {
        bgmSwitch=!bgmSwitch;
    }
}
