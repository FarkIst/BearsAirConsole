using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GControllerScript : MonoBehaviour {

    private GameLoader gl;
    private static bool created = false;
    private GameObject menu;
    private GameObject cam;
    public GameObject player1;
    public GameObject player2;
    public GameObject props;
    public GameObject p1Spawn;
    public GameObject p2Spawn;
    public GameObject GameStartPosition;

    private Text p1Score;
    private Text p2Score;
    private int score1;
    private int score2;



    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
    }

    void Start()
    {
        menu = GameObject.Find("Menu");

        gl = menu.GetComponent<GameLoader>();
        p1Score = GameObject.Find("p1Score").GetComponent<Text>();
        p2Score = GameObject.Find("p2Score").GetComponent<Text>();
        cam = GameObject.Find("Main Camera");
}

    void Update()
    {
            p1Score.text = "Player 1: " + score1.ToString();
            p2Score.text = "Player 2: " + score2.ToString();
    }

    public void RestartLevel()
    {
        player1.transform.position = p1Spawn.transform.position;
        player2.transform.position = p2Spawn.transform.position;
        props.transform.position = GameStartPosition.transform.position;
        // GameObject cam = Instantiate(cameraPrefab, new Vector2(0, 0), transform.rotation);
        //      cam.name = "Main Camera";
        //       cam.GetComponent<CameraMovement>().delay = 7f;
        Destroy(cam.GetComponent < CameraMovement>());
        cam.transform.position = new Vector3(0, 0, -10);
        cam.AddComponent<CameraMovement>();
        cam.GetComponent<CameraMovement>().StartDelay();
        menu.SetActive(true);
        gl.SetStart();
    }

    public void GetDeadPlayer(string player)
    {
       // Destroy(GameObject.Find("Main Camera"));
        Debug.Log(player);
        if(player == "Player1")
        {
            score2 += 1;
        }
        else if(player == "Player2")
        {
            score1 += 1;
        }
        RestartLevel();
    }


}
