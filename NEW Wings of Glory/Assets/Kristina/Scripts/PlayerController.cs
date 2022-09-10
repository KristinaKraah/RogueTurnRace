using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        rb.velocity = ctx.ReadValue<Vector3>() * speed;
    }
}
