using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceMe : MonoBehaviour {
    public GameObject headset;
    public Text Name;
    public Text Phone;
    public Text Location;
    public Text Status;
    
	// Use this for initialization
	void Start () {
        headset = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 facingHeadset = headset.position - transform.position;
        //transform.LookAt(headset.transform);
        var lookDir = transform.position - headset.transform.position;
        lookDir.y = 0f; //this is the critical part, this makes the look direction perpendicular to 'up'
        transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
    }
}
