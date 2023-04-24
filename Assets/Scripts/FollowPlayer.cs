using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform camPos;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GetComponent<Transform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camPos.position = playerPos.position + new Vector3(0f, 65f, 0f);
    }
}
