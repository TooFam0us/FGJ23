using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxX = 20f;
    public float maxZ = 20f;
    public float minX = -20f;
    public float minZ = -20f;

    public GameObject player;
    Vector3 movement;
    public int maxiumElectricity = 1000;
    public int CurrentUsedElectricity = 0;

    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 nextMovement = player.transform.position + movement * moveSpeed;
        if (nextMovement.x < maxX && nextMovement.z < maxZ && nextMovement.x > minX && nextMovement.z > minZ)
        { 
        player.transform.position = nextMovement;
        }
    }
    public int GetMaxEle()
    {
        return maxiumElectricity;
    }
    public int GetUsedEle()
    {
        return CurrentUsedElectricity;
    }

    public void AddUsed(int value)
    {
        CurrentUsedElectricity = CurrentUsedElectricity + value;
        if(CurrentUsedElectricity > maxiumElectricity)
        {
            ShutDownAll();
        }
    }
    public void RemoveUsed(int value)
    {
        CurrentUsedElectricity = CurrentUsedElectricity - value;
    }






    void ShutDownAll()
    {
        print("Shutting it down");
        InteractableObject[] ScriptArray = FindObjectsOfType(typeof(InteractableObject)) as InteractableObject[];
        foreach (InteractableObject yourScriptName in ScriptArray)
        {
            yourScriptName.CrashOff();
        }
        CurrentUsedElectricity = 0;
    }
}
