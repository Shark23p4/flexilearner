using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class questionHandler : MonoBehaviour
{
    int curr = 0;
    public Button[] buttons;
    public GameObject continueButton;
    public Question[] questionPool;
    public TextMeshProUGUI questionText;
    public GameObject meaning;
    public GameObject plusText;
    public TextMeshProUGUI streakText;
    public mechanicHandler mechanics;
    int currentPool = 0;
    public Camera cam;
    public GameObject gameCanvas;
    public GameObject feedbackCanvas;
    Color buttonColor;
    public GameObject Death;
    // Start is called before the first frame update
    void Start()
    {
        nextQuestion();
        mechanics.initialize();
        buttonColor = buttons[0].GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressedButton(int index)
    {
        buttons[index].GetComponent<Image>().color = Color.red;
        buttons[questionPool[currentPool].questions[curr].rightAnswer].GetComponent<Image>().color = Color.green;
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        bool rightAnswer = false;
        if(index == questionPool[currentPool].questions[curr].rightAnswer)
            rightAnswer = true;
        mechanics.questionSolved(rightAnswer);
        continueButton.SetActive(true);
        //send timestamp to db
    }

    void nextQuestion()
    {
        try { Question pool = questionPool[currentPool]; }
        catch {
            return;
        }
        meaning.SetActive(false);
        plusText.SetActive(false);
        streakText.color = Color.black;
        meaning.GetComponentInChildren<TextMeshProUGUI>().text = questionPool[currentPool].questions[curr].meaning;
        questionText.text = questionPool[currentPool].questions[curr].theQuestion;
        buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[currentPool].questions[curr].answer1;
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[currentPool].questions[curr].answer2;
        buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[currentPool].questions[curr].answer3;
        buttons[3].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[currentPool].questions[curr].answer4;
        //send timestamp to db
    }

    public void continueHandler()
    {
        if (Death.activeInHierarchy)
        {
            Death.SetActive(false);
            curr = -1;
            mechanics.initialize();
        }
        curr++;
        if(curr < questionPool[currentPool].questions.Length)
        {
            foreach (var button in buttons)
            {
                button.interactable = true;
                button.GetComponent<Image>().color = buttonColor;
            }
            continueButton.SetActive(false);
            nextQuestion();
        }
        else
        {
            try
            {
                mechanics.seedHandler.nextConfig();
            }
            catch (Exception e) { }
            mechanics.initialize();
            currentPool++;
            curr = 0;
            foreach (var button in buttons)
            {
                button.interactable = true;
                button.GetComponent<Image>().color = buttonColor;
            }
            continueButton.SetActive(false);
            nextQuestion();
            gameCanvas.SetActive(false);
            feedbackCanvas.SetActive(true);
        }
    }

    public bool done()
    {
        return currentPool >= questionPool.Length;
    }
}
