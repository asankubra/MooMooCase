using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateExample : MonoBehaviour
{
    public delegate void TestDelegate();
    public TestDelegate testDelegate;

    public Action action;

    // Start is called before the first frame update
    void Start()
    {
        action += DoWork;
        action?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DoWork() 
    {
        Debug.Log("one");
    }
    private void TestMetod() 
    {
        Debug.Log("two");

    }
}
