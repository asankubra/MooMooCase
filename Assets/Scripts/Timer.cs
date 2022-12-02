using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    bool timerActive = false;
    public float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    public int GameTime;

    void Start()
    {
        currentTime = startMinutes * GameTime;
        timerActive = true;
    }

    
    void Update()
    {
        if (timerActive == true)
        if (timerActive == true)
        {
             currentTime  -= Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = 0;
                JoystickController.OnloseGame.Invoke();
            }
        }
       
        currentTimeText.text = ((int)currentTime).ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
