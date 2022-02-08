using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float MaxSpeed = 200.0f;
    [SerializeField] float acceleration = 10.0f;
    [SerializeField] Vector2 movement;

    private Rigidbody2D rb;
    private PlayerInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerInputs.toTheLeft)
        {
            movement.x = -1;
            movement.y = 0;
            transform.eulerAngles= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        }
        else if (playerInputs.toTheRight)
        {
            movement.x = 1;
            movement.y = 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90);
        }
        else if (playerInputs.toUp)
        {
            movement.x = 0;
            movement.y = 1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        else if (playerInputs.toDown)
        {
            movement.x = 0;
            movement.y = -1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
    
        movement.Normalize();

        //Increase player speed
        if (moveSpeed < MaxSpeed / 2)
            moveSpeed += Time.fixedDeltaTime * acceleration * 4;
        else
            moveSpeed += Time.fixedDeltaTime * acceleration;

        if (moveSpeed >= MaxSpeed)
            moveSpeed = MaxSpeed;

        //Change the rigibody's velocity
        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }
}
