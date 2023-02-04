using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_script : MonoBehaviour
{

    int SecondsRemaining=60;
    //level * 2 min or somethia

    [SerializeField]
    Text Timer_txt;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Timetick());
    }



    IEnumerator Timetick(){
        while(true){
            SecondsRemaining--;

            if (SecondsRemaining==0){ 
                EndGame(); 
            }

            Timer_txt.text=SecondsRemaining.ToString();
            yield return new WaitForSeconds(1) ;
        }
    }

    public void EndGame(){
        Debug.Log("game has been ended");
    }



}
