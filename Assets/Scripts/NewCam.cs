using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCam : MonoBehaviour
{
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    float minSizeY = 5f;

    Vector3 midPos;

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }

    void SetCameraPos()
    {
        midPos = (player1.position + player2.position) * 0.5f;
        transform.position = new Vector3(midPos.x, midPos.y, transform.position.z);

    }

    void SetCameraSize()
    {
        float minSizeX = minSizeY * Screen.width / Screen.height;

        float width = Mathf.Abs( (player1.position.x) - (player2.position.x) ) * 0.5f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f;

        float camSizeX = Mathf.Max(width, minSizeX);
        Camera.main.orthographicSize = Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY);
    }
}
