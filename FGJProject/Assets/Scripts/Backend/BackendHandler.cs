using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Net;
using System.Text;
using System;

public class BackendHandler : MonoBehaviour
{
    private int fetchCounter = 0;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI scoreInput;
    public TextMeshProUGUI highScoresTextArea;
    private bool updateHighScoreTextArea = false;
    const string jsonTestStr = "{ " +
    "\"scores\":[ " +
    "{\"id\":1, \"playername\":\"Matti\", \"score\":20, \"playtime\": \"2020-21-11 08:20:00\"}, " +
    "{\"id\":2, \"playername\":\"Hankka\", \"score\":30, \"playtime\": \"2020-21-11 08:20:00\"}, " +
    "{\"id\":3, \"playername\":\"Ismo\", \"score\":40, \"playtime\": \"2020-21-11 08:20:00\"} " +
    "] }";

    const string urlBackendHighScores = "http://172.30.139.152/highscores.php"; //Niklas Server

    // vars
    HighScores.HighScores hs;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (updateHighScoreTextArea)
        {
            highScoresTextArea.text = CreateHighScoresList();
            updateHighScoreTextArea = false;
        }
    }

    string CreateHighScoresList()
    {
        string hsList = "";

        if(hs != null)
        {
            int len = (hs.scores.Length < 3) ? hs.scores.Length : 3;
            for(int i = 0; i < len; i++)
            {
                hsList += string.Format("[ {0} ] {1,15} {2,5} {3,15}\n",
                    (i + 1), hs.scores[i].playername, hs.scores[i].score, hs.scores[i].playtime);
            }
        }

        return hsList;
    }
    string CreateHighScoresListLONG()
    {
        string hsList = "";

        if (hs != null)
        {
            int len = hs.scores.Length;
            for (int i = 0; i < len; i++)
            {
                hsList += string.Format("[ {0} ] {1,15} {2,5} {3,15}\n",
                    (i + 1), hs.scores[i].playername, hs.scores[i].score, hs.scores[i].playtime);
            }
        }

        return hsList;
    }


    public void FetchHighScoresJSONFile()
    {
        fetchCounter++;
    }
    public void FetchHighScoresJSON()
    {
        fetchCounter++;
        StartCoroutine(GetRequestForHighScores(urlBackendHighScores));
        print("Button Pressed");

    }
    public void FetchHighScoresJSONLONG()
    {
        fetchCounter++;
        StartCoroutine(GetRequestForHighScoresLONG(urlBackendHighScores));
        print("Button Pressed");

    }
    IEnumerator GetRequestForHighScores(string uri)
    {
        print("asdasdad Pressed");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            print("Request sent to " + uri);

            // set downloadHandler for json
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Accept", "application/json");
            // Request and wait for reply

            yield return webRequest.SendWebRequest();

            // get raw data and convert it to string
            string resultStr = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                print("Success");
                // create HighScore item from json string
                hs = JsonUtility.FromJson<HighScores.HighScores>(resultStr);
                //updateHighScoreTextArea = true;
                highScoresTextArea.text = CreateHighScoresList();

            }
        }
    }
    IEnumerator GetRequestForHighScoresLONG(string uri)
    {
        print("asdasdad Pressed");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            print("Request sent to " + uri);

            // set downloadHandler for json
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Accept", "application/json");
            // Request and wait for reply

            yield return webRequest.SendWebRequest();

            // get raw data and convert it to string
            string resultStr = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                print("Success");
                // create HighScore item from json string
                hs = JsonUtility.FromJson<HighScores.HighScores>(resultStr);
                // updateHighScoreTextArea = true;
                highScoresTextArea.text = CreateHighScoresListLONG();

            }
        }
    }

    public void PostGameResults()
    {
        HighScores.HighScore hsItem = new HighScores.HighScore();
        hsItem.playername = playerNameInput.text;
        hsItem.score = float.Parse(scoreInput.text);

        playerNameInput.text = "";
        scoreInput.text = "";

        StartCoroutine(PostRequestForHighScores(urlBackendHighScores, hsItem));
    }
    IEnumerator PostRequestForHighScores(string uri, HighScores.HighScore hsItem)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, JsonUtility.ToJson(hsItem)))
        {
            // set downloadHandler for json
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Accept", "application/json");
            // Request and wait for reply
            yield return webRequest.SendWebRequest();
            // get raw data and convert it to string
            string resultStr = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error in post request: " + webRequest.error);
            }
            else
            {
                print("Received(UTF8): " + resultStr);
            }
        }
    }
}
