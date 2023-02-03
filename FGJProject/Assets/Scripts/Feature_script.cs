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

    public Mesh HairStyle; 

    Color_enum HairColor; 

    float Height;


    void Start() {
        GameObject thing = Instantiate(TestInstantiate,gameObject.transform.position,Quaternion.identity);
        thing.transform.parent=gameObject.transform;
        //vaihda thingin mesh johonkin meshiin mikä sille annetaan
        thing.GetComponent<MeshFilter>().mesh=HairStyle;
        //localscale pitää olla sama kuin pelaajha meshillä
        thing.transform.localScale=new Vector3(50,50,50);
        //x pitää olla -90 
        thing.transform.Rotate(-90,0,0);

        
    }

    void Update() {
        
    }
}
