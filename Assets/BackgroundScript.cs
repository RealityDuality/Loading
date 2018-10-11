using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    private Animator background;
    public AudioSource glitch;

    // Use this for initialization
    void Start () {
        background = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            background.SetTrigger("Active");
            glitch.Play();
        } else
        {
            background.ResetTrigger("Active");
        }
	}
}
