using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Man_Life : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    public bool red = false;
    public bool green = false;

    private void Awake()
    {
        _lifeActivator = FindObjectOfType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;
            if(material.color == Color.red)
            {
                _lifeActivator.gunManColorActivator++;
                red = true;
                Destroy(this.gameObject);
            }

            if(material.color == Color.green)
            {
                _lifeActivator.gunManColorActivator++;
                green = true;
                Destroy(this.gameObject);
            }
        }
    }
}
