using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(10f, 0, 0) * Time.deltaTime);
	}
}
