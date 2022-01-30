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

        if(slowed)
        {
            if (!GameObject.FindGameObjectWithTag("obstacle"))
            {
                slowed = false;
                PlayerMovement _playerMovement = GetComponent<PlayerMovement>();
                _playerMovement.moveSpeed *= 2;
            }
        }

       
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("border"))
        {
            nbOfCollisionWithBorders++;
            
        }

    }

    
}
