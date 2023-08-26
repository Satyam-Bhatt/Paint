using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunMan_Handler : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private Gun_Man_Life colorDetector;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_Posi;

    [SerializeField] private GameObject dialogue;
    [SerializeField] private TMP_Text kill_Text;

    [SerializeField] private Dialogue gun_ManHelp_Dialogue;

    private bool stopper = true;
    private bool dialogueStopper = true;
    private Bool_Handler snakeAlive;

    [HideInInspector]
    public bool killPlayer = false;

    [HideInInspector]
    public bool killSnake = false;

    private void Awake()
    {
        snakeAlive = FindObjectOfType<Bool_Handler>();  
        
        dialogue.SetActive(false);
    }

    private void Update()
    {
        if(colorDetector.red == true && stopper)
        {
            StartCoroutine(bulletCoroutine());
            killPlayer = true;
            dialogue.SetActive(true);
            StartCoroutine(TextAppear(kill_Text.text));
            Invoke("Destroy", 5f);
            stopper = false;
        }

        if(colorDetector.green == true)
        { 
            FindObjectOfType<Dialogue_Manager>().gunMan_Call = true;
            if (dialogueStopper)
            {
                FindObjectOfType<Dialogue_Manager>().StartDialogue(gun_ManHelp_Dialogue);
                dialogueStopper = false;
            }
                if(stopper && snakeAlive.snakeAlive)
                {
                    StartCoroutine(bulletCoroutine());
                    killSnake = true;
                    stopper = false;
                }
            
        }
    }

    public IEnumerator bulletCoroutine()
    {
        while (true)
        {
            Instantiate(bullet, bullet_Posi.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator TextAppear(string text)
    {
        kill_Text.text = "";

        Vector3 pos = new Vector3(0, 1, 0);

        foreach (char c in text.ToCharArray())
        {
            kill_Text.text += c;

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void Destroy()
    {
        dialogue.SetActive(false);
        StopCoroutine(TextAppear(kill_Text.text));
    }
}
