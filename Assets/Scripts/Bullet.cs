using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    
    private Movement player;
    private GunMan_Handler gunMan;
    private Snake_Handler snake;

    private Vector3 dir;

    private void Awake()
    {
        player = FindObjectOfType<Movement>();
        gunMan = FindObjectOfType<GunMan_Handler>();
        snake = FindObjectOfType<Snake_Handler>();
    }

    private void Start()
    {
        if(gunMan.killPlayer)
        {
            this.gameObject.tag = "Player Killer";

            dir = (player.transform.position - transform.position).normalized;
            
        }

        if (gunMan.killSnake)
        {
            this.gameObject.tag = "Snake Killer";

            dir = (snake.transform.position - transform.position).normalized;
        }

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));

        Invoke("Destroy", 5f);
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

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
