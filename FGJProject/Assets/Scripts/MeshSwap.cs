using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MeshSwap : MonoBehaviour
{
    public GameObject MyNpc;
    private AIControl AiCont;
    private GameObject Target;
    private MeshFilter yourMesh;

    public Material previewmat;

    // Start is called before the first frame update
    void Start()
    {
        yourMesh = gameObject.GetComponent<MeshFilter>();
        MyNpc = transform.parent.gameObject;
        AiCont = (AIControl)MyNpc.GetComponent(typeof(AIControl));
        //Target = AiCont.GetCurrentGO();
    }



    // Update is called once per frame
    void Update()
    {
        if (AiCont.GetCurrentGO() != null) { 
        MeshFilter viewedModelFilter = AiCont.GetCurrentGO().GetComponent<MeshFilter>();
        yourMesh.mesh = viewedModelFilter.mesh;
        }
    }

    void ChangeMaterial(Material newMat)
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }
}
