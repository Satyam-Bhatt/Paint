using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brown_Button : MonoBehaviour
{
    [SerializeField] private GameObject brownButton;

    private void Awake()
    {
        brownButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            brownButton.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
