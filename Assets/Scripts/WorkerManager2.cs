using System;
using System.Collections.Generic;

public class WorkerManager2
{
    delegate void MyDelegatehook();
    MyDelegatehook ActionsToDo;

    public string WorkerType = "Peon";

    // On Startup, assign jobs to the worker, note this is 
    // configurate instead of fixed
    void Start()
    {
        // Peans get lots of work to do
        if (WorkerType == "Peon")
        {
            ActionsToDo += DoJob1;
            ActionsToDo += DoJob2;
        }
        // Everyone else plays golf
        else
        {
            ActionsToDo += DoJob3;
        }
    }

    // With update, do the actions on ActionsToDo
    void Update()
    {
        ActionsToDo();
    }

    private void DoJob1()
    {
        // Do some filling
    }


    private void DoJob2()
    {
        // Make coffe for the office
    }

    private void DoJob3()
    {
        // Play Golf
    }
}