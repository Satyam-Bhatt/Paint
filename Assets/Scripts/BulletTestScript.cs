using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTestScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_Posi;
    [SerializeField] private Movement player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, bullet_Posi.transform.position, Quaternion.identity);
        }
    }
}
