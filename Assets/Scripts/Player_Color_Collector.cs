using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Color_Collector : MonoBehaviour
{
    [SerializeField] private Button _color;

    private void Start()
    {
      //  _color.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 && collision.gameObject.tag == "Brown")
        {
          //  _color.enabled=true;
            Destroy(this);
        }
    }
}
