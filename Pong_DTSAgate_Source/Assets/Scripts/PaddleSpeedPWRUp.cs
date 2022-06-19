using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedPWRUp : PaddlePowerUp
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    protected override void Interacted(BallMovement _ball, int _multiplier, float _duration)
    {
        _ball.paddle.SpeedPWRUp(_multiplier, _duration);
        base.Interacted(_ball, _multiplier, _duration);
    }
}
