using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] 
    private float speed = 100f;
    [SerializeField]
    private float rotationSpeed = 1f;

    private Rigidbody2D rb;
    private Vector2 input;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Rotation();
    }

    private void FixedUpdate()
    {
        Vector2 movement = input * speed * Time.deltaTime;
        Vector2 newPosition = rb.position + movement;
        rb.MovePosition(newPosition);
    }

    private void Rotation()
    {
        if (input.magnitude > 0.5f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, input);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
