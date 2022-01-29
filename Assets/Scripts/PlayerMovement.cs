using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
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
        }
        else if (playerInputs.toTheRight)
        {
            movement.x = 1;
            movement.y = 0;
        }
        else if (playerInputs.toUp)
        {
            movement.x = 0;
            movement.y = 1;
        }
        else if (playerInputs.toDown)
        {
            movement.x = 0;
            movement.y = -1;
        }
        movement.Normalize();

        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }
}
