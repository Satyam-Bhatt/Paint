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

    private bool stopper = true;

    private void Update()
    {
        if(colorDetector.red == true && stopper)
        {
            StartCoroutine(bulletCoroutine());
            stopper = false;
        }

        if(colorDetector.green == true)
        {

        }
    }

    public IEnumerator bulletCoroutine()
    {
        while (true)
        {
            Instantiate(bullet, bullet_Posi.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
