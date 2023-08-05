using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brown_Button : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            Destroy(this.gameObject);
        }
    }
}
