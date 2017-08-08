using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour, IInputHandler
{
    public GameObject Cursor;
    public GameObject Ball;
    public GameObject BallPrefab;
    public GameObject scoreboard;
    private ScoreboardBehaviour scoreboardBehaviour;
    private bool gameActive;

    // Use this for initialization
    void Start ()
    {
        if (Ball == null)
            Ball = Instantiate(BallPrefab);
        scoreboardBehaviour = scoreboard.GetComponent<ScoreboardBehaviour>();
    }
    

    public void OnInputDown(InputEventData eventData)
    {
        SetGameActive(true);
    }

    private void SetGameActive(bool active)
    {
        gameActive = active;
        if (!active)
        {
            Ball = Instantiate(BallPrefab);        
        }
        else
        {
            scoreboardBehaviour.ResetScore();
            Rigidbody ballRigidBody = Ball.GetComponent<Rigidbody>();
            ballRigidBody.useGravity = active;
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
