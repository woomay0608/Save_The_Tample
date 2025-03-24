using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float Sensitivity;
    Camera camera;
    Rigidbody rigidbody;

    Vector2 MoveDir;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
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
        rigidbody.velocity = dir;
        
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
