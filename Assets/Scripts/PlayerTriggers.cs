using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneUp1" )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 25f, 0);
            m_Camera.transform.position = new Vector3(0, 104.94f, -10);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneUp2")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 25f, 0);
            m_Camera.transform.position = new Vector3(0, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneRight1")
        {
            transform.position = new Vector3(transform.position.x + 18f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(107.11f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneRight2")
        {
            transform.position = new Vector3(transform.position.x - 18f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(0f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneLeft1")
        {
            transform.position = new Vector3(transform.position.x - 27f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(-115.35f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneLeft2")
        {
            transform.position = new Vector3(transform.position.x + 27f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(-0f, 0, -10f);
        }

    }
}
