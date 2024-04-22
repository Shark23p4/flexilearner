using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class feedbackHandler : MonoBehaviour
{
    seedHandler seedHandler;
    int feedBackIndex = 0;
    public int[,] feedBackTable = new int[4,8];
    public bool[] gotFeedback = new bool[8];
    string config;
    public GameObject gameCanvas;
    public GameObject feedbackCanvas;
    public GameObject endCanvas;

    public GameObject failText;
    //public questionHandler questionHandler;

    // circles
    public GameObject[] supportCircles;
    public GameObject[] complicatonCircles;
    public GameObject[] efficiencyCircles;
    public GameObject[] clarityCircles;
    public GameObject[] excitementCircles;
    public GameObject[] interestCircles;
    public GameObject[] innovationCircles;
    public GameObject[] usualnessCircles;

    bool ended = false;
    // Start is called before the first frame update
    void Start()
    {
        seedHandler = FindAnyObjectByType<seedHandler>();
        if (seedHandler != null)
        {
            config = seedHandler.sequence;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void supportFeedback(int i)
    {
        feedBackTable[feedBackIndex,0] = i;
        gotFeedback[0] = true;
        foreach (GameObject circle in supportCircles)
        {
            circle.SetActive(false);
        }
        supportCircles[i].SetActive(true);
    }

    public void complicatonFeedback(int i)
    {
        feedBackTable[feedBackIndex,1] = i;
        gotFeedback[1] = true;
        foreach (GameObject circle in complicatonCircles)
        {
            circle.SetActive(false);
        }
        complicatonCircles[i].SetActive(true);
    }

    public void efficiencyFeedback(int i)
    {
        feedBackTable[feedBackIndex,2] = i;
        gotFeedback[2] = true;
        foreach (GameObject circle in efficiencyCircles)
        {
            circle.SetActive(false);
        }
        efficiencyCircles[i].SetActive(true);
    }

    public void clarityFeedback(int i)
    {
        feedBackTable[feedBackIndex,3] = i;
        gotFeedback[3] = true;
        foreach (GameObject circle in clarityCircles)
        {
            circle.SetActive(false);
        }
        clarityCircles[i].SetActive(true);
    }

    public void excitementFeedback(int i)
    {
        feedBackTable[feedBackIndex,4] = i;
        gotFeedback[4] = true;
        foreach (GameObject circle in excitementCircles)
        {
            circle.SetActive(false);
        }
        excitementCircles[i].SetActive(true);
    }

    public void interestFeedback(int i)
    {
        feedBackTable[feedBackIndex,5] = i;
        gotFeedback[5] = true;
        foreach (GameObject circle in interestCircles)
        {
            circle.SetActive(false);
        }
        interestCircles[i].SetActive(true);
    }

    public void innovationFeedback(int i)
    {
        feedBackTable[feedBackIndex,6] = i;
        gotFeedback[6] = true;
        foreach (GameObject circle in innovationCircles)
        {
            circle.SetActive(false);
        }
        innovationCircles[i].SetActive(true);
    }

    public void usualnessFeedback(int i)
    {
        feedBackTable[feedBackIndex,7] = i;
        gotFeedback[7] = true;
        foreach (GameObject circle in usualnessCircles)
        {
            circle.SetActive(false);
        }
        usualnessCircles[i].SetActive(true);
    }

    public void submitFeedback()
    {
        if(!gotFeedback.Contains(false))
        {
            //send to db here
            gotFeedback = new bool[8];
            feedBackIndex += 1;
            feedbackCanvas.SetActive(false);
            for(int i = 0; i<7; i++)
            {
                supportCircles[i].SetActive(false);
                complicatonCircles[i].SetActive(false);
                efficiencyCircles[i].SetActive(false);
                clarityCircles[i].SetActive(false);
                excitementCircles[i].SetActive(false);
                interestCircles[i].SetActive(false);
                innovationCircles[i].SetActive(false);
                usualnessCircles[i].SetActive(false);
            }
            if (feedBackIndex > 3)
            {
                endCanvas.SetActive(true);
            }
            else
            {
                gameCanvas.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(displayError());
        }
    }

    IEnumerator displayError()
    {

        failText.SetActive(true);
        yield return new WaitForSeconds(4);
        failText.SetActive(false);
    }
}
