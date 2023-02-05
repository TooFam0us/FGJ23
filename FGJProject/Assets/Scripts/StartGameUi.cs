using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUi : MonoBehaviour
{
    GameObject manager;

    void Start() {
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
    }

    public void ExitGame(){ 
        Application.Quit();
    }

    public void StartGame(){
        //code
        //start from lev0
        Application.LoadLevel("TestScene");
        closeUi();
    }

    void closeUi(){
        //lock mouse

        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        Destroy(gameObject);
    }


}
