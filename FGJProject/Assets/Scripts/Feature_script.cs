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

    Material HairColor; 

    //unimplemented
    Material EyeColor; 

    //unimplemented
    Material SkinColor; 

    //unimplemented
    float Height;


    //not inherritted stuff 
    Material Shirt_color;

    



    /*sets characters features and spawns meshes as children*/
    public void SetFeatures(Mesh hair_mesh, Material hair_color, Material eye_color, Material skin_color, bool is_parent ){
        HairStyle=hair_mesh;
        HairColor=hair_color;
        EyeColor=eye_color;
        SkinColor=skin_color;
        IsParent=is_parent;


        SpawnFeatures();
    }

    //debug function
    public void setCol(Material hair){
        HairColor=hair;
        SpawnFeatures();
    }



    /* spawn meshes as children */
    void SpawnFeatures(){
        if(HairStyle!=null){

        GameObject thing = Instantiate(TestInstantiate,gameObject.transform.position,Quaternion.identity);
        thing.transform.parent=gameObject.transform;

        //vaihda thingin mesh johonkin meshiin mikä sille annetaan
        thing.GetComponent<MeshFilter>().mesh=HairStyle;

        //localscale pitää olla sama kuin pelaajha meshillä
        thing.transform.localScale=new Vector3(50,50,50);

        thing.GetComponent<Renderer>().material=HairColor;

        //x pitää olla -90 
        thing.transform.Rotate(-90,0,0);
        }else{
            Debug.Log("tried to spawn hair. but hairstyle is null");;
        }




    }




    void Start() {
        //generate random shirt color
        //and other stuff that is not inherritable 
        
    }

    void Update() {
        
    }



}
