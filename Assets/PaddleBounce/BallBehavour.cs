using UnityEngine;
using System.Collections;
using HoloToolkit.Unity.InputModule;
using System;
using HoloToolkit.Unity;

public class BallBehavour : MonoBehaviour
{

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        //preload our audio data
        audioSource.clip.LoadAudioData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        
    }


}
