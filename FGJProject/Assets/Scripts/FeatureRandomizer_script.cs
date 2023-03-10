using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FeatureRandomizer_script : MonoBehaviour
{

    public List<Mesh> HairStyle_List=new List<Mesh>();
    public List<Material> ColorMaterial_List=new List<Material>();
    public List<Material> SkinColors_List=new List<Material>();


   // hair color, skiun color, eyecolor 

    int[] playerRandomIndexes = new int[3];
    int[] DadRandomIndexes = new int[3];
    int[] MomRandomIndexes = new int[3];

    private Coroutine koorutiini;



    public GameObject player;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("feature start");

        /* Fetch all resources from their appropriate foldersi

        PopulateMaterialColorList();
        PopulateHairMeshList();
        PopulateSkinColorList();
        */
        
        //set players features and save the indexes
        GeneratePlayerFeatures();
    }

    void Update() {
    }

    public void reset_player_pos(){
        Debug.Log("next lev");
        Vector3 startpos=new Vector3(9.7f,-1.7f,-1.0f);
        player.transform.position = startpos;
        player.transform.rotation = Quaternion.identity;
        koorutiini = StartCoroutine(ExecuteAfterTime(0.2f));

        //9.7,-1.7,-1
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        player.GetComponent<Chill_charactercontroler>().GM.gameEnded = false;
        StopCoroutine(koorutiini);
    }


    /*this sets the players features and saves the indexes. THIS NEEDS TO BE CALLED BEFORE MAKING PARENTS OR NPC'S*/
    public void GeneratePlayerFeatures(){
        //set player features. save the index of these features and use them later

        Mesh playerHairmesh = HairStyle_List[Random.Range(0, HairStyle_List.Count)];

        playerRandomIndexes[0] = Random.Range(0,ColorMaterial_List.Count);
        Material HairColor= ColorMaterial_List[playerRandomIndexes[0]];

        playerRandomIndexes[1] = Random.Range(0,SkinColors_List.Count);
        Material skincol=SkinColors_List[playerRandomIndexes[1]];

        playerRandomIndexes[2] = Random.Range(0,ColorMaterial_List.Count);
        Material eyeColor= ColorMaterial_List[playerRandomIndexes[2]];
        

        player.GetComponent<Feature_script>().SetFeatures(playerHairmesh,HairColor,eyeColor,skincol,false,true);
        player.GetComponent<Feature_script>() .SetClotheCols(GetRandomColor(),GetRandomColor(),GetRandomColor() );
    }




    //copied get random fns
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




    //todo. make it avoid players setted features
    //thhis needs to be implemented in the get random x thing
    //or in this fn to check if hair is same as hairindex etc some checkoup fn

    //this is a function ment to set npc functions
    public void RandomizeFeaturesOfGo(GameObject go){
        Feature_script feature=go.GetComponent<Feature_script>();
        if (feature==null){
            Debug.Log("Gameobject given to feature randomizer does not contain the feature_script component");
        }else{
            //randomize the features of go
            feature.SetFeatures(GetRandomHair(),GetRandomColor(),GetRandomColor(),GetRandomSkinCol(),false, false);
            feature.SetClotheCols(GetRandomColor(),GetRandomColor(),GetRandomColor());
        }
    }

    


    //helper fn
    bool randomBool(){
        return Random.value>0.5;
    }


    public void SetFeaturesOfParents(GameObject parent1, GameObject parent2){
        Debug.Log("Parents");
        // inheritable features features, hair color, skin color, eye color, :height:
        Feature_script father= parent1.GetComponent<Feature_script>();
        Feature_script mother= parent2.GetComponent<Feature_script>();

        Material PlayersHair= ColorMaterial_List[playerRandomIndexes[0]];
        Material PLayersSkin= SkinColors_List[playerRandomIndexes[1]];
        Material PlayersEye= ColorMaterial_List[playerRandomIndexes[2]];


        //first make index set it, then get a mat from the index, reset it if parent gets the players hair
        //parents hair and skin are random at first but then they are set to the players if the parent gets a good roll

        DadRandomIndexes[0] = Random.Range(0,ColorMaterial_List.Count);
        DadRandomIndexes[1] = Random.Range(0,SkinColors_List.Count);

        MomRandomIndexes[0] = Random.Range(0,ColorMaterial_List.Count);
        MomRandomIndexes[1] = Random.Range(0,SkinColors_List.Count);

        Material FathersHair = ColorMaterial_List[DadRandomIndexes[0]];
        Material MothersHair = ColorMaterial_List[MomRandomIndexes[0]];

        Material FathersSkin = SkinColors_List[DadRandomIndexes[1]];
        Material MothersSkin= SkinColors_List[MomRandomIndexes[1]];


        Material FatherEye = ColorMaterial_List[DadRandomIndexes[2]];
        Material MotherEye= ColorMaterial_List[MomRandomIndexes[2]];




        if (father==null || mother==null) {
            Debug.Log("father or mother does not have the featurescript componentr");
        }else{
            //determine wich features go to which parent
            bool[] inheritables={randomBool(),randomBool(),randomBool()};//true means it goes to the father
            //in this order - hair color, skin color, eye color

            //hyvin likaista ja itse????n toistavaa

            //checks if father has the same feature as the player
            if (inheritables[0]){
                FathersHair=PlayersHair;
                DadRandomIndexes[0] =playerRandomIndexes[0] ;
            }else{
                MothersHair=PlayersHair;
                MomRandomIndexes[0] =playerRandomIndexes[0] ;
            }

            if (inheritables[1]){
                FathersSkin=PLayersSkin;
                DadRandomIndexes[1] =playerRandomIndexes[1] ;
            }else{
                MothersSkin=PLayersSkin;
                MomRandomIndexes[1] =playerRandomIndexes[1] ;
            }

            if (inheritables[2]){
                FatherEye=PlayersEye;
                DadRandomIndexes[2] =playerRandomIndexes[2] ;
            }else{
                MotherEye=PlayersEye;
                MomRandomIndexes[2] =playerRandomIndexes[2] ;
            }




            father.SetFeatures(GetRandomHair(),FathersHair,FatherEye,FathersSkin,true,false);
            father.SetClotheCols(GetRandomColor(),GetRandomColor(),GetRandomColor() );

            mother.SetFeatures(GetRandomHair(),MothersHair,MotherEye,MothersSkin,true,false);
            mother.SetClotheCols(GetRandomColor(),GetRandomColor(),GetRandomColor() );


        }

    }





}
