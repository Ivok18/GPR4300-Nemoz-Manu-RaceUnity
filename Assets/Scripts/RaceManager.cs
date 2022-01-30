using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerStartPoint;
    [SerializeField] public GameObject tpPoint;
    [SerializeField] public Portal portal;

    // Update is called once per frame
    void Update()
    {
        //TODO -> vérification de cette condition à la fin de chaque tour
        if(player.GetComponent<PlayerDatas>().nbOfCollisionWithMap > 10)
        {
            portal.gameObject.SetActive(true);
        }
    }
}
