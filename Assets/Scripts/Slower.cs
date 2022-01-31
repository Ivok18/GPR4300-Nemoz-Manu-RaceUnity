using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject, 2);
            PlayerMovement _playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            PlayerDatas _playerDatas = collision.gameObject.GetComponent<PlayerDatas>();
            _playerMovement.moveSpeed = _playerMovement.moveSpeed / 2;
            _playerDatas.slowed = true;
        }
    }
    
}
