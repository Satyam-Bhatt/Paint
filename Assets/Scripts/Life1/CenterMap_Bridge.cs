using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMap_Bridge : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    [SerializeField] private Material _material_Brown;

    private void Awake()
    {
        _lifeActivator = FindAnyObjectByType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;

            Debug.Log("Grabbed Brown:    " + material.color.ToString());
            Debug.Log("mera brown:    " + _material_Brown.color.ToString());

            if(material.color == _material_Brown.color)
            {
                Debug.Log("Brown Ke Saath Baj gya");
                _lifeActivator.brownCounter++;
                Destroy(this.gameObject);
            }
        }
    }
}
