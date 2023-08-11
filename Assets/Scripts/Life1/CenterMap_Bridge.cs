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

            if(material.color == _material_Brown.color)
            {
                _lifeActivator.brownCounter++;
                Debug.Log(_lifeActivator.brownCounter);
                Destroy(this.gameObject);
            }
        }
    }
}
