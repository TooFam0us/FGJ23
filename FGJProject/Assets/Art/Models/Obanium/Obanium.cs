using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obanium : MonoBehaviour
{
    public GameObject OBAMA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OBAMA.transform.Rotate(Vector3.up * (100 * Time.deltaTime));
    }
}
