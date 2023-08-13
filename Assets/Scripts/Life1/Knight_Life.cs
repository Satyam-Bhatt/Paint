using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight_Life : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    [SerializeField] private Material red;

    private void Awake()
    {
        _lifeActivator = FindObjectOfType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;
            if(material.color == red.color)
            {
                _lifeActivator.knighColorActivator++;
                Destroy(this.gameObject);
            }
        }
    }
}
