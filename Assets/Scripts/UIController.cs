using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;

    private void OnEnable()
    {
        JoystickController.OnwinGame += Win;
        JoystickController.OnloseGame += Lose;
    }

    private void OnDisable()
    {
        JoystickController.OnwinGame -= Win;
        JoystickController.OnloseGame -= Lose;
    }
    void Win()
    {
        WinPanel.SetActive(true);
    }

    void Lose()
    {
        LosePanel.SetActive(true);
    }

    
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
