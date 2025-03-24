using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float Sensitivity;
    Camera cameras;
    Rigidbody rigidbodys;

    Vector2 MoveDir;

    private void Awake()
    {
        cameras = GetComponentInChildren<Camera>();
        rigidbodys = GetComponent<Rigidbody>();
    }

    private void Update()
    {
            Move();
            MouseMove();
      
    }

    private void OnMove(InputValue value)
    {
        MoveDir = value.Get<Vector2>();
    }

    private void Move()
    {
        
        Vector3 dir = -MoveDir.y * transform.right + MoveDir.x * transform.forward;
        dir *= Sensitivity;
        GetComponent<Rigidbody>().velocity = dir;
        
    }

    private void MouseMove()
    {
        float ScreenThreshhold = 100f;

        if (Input.mousePosition.y > Screen.height - ScreenThreshhold )
        {
            transform.position += -Vector3.right.normalized * Time.deltaTime * Sensitivity;
        }
        if (Input.mousePosition.y <  ScreenThreshhold )
        {
            transform.position += Vector3.right.normalized * Time.deltaTime * Sensitivity;
        }
        if (Input.mousePosition.x > Screen.width - ScreenThreshhold)
        {
            transform.position += Vector3.forward.normalized * Time.deltaTime * Sensitivity;
        }
        if (Input.mousePosition.x < ScreenThreshhold)
        {
            transform.position += -Vector3.forward.normalized * Time.deltaTime * Sensitivity;
        }
    }

}
