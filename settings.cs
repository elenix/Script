using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class settings : MonoBehaviour {

    public GameObject cardboard;
    public GameObject line;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void changeScreen()
    {
        line.SetActive(true);
    }
}
