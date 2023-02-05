using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBallRotatro : MonoBehaviour
{
    float rotatingSpeed = 1;
    bool rotateForward = false;
    // Start is called before the first frame update
    void Start()
    {
        rotatingSpeed = Random.Range(25, 50);
        rotateForward = Random.Range(0, 100) > 49 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, rotateForward ? transform.forward : -transform.forward, Time.deltaTime * rotatingSpeed);
    }
}
