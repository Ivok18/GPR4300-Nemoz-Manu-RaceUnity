using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas : MonoBehaviour
{
    [SerializeField] public int nbOfCollisionWithMap = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("border") || collision.transform.CompareTag("obstacle"))
        {
            nbOfCollisionWithMap++;
        }
       
    }
}
