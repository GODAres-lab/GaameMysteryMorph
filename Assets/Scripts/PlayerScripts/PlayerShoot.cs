using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Instantiate(bullet, shootPoint.position, transform.rotation);
        }
    }
}