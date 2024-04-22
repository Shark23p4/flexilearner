using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mechanicHandler : MonoBehaviour
{
    bool progressOn;
    bool heartsOn;
    bool pointsOn;
    bool meaningOn;
    bool streakOn;
    public GameObject meaning;
    public GameObject[] progressCircles;
    public int currentProgress;
    public GameObject[] hearts;
    int hp;
    public TextMeshProUGUI pointText;
    public GameObject plusText;
    int points = 0;
    int streak = 0;
    public TextMeshProUGUI streakText;
    public seedHandler seedHandler;
    public GameObject Death;

    public GameObject[] UIElements;
    // Start is called before the first frame update
    void Start()
    {
       seedHandler = FindAnyObjectByType<seedHandler>();
        accessConfig();
    }




    void accessConfig()
    {
        progressOn = seedHandler.progressOn;
        heartsOn = seedHandler.heartsOn;
        pointsOn = seedHandler.pointsOn;
        if(seedHandler == null)
        {
            heartsOn = true;
            pointsOn = true;
        }
        meaningOn = seedHandler.meaningOn;
        streakOn = seedHandler.streakOn;

        UIElements[0].SetActive(progressOn);
        UIElements[1].SetActive(heartsOn);
        UIElements[2].SetActive(pointsOn);
        UIElements[3].SetActive(meaningOn);
        UIElements[4].SetActive(streakOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void initialize()
    {
        for (int i = 1; i < progressCircles.Length; i++)
        {
            progressCircles[i].SetActive(false);
            progressCircles[i].GetComponent<SpriteRenderer>().color = Color.red;
        }
        currentProgress = 0;
        hp = hearts.Length;
        foreach(GameObject heart in hearts) 
            heart.GetComponent<SpriteRenderer>().color = Color.white;
        points = 0;
        pointText.text = "Score: 0";
        streakText.text = "Streak: 0";
        streak = 0;
        accessConfig();
    }

    public void questionSolved(bool correct)
    {
        if (meaningOn)
        {
            meaning.SetActive(true);
        }
        if (progressOn)
        {
            progressCircles[currentProgress].GetComponent<SpriteRenderer>().color = Color.green;
            currentProgress += 1;
            if (currentProgress < progressCircles.Length)
                progressCircles[currentProgress].SetActive(true);
        }
        if (heartsOn && !correct)
        {
            hp -= 1;
            if(hp > -1)
            {
                hearts[hp].GetComponent<SpriteRenderer>().color = Color.black;
            }
           if (hp<=0) {
                Death.SetActive(true);

            }
        }
        if(pointsOn && correct)
        {
            points += 5;
            plusText.SetActive(true);
            pointText.text = "Score: " + points;
        }
        if (streakOn)
        {
            if (correct)
            {
                streak += 1;
                streakText.color = Color.green;
            }
            else
            {
                streak = 0;
                streakText.color = Color.red;
            }
            streakText.text = "Streak: "+streak;
        }
    }
}
