using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public Rigidbody2D player1;
    public Rigidbody2D player2;
    public Text uiText;
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
               

                    this.player1.velocity = Vector3.left * (float)data["move"];
                

                if ((float)data == 1f)
                {
                    this.player1.AddForce(new Vector3(0, 1, 0), ForceMode2D.Impulse);
                }
            }
            if (active_player == 1)
            {
               this.player2.velocity = Vector3.left * (float)data["move"];

                //    this.player2.AddForce(new Vector3(0, (float)data["move"], 0), ForceMode2D.Impulse);

            }
        }
    }

    void StartGame()
    {
        AirConsole.instance.SetActivePlayers(2);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

#endif
}
