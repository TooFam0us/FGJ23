using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam);
        this.transform.Rotate(0, 180, 0);  //Used For Text
        //this.transform.Rotate(100, 0, 0); //Used for image

    }
}
