using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    public AudioClip finishSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //音效
            AudioManager._instance.PlaySingle(finishSound);
            GameController._instance.FinishLevel();
        }
    }
}
