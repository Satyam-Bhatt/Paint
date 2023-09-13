using UnityEngine;

public class Snake_Handler : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject deleteSnake;

    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject killedSnake;

    private Bool_Handler bool_Handler;

    private void Awake()
    {
        bool_Handler = FindObjectOfType<Bool_Handler>();
    }

    private void Start()
    {
        deleteSnake.SetActive(false);
        killedSnake.SetActive(false);
        bool_Handler.snakeAlive = true;       
    }

    private void Update()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * speed, Space.World);

        transform.rotation = Quaternion.Euler(Vector3.forward * (GetAngleFromVectorFloat(dir)));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Snake Killer")
        {
            Destroy(collision.gameObject);

            bool_Handler.bulletCoroutine_Snake = false;
            killedSnake.transform.position = transform.position;
            killedSnake.transform.rotation = transform.rotation;
            killedSnake.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
