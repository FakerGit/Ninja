using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = GetComponent<Transform>().position;
        pos.x = target.transform.position.x;
        GetComponent<Transform>().position = pos;
	}
}
