using UnityEngine;
using System.Collections;

public class Award : MonoBehaviour {

    public int point;

    public float speed = 120;
    public AudioClip awardSound;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().Rotate(-Vector3.forward * speed * Time.deltaTime);
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //加分
            GameController._instance.AddScore(point);
            //音效
            AudioManager._instance.PlaySingle(awardSound);
            Destroy(this.gameObject);
        }
    }
}
