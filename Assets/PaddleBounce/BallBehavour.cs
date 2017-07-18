using UnityEngine;
using System.Collections;
using HoloToolkit.Unity.InputModule;
using System;

public class BallBehavour : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Rigidbody ballRigidBody = this.gameObject.GetComponent<Rigidbody>();
        ballRigidBody.useGravity = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
