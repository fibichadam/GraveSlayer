using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bullet;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject b = Instantiate(bullet, GetComponent<Transform>().position, Quaternion.identity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                direction.Normalize();
                b.GetComponent<Rigidbody>().AddForce(direction * 7000f);

            }

            Destroy(b, 4f);
        }
    }

}
