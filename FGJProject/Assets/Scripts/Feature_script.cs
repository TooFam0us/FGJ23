using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature_script : MonoBehaviour {

    //has data on what hair is on this character what color it is
    //also knows if this is one of the parents

    public bool IsParent;

    //incase we need this 
    bool IsMale;

    public GameObject TestInstantiate;

    Mesh HairStyle; 

    Color_enum HairColor; 

    float Height;


    void Start() {
        GameObject thing = Instantiate(TestInstantiate,gameObject.transform.position,Quaternion.identity);
        thing.transform.parent=gameObject.transform;

        
    }

    void Update() {
        
    }
}
