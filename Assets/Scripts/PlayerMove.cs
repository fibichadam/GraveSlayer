using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        //Plyaer Movement
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        //Rotate player towards mouse
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }


    float AngleBetweenPoints(Vector3 a, Vector3 b) 
    { 
        return Mathf.Atan2(b.z - a.z, a.x - b.x) * Mathf.Rad2Deg - 90f; 
    }

}
