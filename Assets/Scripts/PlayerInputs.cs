using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] public bool toTheLeft, toTheRight, toUp, toDown = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            toTheLeft = true;
            toTheRight = false;
            toUp = false;
            toDown = false;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            toTheLeft = false;
            toTheRight = true;
            toUp = false;
            toDown = false;

        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            toTheLeft = false;
            toTheRight = false;
            toUp = true;
            toDown = false;

        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            toTheLeft = false;
            toTheRight = false;
            toUp = false;
            toDown = true;
        }
    }
}
