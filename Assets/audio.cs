using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {
    public AudioClip soundFile;
    AudioSource mySound;
    private void Awake()
    {
       
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("MysoundFunction", 3f);
    }

    void MysoundFunction()
    {
        mySound.PlayOneShot(soundFile);
    }
}
