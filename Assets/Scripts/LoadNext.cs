using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNext : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("MyLoadingFunction", 5f);
    }
    void MyLoadingFunction()
    {
        Application.LoadLevel("Main");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
