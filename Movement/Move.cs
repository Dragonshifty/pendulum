using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigid;
    Pendulum pendulum;

    Vector2 moveInput;
    [SerializeField] float moveSpeed = 100f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pendulum = FindObjectOfType<Pendulum>();
    }

    void Update()
    {
        if (Keyboard.current.anyKey.isPressed)
        {
            pendulum.StartRotation(false);
        } else 
        {
            pendulum.StartRotation(true);
        }
    }

    private void FixedUpdate()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        if (moveInput != Vector2.zero)
        {
            rigid.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }
}
