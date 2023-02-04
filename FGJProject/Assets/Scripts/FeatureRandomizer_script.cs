using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FeatureRandomizer_script : MonoBehaviour
{

    List<Mesh> HairStyle_List=new List<Mesh>();

    //list of hair meshes
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

        PopulateHairMeshList();
        //gib player hair  color 
        player.GetComponent<Feature_script>().SetFeatures(GetRandomHair(),GetMaterialFromColorEnum(Color_enum.Green),null,null,false);
        
    }




    void PopulateHairMeshList(){

        //hyvin likaista, hyvin epätehokasta
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
        Debug.Log(max);
        return HairStyle_List[Random.Range(0,max)] ;
    }


    Material GetMatByName(string name){

        //hyvin likaista, hyvin epätehokasta
        Material[] matarr={null};
        string[] guids = AssetDatabase.FindAssets( name,new string[]{"Assets/Materials/FeatureColorMaterials"});

        foreach( var guid in guids ) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            Material mat = AssetDatabase.LoadAssetAtPath<Material>( path );
            matarr[0]=mat;
        }
        return matarr[0];
    }

    /* helper fn to fet matarial from color enum*/
    Material GetMaterialFromColorEnum(Color_enum color){


        switch (color) {
            case Color_enum.Green:
                Debug.Log("green");
                return GetMatByName("GreenFeature");

            case Color_enum.Red:
                Debug.Log("red");
                return GetMatByName("RedFeature");

            case Color_enum.Blue:
                Debug.Log("blue");
                return GetMatByName("BlueFeature");

            case Color_enum.Blonde:
                Debug.Log("blone");
                return GetMatByName("BlondeFeature");
            
            case Color_enum.Yellow:
                Debug.Log("yellow");
                return GetMatByName("YellowFeature");
            
            default:
                return null;
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
