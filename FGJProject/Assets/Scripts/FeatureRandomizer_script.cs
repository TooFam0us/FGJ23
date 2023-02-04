using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FeatureRandomizer_script : MonoBehaviour
{

    List<Mesh> HairStyle_List=new List<Mesh>();
    List<Material> ColorMaterial_List=new List<Material>();
    List<Material> SkinColors_List=new List<Material>();

    

    //what hair the player has as an index from the hairstyle list
    int playersHairMeshIndex;

    //what hair color the player has as an index from the colormaterial list
    int playersHairColorIndex;

    //what skin color the player has as an index from the skincolor list
    int playersSkinColorIndex;


    //list of eyecols
    //list of skincols
    //list of cols in generall i guess

    //ref to player
    //set players things on startup mab using the material

    //get random height
    //set boundaries for what you cannot have as a hair style or color



    //save players feature indexes somewhere so we can later use them for when we want to limit random spawning
    //generate parents



    public GameObject player;

    // Start is called before the first frame update
    void Start() {

        PopulateMaterialColorList();
        PopulateHairMeshList();
        PopulateSkinColorList();
        //gib player hair  color 
        GeneratePlayerFeatures();
        
    }



    void GeneratePlayerFeatures(){
        //set player features. save the index of these features and use them later

        playersHairMeshIndex = Random.Range(0,HairStyle_List.Count);
        Mesh playerHairmesh = HairStyle_List[playersHairMeshIndex];

        playersHairColorIndex = Random.Range(0,ColorMaterial_List.Count);
        Material HairColor= ColorMaterial_List[playersHairColorIndex];

        playersSkinColorIndex = Random.Range(0,SkinColors_List.Count);
        Material skincol=SkinColors_List[playersSkinColorIndex];

        player.GetComponent<Feature_script>().SetFeatures(playerHairmesh,HairColor,null,skincol,false);
        player.GetComponent<Feature_script>() .SetClotheCols(GetRandomColor(),GetRandomColor(),GetRandomColor() );
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

    Material GetRandomSkinCol(){
        int max = SkinColors_List.Count; 
        return SkinColors_List[Random.Range(0,max)] ;
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

    void PopulateSkinColorList(){

        //hyvin likaista, hyvin epätehokasta
        string[] guids = AssetDatabase.FindAssets( "t:Material",new string[]{"Assets/Materials/SkinColors"});

        foreach( var guid in guids ) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            Material mat = AssetDatabase.LoadAssetAtPath<Material>( path );
            SkinColors_List.Add(mat);
        }
    }


    //todo. make it avoid players setted features
    //thhis needs to be implemented in the get random x thing
    public void RandomizeFeaturesOfGo(GameObject go){
        Feature_script feature=go.GetComponent<Feature_script>();
        if (feature==null){
            Debug.Log("Gameobject given to feature randomizer does not contain the feature_script component");
        }else{
            //randomize the features of go
            feature.SetFeatures(GetRandomHair(),GetRandomColor(),null,null,false);

        }
    }





}
