using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15;
    private float turnSpeed = 15;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (ShouldGoForward())
        {
            MoveVertical();
        }

        if (ShouldRotate())
        {
            MoveHorizon();
        }
        
    }

    private bool ShouldGoForward()
    {
        return true;
    }

    private void MoveVertical()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    }

    private bool ShouldRotate()
    {
        return Mathf.Clamp(forwardInput, -0.1f, 0.1f) != forwardInput;
    }

    private void MoveHorizon()
    {
        var rotateAngle = horizontalInput * turnSpeed * Time.deltaTime;
        if (forwardInput > 0)
        {
            transform.Rotate(Vector3.up, rotateAngle);
        }
        else
        {
            transform.Rotate(Vector3.down, rotateAngle);
        }
        
    }
}