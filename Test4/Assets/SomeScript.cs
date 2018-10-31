using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour {
    public GameObject someObject;
    public float speedX;
    public float speedY;
    public float speedZ;
    TestScript testScript;
	// Use this for initialization
	void Start () {
        testScript = GameObject.Find("Player").GetComponent<TestScript>();
	}
	
	// Update is called once per frame
	void Update () {
        testScript.LookSomewhere(someObject);
	}
}
