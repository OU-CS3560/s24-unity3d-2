using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public Rigidbody2D player;
    public CircleCollider2D hi;
    private Vector2 direction = Vector2.down;
    public float speed = 4F;
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    public SpriteAnimation spriteAniUp;
    public SpriteAnimation spriteAniDown;
    public SpriteAnimation spriteAniLeft;
    public SpriteAnimation spriteAniRight;
    public SpriteAnimation spriteAniDeath;
    //Make respawn postion adjustable
    public float respawn_x = -7.0f;
    public float respawn_y = 5.5f;
    public bool shield = false;
    private SpriteAnimation previousAni;
    public int deaths;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        previousAni = spriteAniDown;
        hi = GetComponent<CircleCollider2D>();

        deaths = 0;
    }
    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteAniUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteAniDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteAniLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteAniRight);
        }
        else
        {
            SetDirection(Vector2.zero, previousAni);
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 position = player.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        player.MovePosition(position+translation);
        
    }
    private void SetDirection (Vector2 newDirection, SpriteAnimation spriteAni)
    {
        direction = newDirection;
        spriteAniUp.enabled = spriteAni == spriteAniUp;
        spriteAniDown.enabled = spriteAni == spriteAniDown;
        spriteAniLeft.enabled = spriteAni == spriteAniLeft;
        spriteAniRight.enabled = spriteAni == spriteAniRight;

        previousAni = spriteAni;
        previousAni.idle = direction == Vector2.zero;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boom"))
        {
            if (shield)
            {
                shield = false;
            }
            else{
                Death();
            }

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // Player collides with an enemy
            if (shield)
            {
                shield = false;
            }
            else
            {
                Death();
            }
            collision.gameObject.GetComponent<EnemyMovement>().Death();
        }
    }
    

    private void Death()
    {
        hi.enabled = false;
        enabled = false;
        deaths++;
        GetComponent<Bomb>().enabled = false;
        spriteAniUp.enabled = false;
        spriteAniDown.enabled = false; 
        spriteAniLeft.enabled=false;
        spriteAniRight.enabled=false;
        spriteAniDeath.enabled = true;
        player.GetComponent<Bomb>().bombs_had = 1;
        player.GetComponent<Bomb>().explosion_radius = 1;
        player.mass = 1;

        Invoke(nameof(Afterdying), 1.25f);
    }

    private void Afterdying()
    {
        hi.enabled = true;
        Vector2 respawnPosition = new(respawn_x, respawn_y);

        player.position = respawnPosition;

        enabled = true;
        GetComponent<Bomb>().enabled = true;
        spriteAniUp.enabled = true;
        spriteAniDown.enabled = true;
        spriteAniLeft.enabled = true;
        spriteAniRight.enabled = true;

        spriteAniDeath.enabled = false;

        SetDirection(Vector2.down, spriteAniDown);
    }


}
