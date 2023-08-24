using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Snake_Handler : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject deleteSnake;

    [SerializeField] private float speed = 10f;

    private Bool_Handler snakeBool;

    private void Awake()
    {
        snakeBool = FindObjectOfType<Bool_Handler>();
    }

    private void Start()
    {
        deleteSnake.SetActive(false);
        snakeBool.snakeAlive = true;       
    }

    private void Update()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * speed);

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
}
