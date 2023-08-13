using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Button : MonoBehaviour
{
    [SerializeField] private GameObject greenButton;

    private void Awake()
    {
        greenButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            greenButton.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
