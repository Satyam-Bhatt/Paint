using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    
    private Movement player;
    private Rigidbody2D rb;

    private Vector3 dir;

    private void Awake()
    {
        player = FindObjectOfType<Movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        dir = (player.transform.position - transform.position).normalized;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir  = dir.normalized;
        float n = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        if(n < 0)
        {
            n += 360;
        }
        return n;
    }
}
