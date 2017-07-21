using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour, IInputHandler
{
    public GameObject Cursor;
    public GameObject Ball;
    public GameObject scoreboard;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private ScoreboardBehaviour scoreboardBehaviour;
    private bool gameActive;

    // Use this for initialization
    void Start ()
    {
        Transform ballTransform = Ball.transform;
        originalPosition = ballTransform.position;
        originalRotation = ballTransform.rotation;
        scoreboardBehaviour = scoreboard.GetComponent<ScoreboardBehaviour>();
    }
    

    public void OnInputDown(InputEventData eventData)
    {
        SetGameActive(true);
    }

    private void SetGameActive(bool active)
    {
        Rigidbody ballRigidBody = Ball.GetComponent<Rigidbody>();
        gameActive = active;
        ballRigidBody.useGravity = active;
        if (!active)
        {
            ballRigidBody.isKinematic = true;
            Ball.GetComponent<Transform>().SetPositionAndRotation(originalPosition, originalRotation);
            ballRigidBody.isKinematic = false;
        }
        else
        {
            scoreboardBehaviour.ResetScore();
        }
        //Hide or show the cursor.
        if (this.Cursor != null)
        {
            this.Cursor.SetActive(!active);
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        SetGameActive(false);

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == Ball)
        {
            
            if (gameActive)
                scoreboardBehaviour.IncrementScore();
            else
                //Sometimes when the ball comes to rest on the paddle, and you pull the paddle down from under it
                //the rigid body isn't woken up and the ball stays stuck in mid-air.
                //We make sure to wake the ball up when it leaves the paddle. 
                Ball.GetComponent<Rigidbody>().WakeUp();
        }
    }
}
