using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public AudioClip changeSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            //音效
            AudioManager._instance.PlaySingle(changeSound);
            Destroy(this.gameObject);
        }
    }
}
