using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BladeBehaviour : MonoBehaviour, IInputHandler
{
    public GameObject Cursor;
    public GameObject Ball;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool checkMoving;
    private bool gameActive;

    // Use this for initialization
    void Start ()
    {
        Transform ballTransform = Ball.transform;
        originalPosition = ballTransform.position;
        originalRotation = ballTransform.rotation;

    }
    

    public void OnInputDown(InputEventData eventData)
    {
        SetGameActive(true);
    }

    private void SetGameActive(bool active)
    {
        gameActive = active;
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

    List<float> lastBallVelocities = new List<float>();
	
	// Update is called once per frame
	void Update () {
        /*
         *the ball sometimes gets stuck in thin air when you move the paddle away.
         *we'll check if the game is going and the ball is not currently resting on the paddle
         *if the velocity of the ball is static over the last 3 frames, we apply a small upwards force
         *to get it going again, if we're sure it's moving, we just stop checking*/
		if (gameActive && checkMoving)
        {
            float sqrMagnitude = Ball.transform.position.sqrMagnitude;
            lastBallVelocities.Add(sqrMagnitude);

            if (lastBallVelocities.Count == 3)
            {
                if (lastBallVelocities.All(item => item == sqrMagnitude))
                {
                    Debug.Log("Stuck? Pop!");
                    Rigidbody ballRigidBody = Ball.GetComponent<Rigidbody>();
                    ballRigidBody.AddForce(new Vector3(0, 0.0001f, 0), ForceMode.Impulse);
                }
                checkMoving = false;
                lastBallVelocities.Clear();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        checkMoving = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        checkMoving = true;
    }
}
