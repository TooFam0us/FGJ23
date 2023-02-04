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
        setTime();
        StartCoroutine(Timetick());
    }

    public void setTime(){
        SecondsRemaining= GameObject.Find("manager").GetComponent<GameManager_script>().CurrentLevel*60;

    }



    IEnumerator Timetick(){
        while(true){
            SecondsRemaining--;

            if (SecondsRemaining==0){ 
                EndGame(); 
            }

            int minute=SecondsRemaining/60;
            int second=SecondsRemaining-minute*60;
            Timer_txt.text=string.Format("{0}:{1:00}",minute,second);
            yield return new WaitForSeconds(1) ;
        }
    }

    public void EndGame(){
        Debug.Log("game has been ended");
        GameObject.Find("manager").GetComponent<GameManager_script>().EndOfLevel(false);
    }



}
