using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GunMan_Handler : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private Gun_Man_Life colorDetector;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_Posi;

    private void Update()
    {
        if(colorDetector.red == true)
        {
            Vector2 dir = player.transform.position - bullet_Posi.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, dir);

            Instantiate(bullet, bullet_Posi.transform.position, targetRotation);
        }

        if(colorDetector.green == true)
        {

        }
    }
}
