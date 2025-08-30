using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed, damage, destroyTime;
    // Update is called once per frame

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyD"))
        {
            collision.transform.parent.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
            print("Kena Dmg kan?");
        } else if (collision.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
