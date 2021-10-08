using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableQuiz : MonoBehaviour
{
    public static TableQuiz instance = null;

    public TextMeshProUGUI roundNumText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI tableToGuessText;
    public TableInfo[] tables;
    [Space] public GameObject EndMenu;

    float roundTimerStartValue = 9.99f;
    float roundTimerWrongValue = 5;
    bool playerGuessedCorrectly = false;

    private int roundNum_ = 1;
    public int roundNum
    {
        get { return roundNum_; }
        set { roundNum_ = value;
            if(value <= 10)
            {
                roundNumText.text = "Round " + value + "/10";
            }
        }
    }

    private float timer_ = 0;
    public float timer
    {
        get { return timer_; }
        set { timer_ = value;
            if (timer_ < 0)
                timerText.text = "" + 0;
            else
            {
                timerText.text = "" + Math.Round(value, 2, MidpointRounding.AwayFromZero);
            }
        }
    }

    private float currentScore_;
    public float currentScore
    {
        get { return currentScore_; }
        set { currentScore_ = value;
              double num = Math.Round(value, 2, MidpointRounding.AwayFromZero);
              currentScoreText.text = "" + num;
        }
    }

    private string tableToFind_;
    public string tableToFind
    {
        get { return tableToFind_; }
        set { tableToFind_ = value;
            tableToGuessText.text = "" + value;
        }
    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GameStart()
    {
        StartCoroutine(GameCoroutine());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void tableChosen(string tableName)
    {
        if(tableName == tableToFind)
        {
            playerGuessedCorrectly = true;
            currentScore += Mathf.Abs(timer - roundTimerStartValue);
        }
        else
        {
            timer -= 5;
        }
    }

    private IEnumerator GameCoroutine()
    {
        currentScore = 0;
        roundNum = 1;
        while(roundNum <= 10)
        {
            //sets the table to find
            tableToFind = tables[UnityEngine.Random.Range(0, tables.Length)].name;

            timer = roundTimerStartValue;
            playerGuessedCorrectly = false;
            while (timer > 0 && !playerGuessedCorrectly)
            {
                yield return new WaitForSeconds(0.01f);
                timer -= 0.01f;
            }
            if(timer <= 0)
            {
                currentScore += 10f;
            }
            roundNum++;
        }
        EndMenu.SetActive(true);
    }

    private IEnumerator StartTimer()
    {

        while (timer > 0 && !playerGuessedCorrectly)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }
    }

    /*private void SetTableNumbersActive(bool b)
    {
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i]
        }
    }*/
}
