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

    [SerializeField] private GameObject panel;

    private bool stopper = true;
    private bool dialogueStopper = true;
    private bool coroutineStopper = true; 
    private Bool_Handler bool_Handler;

    [HideInInspector]
    public bool killPlayer = false;

    [HideInInspector]
    public bool killSnake = false;

    private Coroutine bulletCoroutine = null;

    private void Awake()
    {
        bool_Handler = FindObjectOfType<Bool_Handler>();  
        
        dialogue.SetActive(false);
    }

    private void Update()
    {
        if(colorDetector.red == true && stopper)
        {
            bulletCoroutine = StartCoroutine(BulletCoroutine());
            killPlayer = true;
            dialogue.SetActive(true);
            StartCoroutine(TextAppear(kill_Text.text));
            Invoke("Destroy", 5f);
            stopper = false;
        }

        if(colorDetector.green == true)
        { 
            
            if (dialogueStopper)
            {
                panel.SetActive(false);
                FindObjectOfType<Dialogue_Manager>().gunMan_Call = true;
                FindObjectOfType<Dialogue_Manager>().StartDialogue(gun_ManHelp_Dialogue);
                dialogueStopper = false;
            }
                if(stopper && bool_Handler.snakeAlive)
                {
                    bulletCoroutine = StartCoroutine(BulletCoroutine());
                    killSnake = true;
                    stopper = false;
                }
            
        }

        if(bool_Handler.bulletCoroutine_Snake == false && coroutineStopper)
        {
            StopCoroutine(bulletCoroutine);
            coroutineStopper = false;
        }
    }

    public IEnumerator BulletCoroutine()
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
