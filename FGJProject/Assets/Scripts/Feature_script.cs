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

    //this is the go that holds the hair mesh
    GameObject HairObject;

    Material HairColor; 

    //unimplemented
    Material EyeColor; 

    Material SkinColor; 

    //unimplemented
    float Height;


    



    /*sets characters features and spawns meshes as children*/
    public void SetFeatures(Mesh hair_mesh, Material hair_color, Material eye_color, Material skin_color, bool is_parent ){
        HairStyle=hair_mesh;
        HairColor=hair_color;
        EyeColor=eye_color;
        SkinColor=skin_color;
        IsParent=is_parent;
        
        ChancePlayerskin();

        SpawnFeatures();
    }


    //set uninheritables
    public void SetClotheCols(Material shirt,Material pants, Material shoe){
        changeCharacterMeshMaterial(0,shirt);
        changeCharacterMeshMaterial(1,pants);
        changeCharacterMeshMaterial(2,shoe);

    }



    /* spawn meshes as children. changes the mesh if it is allready spawned */
    void SpawnFeatures(){

        if(HairStyle!=null){
            if (HairObject==null){
                //spawn it set it as a child
                HairObject= Instantiate(TestInstantiate,gameObject.transform.position,Quaternion.identity);
                HairObject.transform.parent=gameObject.transform;

                //vaihda thingin mesh johonkin meshiin mikä sille annetaan
                HairObject.GetComponent<MeshFilter>().mesh=HairStyle;

                //localscale pitää olla sama kuin pelaajha meshillä
                HairObject.transform.localScale=new Vector3(50,50,50);

                HairObject.GetComponent<Renderer>().material=HairColor;

                //x pitää olla -90 
                HairObject.transform.Rotate(-90,0,0);
            }else {
                HairObject.GetComponent<MeshFilter>().mesh=HairStyle;
            }

        }else{
            Debug.Log("tried to spawn hair. but hairstyle is null");;
        }


    }

    void ChancePlayerskin() {
        changeCharacterMeshMaterial(3,SkinColor);
        //changeCharacterMeshMaterial(7,EyeColor);
    }


    //change material at index for the player mesh
    void changeCharacterMeshMaterial(int index,Material newMat){
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();

        //look at index 1 since index  0 is camera
        Material[] mats =children[1].materials;
        mats[index]=newMat;
        children[1].materials=mats;

    }




    void Start() {
        //generate random shirt color
        //and other stuff that is not inherritable 
        
    }

    void Update() {
        
    }



}
