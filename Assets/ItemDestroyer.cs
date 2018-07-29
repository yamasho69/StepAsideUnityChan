using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {

    private GameObject unitychan;
    private float offset = 5.0f;

	// Use this for initialization
	void Start () {

        this.unitychan = GameObject.Find("unitychan");
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(unitychan.transform.position.z);

        if (this.transform.position.z + offset <= unitychan.transform.position.z)
        { Destroy(this.gameObject);}
	}
}
