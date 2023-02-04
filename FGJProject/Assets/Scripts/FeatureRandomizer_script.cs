using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FeatureRandomizer_script : MonoBehaviour
{

    List<Mesh> HairStyle_List=new List<Mesh>();
    List<Material> ColorMaterial_List=new List<Material>();

    //list of eyecols
    //list of skincols
    //list of cols in generall i guess

    //ref to player
    //set players things on startup mab using the material

    //get random color
    //get random hair style
    //get random height
    //set boundaries for what you cannot have as a hair style or color


    public GameObject player;

    // Start is called before the first frame update
    void Start() {

        PopulateMaterialColorList();
        PopulateHairMeshList();
        //gib player hair  color 
        player.GetComponent<Feature_script>().SetFeatures(GetRandomHair(),GetRandomColor(),null,null,false);
        
    }




    void PopulateHairMeshList(){

        //hyvin likaista, hyvin epätehokasta kopioitusa
        string[] guids = AssetDatabase.FindAssets( "t:Mesh",new string[]{"Assets/Art/Models/Character/Hair"});
        //string[] guids = AssetDatabase.FindAssets("hamehair" );

        foreach( var guid in guids ) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            Mesh me = AssetDatabase.LoadAssetAtPath<Mesh>( path );
            HairStyle_List.Add(me);
        }
    }


    Mesh GetRandomHair(){
        int max = HairStyle_List.Count; 
        return HairStyle_List[Random.Range(0,max)] ;
    }

    Material GetRandomColor(){
        int max = ColorMaterial_List.Count; 
        return ColorMaterial_List[Random.Range(0,max)] ;
    }


    void PopulateMaterialColorList(){

        //hyvin likaista, hyvin epätehokasta
        string[] guids = AssetDatabase.FindAssets( "t:Material",new string[]{"Assets/Materials/FeatureColorMaterials"});

        foreach( var guid in guids ) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            Material mat = AssetDatabase.LoadAssetAtPath<Material>( path );
            ColorMaterial_List.Add(mat);
        }
    }



    void RandomizeFeaturesOfGo(GameObject go){
        Feature_script feature=go.GetComponent<Feature_script>();
        if (feature==null){
            Debug.Log("Gameobject given to feature randomizer does not contain the feature_script component");
        }else{
            //randomize the features of go


        }
    }





}
