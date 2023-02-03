using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Material TurnedOffMat;
    public Material TurnedOnMat;
    public bool State = false;
    public float CoolDownTime = 0;
    public float timeRemaining;
    private GameObject player;
    public int ElectricityUsage;
    private PlayerController playerCont;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCont = (PlayerController)player.GetComponent(typeof(PlayerController));
    }



    void Update()

    {
        if (timeRemaining > 0)

        {
            timeRemaining -= Time.deltaTime;
        }
    }


    void OnMouseOver()
    {
        if (Time.timeScale > 0 && timeRemaining <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeMesh();
            }
            if (Input.GetMouseButtonDown(1))
            {
                print(name);
            }
        }
    }

    void ChangeMesh()
    {
        if (State)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }
    public void TurnOff()
    {
        if (TurnedOffMat)
        {
            GetComponent<Renderer>().material = TurnedOffMat;
        }
        if (GetComponent<Light>())
        {
            GetComponent<Light>().enabled = false;
        }
        State = false;
        playerCont.RemoveUsed(ElectricityUsage);
        timeRemaining = 0;
    }

    void TurnOn()
    {
        if (TurnedOnMat)
        {
            GetComponent<Renderer>().material = TurnedOnMat;
        }
        if (GetComponent<Light>())
        {
            GetComponent<Light>().enabled = true;
        }
        State = true;
        timeRemaining = CoolDownTime;
        playerCont.AddUsed(ElectricityUsage);
    }

    public void CrashOff()
    {
        if (TurnedOffMat)
        {
            GetComponent<Renderer>().material = TurnedOffMat;
        }
        if (GetComponent<Light>())
        {
            GetComponent<Light>().enabled = false;
        }
        State = false;
        timeRemaining = 0;
    }

    public bool GetState()
    {
        return State;
    }
}
