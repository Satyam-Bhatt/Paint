using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Button : MonoBehaviour
{
    [SerializeField] private GameObject redButton;

    private void Awake()
    {
        redButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            redButton.SetActive(true);
            Destroy(this.gameObject);
        }
       
    }
}
