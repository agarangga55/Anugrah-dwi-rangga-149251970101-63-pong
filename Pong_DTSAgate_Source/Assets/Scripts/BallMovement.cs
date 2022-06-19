using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 normalSpeed;
    public Vector2 resetPosition;

    public PaddleController paddle;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * Time.deltaTime);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
        rig.velocity = normalSpeed;
    }

    public void ActivatePwrUpSPDUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PaddleController paddleSel = collision.gameObject.GetComponent<PaddleController>();
        if(paddleSel != null)
        {
            paddle = paddleSel;
        }
    }
}
