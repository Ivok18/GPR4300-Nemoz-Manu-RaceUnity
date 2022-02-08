using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    RaceManager manager;
    [SerializeField] int id;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<RaceManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReportToManager();
    }

    private void ReportToManager()
    {
        manager.UpdateProgress(id);
    }
}
