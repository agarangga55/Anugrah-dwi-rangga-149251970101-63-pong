using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePowerUp : MonoBehaviour
{
    public PowerUpManager manager;

    public int multiplier;

    public float duration;

    public float powerUpDuration;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        powerUpDuration -= Time.deltaTime;
        if (powerUpDuration <= 0)
        {
            manager.RemovePowerUp(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();
        if (ball != null)
        {
            Interacted(ball, multiplier, duration);
        }
    }

    protected virtual void Interacted(BallMovement _ball, int _multiplier, float _duration)
    {
        manager.RemovePowerUp(gameObject);
    }
}
