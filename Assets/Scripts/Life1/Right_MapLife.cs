using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Right_MapLife : MonoBehaviour
{
    private LifeActivator _lifeActivator;

    private void Awake()
    {
        _lifeActivator = FindObjectOfType<LifeActivator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ColorCollision")
        {
            Material material = collision.gameObject.GetComponent<MeshRenderer>().material;
            if (material.color == Color.black)
            {
                _lifeActivator.blackCounter_Right++;
                Destroy(this.gameObject);
            }
        }
    }
}
