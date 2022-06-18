using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrUpSPDUpController : MonoBehaviour
{
    public PowerUpManager manager;

    public Collider2D ball;

    public int DestroyInterval;

    public float magnitude;
    public float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > DestroyInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            // speed up the ball
            ball.GetComponent<BallMovement>().ActivatePwrUpSPDUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
