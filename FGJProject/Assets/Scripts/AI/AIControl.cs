using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class AIControl : MonoBehaviour {

    // Storage for the prefab
    public NavMeshAgent agent;
    public GameObject[] targets;
    public Int32 pathIndex = -1;
    Vector3 targetLocation;
    private bool found = false; 
    public int[] waitTimes;
    private int countdown = 0;

    private InteractableObject TarObject;
    private Wapoint TarWaypoint;


    public Score score;

    private Animator anim;
    void Start() {
        anim = GetComponentInChildren<Animator>();
        // Grab hold of the agents NavMeshAgent
        MoveToNext();
    }

    void Update()
    {
        if (targets.Length > pathIndex) 
        { 
        if(Vector3.Distance(targets[pathIndex].transform.position, transform.position) < 1 && found==false)
            {
                found = true;
                ArrivedAtLocation();
            }
        }
    }


    void FixedUpdate()
    {
        if (countdown > 0) { 
        countdown--;
        if (countdown % 50 == 0) {
                Points();
        }
        if (countdown == 0)
            {
                MoveToNext();
            }
        }
    }

    void MoveTo (Vector3 targetLocation)
    {
        //this.GetComponentInChildren<Animator>().enabled = true;
        anim.speed = 1f;
        this.GetComponent<NavMeshAgent>().SetDestination(targetLocation);
        this.transform.forward = targetLocation;

    }

    void MoveToNext()
    {
        pathIndex++;
        found = false;
        if (targets.Length > pathIndex) { 
        MoveTo(targets[pathIndex].transform.position);
        TarWaypoint = (Wapoint)targets[pathIndex].GetComponent(typeof(Wapoint));
        TarObject = (InteractableObject)TarWaypoint.GetTarget().GetComponent(typeof(InteractableObject));


        }
        else
        {
            TarWaypoint = null;
        }
    }


    void ArrivedAtLocation()
    {
        anim.speed = 0f;
        //anim.Play("mixamo_com", 0, 16/31);
        countdown = waitTimes[pathIndex] * 50 + 10;
    }

    public GameObject GetCurrentGO()
    {
        if (targets.Length > pathIndex)
        {
            return TarWaypoint.GetTarget();

        }
        else
        {
            return null;
        }
    }

    void Points()
    {
        if (TarObject.GetState())
        {
            score.AddScore(TarWaypoint.GetPointsToGive());
        }
        /* //Pisteiden menetys poistettu liaallisen vaikeuden takia
        else
        {
            score.LoseScore(TarWaypoint.GetPointsToGive()/2);
        }
        */
    }

    bool TargetState()
    {
        return TarObject.GetState();
    }
}
