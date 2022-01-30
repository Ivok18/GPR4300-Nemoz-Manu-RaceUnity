using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerDatas _playerDatas = collision.gameObject.GetComponent<PlayerDatas>();
            _playerDatas.respawn = true;
        }
    }
}
