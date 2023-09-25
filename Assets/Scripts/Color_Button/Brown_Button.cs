using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brown_Button : MonoBehaviour
{
    [SerializeField] private GameObject brownButton;
    [SerializeField] private GameObject brown_Text;

    private void Awake()
    {
        brownButton.SetActive(false);
        brown_Text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            brownButton.SetActive(true);
            brown_Text.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
