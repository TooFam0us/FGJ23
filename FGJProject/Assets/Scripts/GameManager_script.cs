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
    private GameObject[] Rooms;
    string[] RoomTypes;

    // Start is called before the first frame update
    void Start()
    {
        RoomTypes = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Rooms" });

        GenerateLevel();
        //SpawnNpc();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel()
    {
        CurrentLevel++;
        GenerateLevel();
    }
    void GenerateLevel()
    {
        //spawnais roomeja suhteutettuna level tasoon
        //Instantiate(RoomTypes[0], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        SpawnNpc(GenerateRoom(new Vector3(0, 0, 0)));
        SpawnNpc(GenerateRoom(new Vector3(50, 0, 0)));
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
        GameObject NPC =Instantiate(npcPrefab, Waypoints[Random.Range(0, Waypoints.Length - 1)].transform.position, new Quaternion(0, 0, 0, 0));
        NPC.GetComponent<AIControl>().targets = Waypoints;


    }
    GameObject GenerateRoom(Vector3 loc)
    {
        //spawnais roomeja suhteutettuna level tasoon
        //Instantiate(RoomTypes[0], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        var path = AssetDatabase.GUIDToAssetPath(RoomTypes[Random.Range(0, RoomTypes.Length)]);
        GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        GameObject CreatedRoom = Instantiate(go, loc, new Quaternion(0, 0, 0, 0));
        return CreatedRoom;
    }
}
