using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public Text uiText;

    private bool move;
#if !DISABLE_AIRCONSOLE

    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }


    void OnConnect(int device_id)
    {
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {
                StartGame();
            }
            else
            {
                uiText.text = "NEED MORE PLAYERS";
            }
        }
    }

    void OnDisconnect(int device_id)
    {
        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        if (active_player != -1)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {
                StartGame();
            }
            else
            {
                AirConsole.instance.SetActivePlayers(0);
               
                uiText.text = "PLAYER LEFT - NEED MORE PLAYERS";
            }
        }
    }


    void OnMessage(int from, JToken data)
    {

       

        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);
        if (active_player != -1)
        {
           

            if (active_player == 0)
            {

                if ((string)data == "left")
                {
                    player1.GetComponent<PlayerMovement>().SetLeft(true);
                    player1.GetComponent<PlayerMovement>().SetRight(false);
                }

                if ((string)data == "right")
                {
                    player1.GetComponent<PlayerMovement>().SetLeft(false);
                    player1.GetComponent<PlayerMovement>().SetRight(true);
                }

                if ((string)data == "jump")
                {
                    player1.GetComponent<PlayerMovement>().Jump();
                }

                
                if ((string)data == "stop")
                {
                    player1.GetComponent<PlayerMovement>().SetStop();
                }
               
                if((string)data == "shoot")
                {
                    player1.GetComponent<PlayerMovement>().Shoot();
                }

            }
            if (active_player == 1)
            {
                if ((string)data == "left")
                {
                    player2.GetComponent<PlayerMovement>().SetLeft(true);
                    player2.GetComponent<PlayerMovement>().SetRight(false);
                }

                if ((string)data == "right")
                {
                    player2.GetComponent<PlayerMovement>().SetLeft(false);
                    player2.GetComponent<PlayerMovement>().SetRight(true);
                }

                if ((string)data == "jump")
                {
                    player2.GetComponent<PlayerMovement>().Jump();
                }


                if ((string)data == "stop")
                {
                    player2.GetComponent<PlayerMovement>().SetStop();
                }

                if ((string)data == "shoot")
                {
                    player2.GetComponent<PlayerMovement>().Shoot();
                }
            }
        }
    }

    void StartGame()
    {
        AirConsole.instance.SetActivePlayers(2);
        GameObject.Find("Menu").GetComponent<GameLoader>().SetStart();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

#endif
}
