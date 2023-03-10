using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameManager_script : MonoBehaviour
{

    //set player features
    //spawn players parents and set their features
    //spawn random npc's
    public int CurrentLevel = 0;
    public GameObject npcPrefab;
    private List<GameObject> Rooms= new List<GameObject>();
    public GameObject[] RoomTypes;
    private List<GameObject> Npcs;
    // Start is called before the first frame update
    private bool firstParentFound = false;

    public GameObject EndPiece;

    [SerializeField]
    GameObject endOfGamePrefab;

    GameObject Timer;

    int quessAttemptsPerLevel=5;
    public int quessAttempsRemaining=5;

    public bool gameEnded = false;

    void Start()
    {
        Debug.Log("gamemanager start");
        Timer=GameObject.Find("TimerUi");
        //RoomTypes = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/PivotedRooms" });
        Npcs = new List<GameObject>();

        GenerateLevel();
        //SpawnNpc();
        makeParents();
        Timer.GetComponent<Timer_script>().setAttempts(quessAttempsRemaining);


    }


    void DestroyAllRooms(){
        for (int i = 0; i < Rooms.Count; i++) {
            Destroy(Rooms[i]);
        }
    }

    void DestroyAllNpc(){
        for (int i = 0; i < Npcs.Count; i++) {
            Destroy(Npcs[i]);
        }
        Npcs = new List<GameObject>();
    }

    //player gives incorrect quess
    public void IncorrectQuess(){
        quessAttempsRemaining--;
        Timer.GetComponent<Timer_script>().setAttempts(quessAttempsRemaining);
        if (quessAttempsRemaining==0){
            EndOfLevel(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        Debug.Log("next lev");
        quessAttempsRemaining=quessAttemptsPerLevel;
        Timer.GetComponent<Timer_script>().setAttempts(quessAttempsRemaining);
        DestroyAllRooms();
        DestroyAllNpc();
        CurrentLevel++;
        Timer.GetComponent<Timer_script>().setTime();
        GenerateLevel();
        GetComponent<FeatureRandomizer_script>().reset_player_pos();
        makeParents();
    }

    void GenerateLevel()
    {
        //spawnais roomeja suhteutettuna level tasoon
        //Instantiate(RoomTypes[0], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        for (int i = 0; i < CurrentLevel; i++)
        {
            SpawnNpc(GenerateRoom(new Vector3(-42.34766f * i, 0, 0), new Quaternion(0, 0, 0, 0)));
            SpawnNpc(GenerateRoom(new Vector3(-42.34766f * i, 0, 0), new Quaternion(0, 180, 0, 0)));
        }
        EndPiece.transform.position = new Vector3(-42.34766f * CurrentLevel + 25, 0, 0);
    }

    void SpawnNpc(GameObject room)
    {
        Debug.Log(room.transform.position);
        Transform[] allChildren = room.GetComponentsInChildren<Transform>();
        GameObject[] Waypoints = new GameObject[allChildren.Length];
        int i = 0;
        foreach (Transform child in allChildren)
        {
            if (child.tag == "Waypoint")
            {
                Waypoints[i]=child.gameObject;
            }
            i++;
        }
        int xd = 0;
        foreach (GameObject GME in Waypoints)
        {
            if(GME != null)
            {
                xd++;
            }
        }
        int z = 0;
        GameObject[] Waypoints2 = new GameObject[xd];
        foreach (GameObject GME2 in Waypoints)
        {
            if (GME2 != null)
            {
                Waypoints2[z]=GME2.gameObject;
                z++;
            }
        }
        Waypoints = Waypoints2;
        //Debug.Log(Waypoints[Random.Range(0, Waypoints.Length - 1)].transform.position);
        foreach (GameObject waypoint in Waypoints)
        {
            if (Random.value > 0.5f)
            {
                GameObject NPC = Instantiate(npcPrefab, waypoint.transform.position, new Quaternion(0, 0, 0, 0));
                NPC.GetComponent<AIControl>().targets = Waypoints;
                GetComponent<FeatureRandomizer_script>().RandomizeFeaturesOfGo(NPC); 
                Npcs.Add(NPC);
            }

        }



    }
    GameObject GenerateRoom(Vector3 loc, Quaternion rot)
    {
        //spawnais roomeja suhteutettuna level tasoon
        //Instantiate(RoomTypes[0], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        /*
        var path = AssetDatabase.GUIDToAssetPath(RoomTypes[Random.Range(0, RoomTypes.Length)]);
        GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        GameObject CreatedRoom = Instantiate(go, loc, rot);
        */
        GameObject go = RoomTypes[Random.Range(0, RoomTypes.Length)];

        GameObject CreatedRoom = Instantiate(go, loc, rot);

        Rooms.Add(CreatedRoom);
return CreatedRoom;
}

void makeParents()
{
GetComponent<FeatureRandomizer_script>().SetFeaturesOfParents(Npcs[Random.Range(0, Npcs.Count - 1)], Npcs[Random.Range(0, Npcs.Count - 1)]);
}

public void ParentFound()
{
if (firstParentFound)
{
    EndOfLevel(true);
    firstParentFound = false;
}
else
{
    firstParentFound = true;
}
}
public void EndOfLevel(bool won) {
gameEnded = true;
GameObject endofgame_screen= Instantiate(endOfGamePrefab,transform.position, Quaternion.identity);
endofgame_screen.GetComponent<EndGameUiUtils_script>().IsWin=won;
endofgame_screen.GetComponent<EndGameUiUtils_script>().SetGameStateInfo();
GetComponent<FeatureRandomizer_script>().GeneratePlayerFeatures();

}
}
