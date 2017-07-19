using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BladeBehaviour : MonoBehaviour, IInputHandler
{
    public GameObject Cursor;
    public GameObject Ball;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    // Use this for initialization
    void Start ()
    {
        Transform ballTransform = Ball.GetComponent<Transform>();
        originalPosition = ballTransform.position;
        originalRotation = ballTransform.rotation;

    }
    

    public void OnInputDown(InputEventData eventData)
    {
        SetGameActive(true);
    }

    private void SetGameActive(bool active)
    {
        Rigidbody ballRigidBody = Ball.GetComponent<Rigidbody>();
        ballRigidBody.useGravity = active;
        if (!active)
        {
            ballRigidBody.isKinematic = true;
            ballRigidBody.MovePosition(originalPosition);
            ballRigidBody.MoveRotation(originalRotation);
            ballRigidBody.isKinematic = false;
        }
        //Hide the cursor.
        if (this.Cursor != null)
        {
            this.Cursor.SetActive(!active);
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        SetGameActive(false);
        Ball.GetComponent<Transform>().SetPositionAndRotation(originalPosition, originalRotation);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
