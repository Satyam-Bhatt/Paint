using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeToRope : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    [SerializeField] private Material _material_Brown;
    [SerializeField] private GameObject parent;

    private void Awake()
    {
        _lifeActivator = FindAnyObjectByType<LifeActivator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;

            if (material.color == _material_Brown.color)
            {
                _lifeActivator.snakeToRope_Activator++;
                parent.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}
