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
    int i = 0;

    public Score score;

    private Animator anim;
    void Start() {
        anim = GetComponentInChildren<Animator>();
        // Grab hold of the agents NavMeshAgent
        MoveToRandom();
    }

    void Update()
    {
        if (targets.Length > pathIndex) 
        { 
        if(Vector3.Distance(targets[i].transform.position, transform.position) < 1 && found==false)
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
        if (countdown == 0)
            {
                MoveToRandom();
            }
        }
    }

    void MoveTo (Vector3 targetLocation)
    {
        this.GetComponentInChildren<Animator>().enabled = true;
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
    void MoveToRandom()
    {
        found = false;
        Randomize();
        MoveTo(targets[i].transform.position);
        TarWaypoint = (Wapoint)targets[i].GetComponent(typeof(Wapoint));
        TarObject = (InteractableObject)TarWaypoint.GetTarget().GetComponent(typeof(InteractableObject));
    }

    void Randomize()
    {
        i = UnityEngine.Random.Range(0, targets.Length);
        //Debug.Log(i.ToString());
    }
    void ArrivedAtLocation()
    {
        anim.speed = 0f;
        anim.Play("mixamo_com", 0, 16/31);
        countdown = waitTimes[i] * 50 + 10;
        countdown = UnityEngine.Random.Range(60, 300); ;
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

    bool TargetState()
    {
        return TarObject.GetState();
    }
}
