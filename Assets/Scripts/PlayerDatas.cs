using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas : MonoBehaviour
{
    [SerializeField] public int nbOfCollisionWithBorders = 0;
    [SerializeField] public RaceManager raceManager;
    [SerializeField] public bool respawnAtStartPoint = false;
    [SerializeField] public bool canTp = false;
    [SerializeField] public bool enableSpeedRevovery = false;
    [SerializeField] public bool slowed = false;

    PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(respawnAtStartPoint)
        {
            transform.position = raceManager.playerStartPoint.transform.position;
            respawnAtStartPoint = false;
        }

        if(canTp)
        {
            transform.position = raceManager.tpPoint.transform.position;
            PlayerInputs _playerInputs = GetComponent<PlayerInputs>();
            _playerInputs.toDown = true;
            _playerInputs.toUp = false;
            _playerInputs.toTheLeft = false;
            _playerInputs.toTheRight = false;
            canTp = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("border"))
        {
            nbOfCollisionWithBorders++;
            movement.moveSpeed /= 1.5f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("border"))
        {
            nbOfCollisionWithBorders++;
            movement.moveSpeed /= 1.05f;
        }
    }
}
