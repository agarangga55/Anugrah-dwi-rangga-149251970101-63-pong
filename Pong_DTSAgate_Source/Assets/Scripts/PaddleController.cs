using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public int normalSpeed;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    public Vector3 normalTransform;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //// to get input
        // Vector3 movement = GetInput();

        //// to move object
        // MoveObject(movement);

        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        if(Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        ///transform.Translate(movement * Time.deltaTime);
        Debug.Log("Test:" + movement);
        rig.velocity = movement;
    }

    public void SpeedPWRUp(int _pwrMultiplier, float _duration)
    {
        StartCoroutine(PaddleSpeedPWRUp(_pwrMultiplier, _duration));
    }
    public void LenghtPWRUp(int _pwrMultiplier, float _duration)
    {
        StartCoroutine(PaddleLenghtPWRUp(_pwrMultiplier, _duration));
    }


    private IEnumerator PaddleLenghtPWRUp (int _pwrMultiplier, float _duration)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * _pwrMultiplier, transform.localScale.z);
        yield return new WaitForSeconds(_duration);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / _pwrMultiplier, transform.localScale.z);
    }

    private IEnumerator PaddleSpeedPWRUp (int _pwrMultipler, float _duration)
    {
        speed *= _pwrMultipler;
        yield return new WaitForSeconds(_duration);
        speed /= _pwrMultipler;
    }

    public void StatsReset()
    {
        StopAllCoroutines();
        speed = normalSpeed;
        transform.localScale = normalTransform;
    }
}
