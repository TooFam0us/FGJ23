using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUiUtils_script : MonoBehaviour
{
    [SerializeField] 
    Text score_txt;

    [SerializeField] 
    Text HeroText;

    [SerializeField] 
    Text buttons_text;

    GameObject manager;

    public bool IsWin;


    void Start() {
        manager=GameObject.Find("manager");
        updateScoreTxt();
        
    }


    void updateScoreTxt(){
        int score = manager.GetComponent<GameManager_script>().CurrentLevel;
        score_txt.text=string.Format("Score:{0}",score);
    }

    //tells if you lost or won
    void SetGameStateInfo(){
        if(IsWin){
            HeroText.text = "Level Passed!";
            buttons_text.text="Next Level!"; 
        }else{
            HeroText.text = "Game Over!" ;
            buttons_text.text="Retry Game!"; 
        }

    }



    public void ExitGame(){ 
        Application.Quit();
    }

    public void replayButton(){
        if(IsWin){
            NextLevel();
        }else{
            RestartGame();
        }
    }

    public void RestartGame(){
        //code
        //start from lev0

        closeUi();
    }

    public void NextLevel(){
        //code
        //start from next level

        closeUi();
    }


    void closeUi(){
        //unlock mouse

        Destroy(gameObject);
    }


}
