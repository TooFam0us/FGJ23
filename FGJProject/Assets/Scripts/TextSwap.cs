using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TextSwap : MonoBehaviour
{
    public GameObject MyNpc;
    private AIControl AiCont;
    private MeshFilter yourMesh;

    public TextMeshPro MyText;
    // Start is called before the first frame update
    void Start()
    {
        MyNpc = transform.parent.gameObject;
        AiCont = (AIControl)MyNpc.GetComponent(typeof(AIControl));
        MyText = GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        if (AiCont.GetCurrentGO() != null)
        {
            MyText.SetText(AiCont.GetCurrentGO().name);
        }
        else
        {
            MyText.SetText("");
        }
    }
}
