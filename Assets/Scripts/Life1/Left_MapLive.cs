using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_MapLive : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    private void Awake()
    {
        _lifeActivator = FindAnyObjectByType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;
            if(material.color == Color.black)
            {
                _lifeActivator.blackCounter_Left++;
                Destroy(this.gameObject);
            }
        }
    }
}
