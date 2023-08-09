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
            Material material = collision.gameObject.GetComponent<Material>();
            if(material = _material_Brown)
            {
                Debug.Log("Brown Ke Saath Baj gya");
            }
        }
    }
}
