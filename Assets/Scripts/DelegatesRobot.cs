using System;
using UnityEngine;

public class Delegates
{
    // Define delegate method and signature
    delegate void RobotAction();
    // private property for delegate use
    RobotAction myRobotAction;


    void Start()
    {
        // Set the default method for the delegate
        myRobotAction = RobotWalk;
    }

    void Update()
    {
        // Run the selected delegate method on the update
        myRobotAction();
    }

    // public method to tell the robot to walk
    public void DoRobotWalk()
    {
        // set the delegate method to the walk function
        myRobotAction = RobotWalk;
    }

    void RobotWalk()
    {
        Debug.Log("Robot walking");
    }

    // public method to tell the robot to run
    public void DoRobotRun()
    {
        // Set the delegate method to the run function
        myRobotAction = RobotRun;
    }

    void RobotRun()
    {
        Debug.Log("Robot running");
    }
}