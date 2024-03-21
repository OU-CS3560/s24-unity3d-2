using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public Rigidbody2D whiteplayer;
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
    private SpriteAnimation previousAni;
    private void Awake()
    {
        whiteplayer = GetComponent<Rigidbody2D>();
        previousAni = spriteAniDown;
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
        Vector2 position = whiteplayer.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        whiteplayer.MovePosition(position+translation);
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
            Death();
        }
    }
    
    private void Death()
    {
        enabled = false;
        GetComponent<Bomb>().enabled = false;
        spriteAniUp.enabled = false;
        spriteAniDown.enabled = false;
        spriteAniLeft.enabled=false;
        spriteAniRight.enabled=false;
        spriteAniDeath.enabled = true;

        Invoke(nameof(Afterdying), 1.25f);
    }

    private void Afterdying()
    {
        Vector2 respawnPosition = new(-7.0f, 5.5f);

        whiteplayer.position = respawnPosition;

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
