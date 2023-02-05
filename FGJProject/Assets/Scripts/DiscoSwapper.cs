using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoSwapper : MonoBehaviour
{
    private MeshFilter yourMesh;
    public Material[] Mats;
    public Material kulli;
    public Material kulli2;
    public Material kulli3;

    // Start is called before the first frame update
    void Start()
    {
        yourMesh = gameObject.GetComponent<MeshFilter>();
        StartCoroutine(ExecuteAfterTime(0.5f));

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        ChangeMaterial();
        StartCoroutine(ExecuteAfterTime(0.5f));
    }
    void ChangeMaterial()
    {
        Renderer rend = GetComponent<Renderer>();
        Shuffle();
        rend.materials = Mats;
    }
    void Shuffle()
    {
        kulli = Mats[0];
        for (int i = 0;i < Mats.Length-1;i++) {
            if (i==3)
            {
                kulli3 = Mats[3];
                Mats[i] = Mats[i+2];

            }
            else if (i==4)
            {
                Mats[4] = kulli2;
            }
            else
            {
                Mats[i] = Mats[i + 1];
            }
        }
        Mats[Mats.Length - 1] = kulli;
    }
}
