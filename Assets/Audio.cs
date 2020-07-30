using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    public AudioClip sound;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        AudioSource point = GetComponent<AudioSource>();
        point.PlayOneShot(sound);
    }
}
