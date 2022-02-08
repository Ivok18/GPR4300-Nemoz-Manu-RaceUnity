using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerStartPoint;
    public GameObject tpPoint;
    public Portal portal;

    int currentCheckpoint = 0;
    int numCheckpoints = 0;
    [SerializeField] int laps;
    [SerializeField] int lapsToDo = 5;

    [SerializeField] float timer = 60.0f;
    float timeLeft = 0;

    [SerializeField] TMP_Text timerTxt;
    [SerializeField] TMP_Text lapsTxt;


    void Start()
    {
        timeLeft = timer;
        player.transform.position = playerStartPoint.transform.position;
        numCheckpoints = GameObject.FindGameObjectsWithTag("checkpoint").Length;

        //Setup the ui
        AddLap();
    }

    void Update()
    {
        //Update the timer
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            TimerRunOut();
        }

        //Update the timer's display
        timerTxt.text = "Timer : " + timeLeft.ToString("0.##"); //Show only two digits after the decimal
    }

    //Called by checkpoints to report the curent progress in the lap
    public void UpdateProgress(int checkpointId)
    {
        //Check if the checkpoint crossed is the one after the last we crossed. (i.e. if we're doing them in order)
        if (checkpointId - currentCheckpoint == 1 || (checkpointId == 0 && currentCheckpoint == numCheckpoints - 1))
        {
            currentCheckpoint = checkpointId;

            //Check if we cross the start
            if (checkpointId == 0)
            {
                AddLap();

                //Check if we finished the race
                if (laps >= lapsToDo)
                {
                    Finish();
                }
            }
        }
    }

    void AddLap()
    {
        laps++;

        //Update the lap display
        lapsTxt.text = "Laps : " + laps + " / " + lapsToDo; 
    }

    void Finish()
    {
        portal.gameObject.SetActive(true);
    }

    void TimerRunOut()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
