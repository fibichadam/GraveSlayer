using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        Camera.main.GetComponent<Transform>().position = playerPos.position + new Vector3(0f, 60f, 0f);
    }
}
