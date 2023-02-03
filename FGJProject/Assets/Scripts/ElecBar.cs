using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ElecBar : MonoBehaviour
{

    public PlayerController PlayerCont;
    private float elecU;
    private float elecM;

    [SerializeField] GameObject[] Bars;
    [SerializeField] GameObject text;
    [SerializeField] GameObject alert;



    // Update is called once per frame

    
    IEnumerator Alert()
    {
        alert.SetActive(true);
        yield return new WaitForSeconds(3);
        alert.SetActive(false);

    }
    void Update()
    {
        elecU = PlayerCont.CurrentUsedElectricity;
        text.GetComponent<TextMeshProUGUI>().text = elecU.ToString();

       
        if (elecU < 20)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(false);
            Bars[2].SetActive(false);
            Bars[3].SetActive(false);
            Bars[4].SetActive(false);
            Bars[5].SetActive(false);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);
        }
        if (elecU >= 20)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(false);
            Bars[3].SetActive(false);
            Bars[4].SetActive(false);
            Bars[5].SetActive(false);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);
        }
        if (elecU >= 30)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(false);
            Bars[4].SetActive(false);
            Bars[5].SetActive(false);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 40)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(false);
            Bars[5].SetActive(false);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 50)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(true);
            Bars[5].SetActive(false);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 60)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(true);
            Bars[5].SetActive(true);
            Bars[6].SetActive(false);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 70)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(true);
            Bars[5].SetActive(true);
            Bars[6].SetActive(true);
            Bars[7].SetActive(false);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 80)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(true);
            Bars[5].SetActive(true);
            Bars[6].SetActive(true);
            Bars[7].SetActive(true);
            Bars[8].SetActive(false);
            Bars[9].SetActive(false);

        }
        if (elecU >= 90)
        {
            Bars[0].SetActive(true);
            Bars[1].SetActive(true);
            Bars[2].SetActive(true);
            Bars[3].SetActive(true);
            Bars[4].SetActive(true);
            Bars[5].SetActive(true);
            Bars[6].SetActive(true);
            Bars[7].SetActive(true);
            Bars[8].SetActive(true);
            Bars[9].SetActive(false);

        }
        if (elecU >= 100)
        {
            foreach (GameObject n in Bars)
            {
                n.SetActive(true);
                
            }

        }
        if(elecU > 100)
        {
            StartCoroutine(Alert());

        }
    }
    
}
