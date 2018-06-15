using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    private Camera m_Cam;
    private BoxCollider2D leftColl;
    private BoxCollider2D rightColl;

    void Start()
    {
        m_Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        leftColl = GameObject.Find("Left Collider").GetComponent<BoxCollider2D>();
        rightColl = GameObject.Find("Right Collider").GetComponent<BoxCollider2D>();

        rightColl.size = new Vector2(3f, m_Cam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightColl.offset = new Vector2(m_Cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 1, rightColl.size.y / 4);
        leftColl.size = new Vector2(3f, m_Cam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftColl.offset = new Vector2(m_Cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 3f, leftColl.size.y / 4);
    }
}
