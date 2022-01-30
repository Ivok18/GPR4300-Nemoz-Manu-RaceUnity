using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerDatas _playerDatas = collision.transform.GetComponent<PlayerDatas>();
            _playerDatas.canTp = true;
        }
    }
}
