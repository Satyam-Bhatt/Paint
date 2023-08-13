using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar_Girl_Life : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    private void Awake()
    {
        _lifeActivator = FindObjectOfType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;
            if(material.color == Color.green)
            {
                _lifeActivator.guitarColorActivtor++;
                Destroy(this.gameObject);
            }
        }
    }
}
