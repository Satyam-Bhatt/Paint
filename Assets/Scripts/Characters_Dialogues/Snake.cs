using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
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
            if (material.color == Color.red)
            {
                _lifeActivator.snakeColorActivator++;
                Destroy(this.gameObject);
            }
        }
    }
}
