using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    private float lastShootTime = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void BulletShoot()
    {
        GameObject b = Instantiate(bullet, GetComponent<Transform>().position, Quaternion.identity);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position + Vector3.up;
            direction.Normalize();
            b.GetComponent<Rigidbody>().AddForce(direction * 8000f);
        }

        Destroy(b, 8f);
    }

    private void Shoot()
    {
        if(Time.time > lastShootTime + 0.2f)
        {
            lastShootTime = Time.time;

            BulletShoot();
        }
    }
}
