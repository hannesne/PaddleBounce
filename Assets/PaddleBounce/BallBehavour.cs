using UnityEngine;
using System.Collections;
using HoloToolkit.Unity.InputModule;
using System;

public class BallBehavour : MonoBehaviour, IInputClickHandler
{
    public GameObject Cursor;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //give the ball gravity so it starts falling.
        Rigidbody ballRigidBody = this.gameObject.GetComponent<Rigidbody>();
        ballRigidBody.useGravity = true;
        //Hide the cursor.
        if (this.Cursor != null)
        {
            this.Cursor.SetActive(false);
        }
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
