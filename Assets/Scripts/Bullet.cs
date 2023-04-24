using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(10);
        }   
    }
}
