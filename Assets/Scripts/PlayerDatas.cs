using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas : MonoBehaviour
{
    [SerializeField] public int nbOfCollisionWithMap = 0;
    [SerializeField] public RaceManager raceManager;
    [SerializeField] public bool respawn = false;
    [SerializeField] public bool canTp = false;

    private void Update()
    {
        if(respawn)
        {
            transform.position = raceManager.playerStartPoint.transform.position;
            respawn = false;
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
        if(collision.transform.CompareTag("border") || collision.transform.CompareTag("obstacle"))
        {
            nbOfCollisionWithMap++;
        }

    }

    
}
