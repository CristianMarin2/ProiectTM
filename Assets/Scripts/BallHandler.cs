using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallHandler : MonoBehaviour
{
    public Transform ballHoldPoint;
    public GameObject ball;
    private bool isHolding = false;
    private Rigidbody ballRb;

    private Vector3 initialBallPosition;
private Quaternion initialBallRotation;
private Vector3 initialPlayerPosition;
private Quaternion initialPlayerRotation;



    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();

        initialBallPosition = ball.transform.position;
    initialBallRotation = ball.transform.rotation;
    initialPlayerPosition = transform.position;
    initialPlayerRotation = transform.rotation;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isHolding && Vector3.Distance(transform.position, ball.transform.position) < 2f)
        {
            PickUpBall();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isHolding)
        {
            DropBall();
        }

        if (Input.GetMouseButtonDown(0) && isHolding) // Left click to shoot
        {
            ShootBall();
        }
    }

    void PickUpBall()
    {
        ballRb.isKinematic = true;
        ball.transform.SetParent(ballHoldPoint);
        ball.transform.localPosition = Vector3.zero;
        isHolding = true;
    }

    void DropBall()
    {
        ball.transform.SetParent(null);
        ballRb.isKinematic = false;
        isHolding = false;
    }

    void ShootBall()
{
    DropBall();

    // Move ball slightly forward from player before shooting
    ball.transform.position += transform.forward * 0.5f;

    // Add some upward arc to the shot
    Vector3 shootDir = (transform.forward + transform.up * 0.3f).normalized;

    // 💡 Add player's velocity to the ball
    Rigidbody playerRb = GetComponent<Rigidbody>();
    if (playerRb != null)
    {
        ballRb.linearVelocity = playerRb.linearVelocity;
    }

    // Apply shooting force
    ballRb.AddForce(shootDir * 500f);
}

public void ResetPositions()
{
    // Reset ball
    ball.transform.SetParent(null);
    ball.transform.position = initialBallPosition;
    ball.transform.rotation = initialBallRotation;
    ballRb.linearVelocity = Vector3.zero;
    ballRb.angularVelocity = Vector3.zero;
    ballRb.isKinematic = false;

    // Reset player
    transform.position = initialPlayerPosition;
    transform.rotation = initialPlayerRotation;

    isHolding = false;
}
}