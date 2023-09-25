using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Button : MonoBehaviour
{
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject redText;

    private void Awake()
    {
        redButton.SetActive(false);
        redText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            redButton.SetActive(true);
            redText.SetActive(true);
            Destroy(this.gameObject);
        }
       
    }
}
