using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject win_Panel;

    private bool starMove = false;

    private Menu_Handler m_Handler;

    private void Awake()
    {
        m_Handler = FindObjectOfType<Menu_Handler>();
        win_Panel.SetActive(false);
    }

    private void Update()
    {
        if (starMove && star)
        {
            Vector3 dir = (transform.position - star.transform.localPosition).normalized;
            star.transform.Translate(dir * Time.deltaTime * 10f);

            star.transform.localScale = new Vector3(star.transform.localScale.x - Time.deltaTime, star.transform.localScale.y - Time.deltaTime, star.transform.localScale.z);
        }

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
            transform.position = new Vector3(transform.position.x + 25f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(107.11f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneRight2")
        {
            transform.position = new Vector3(transform.position.x - 25f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(0f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneLeft1")
        {
            transform.position = new Vector3(transform.position.x - 35f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(-115.35f, 0, -10f);
        }

        if (collision.gameObject.layer == 6 && collision.gameObject.tag == "SceneLeft2")
        {
            transform.position = new Vector3(transform.position.x + 35f, transform.position.y, 0);
            m_Camera.transform.position = new Vector3(-0f, 0, -10f);
        }

        if(collision.gameObject.tag == "Player Killer")
        {
            Destroy(collision.gameObject);
            m_Handler.playerDied = true;
        }

        if(collision.gameObject.tag == "Snake")
        {
            m_Handler.playerDied = true;
        }

        if(collision.gameObject.tag == "Rope")
        {
            starMove = true;
        }

        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            win_Panel.SetActive(true);
        }

    }
}
