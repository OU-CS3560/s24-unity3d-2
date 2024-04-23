using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public float speed = 0.01f;

    private float distance;
    public SpriteAnimation spriteAniUp;
    public SpriteAnimation spriteAniDown;
    public SpriteAnimation spriteAniLeft;
    public SpriteAnimation spriteAniRight;
    private SpriteAnimation previousAni;
    
    // Update is called once per frame
    void Update()
    {
        // in case the angle of movement is not 90 vertically or horizontally, we move in the closer side of that angle and ignore the other direction
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        
        float x = Mathf.Abs(velocity.x);
        float y = Mathf.Abs(velocity.y);
        if (x != 0 && y != 0)
        {
            if (x < y)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity.y);
            }
        }
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;


        // write your movement animation here
        // object is moving

        if (velocity != Vector2.zero)
        {
            if (velocity.x > 0) // right
            {
                spriteAniUp.enabled = false;
                spriteAniDown.enabled = false;
                spriteAniLeft.enabled = false;
                spriteAniRight.enabled = true;
                previousAni.idle = false;

                previousAni = spriteAniRight;
            }
            else if (velocity.x < 0)    // left
            {
                spriteAniUp.enabled = false;
                spriteAniDown.enabled = false;
                spriteAniLeft.enabled = true;
                spriteAniRight.enabled = false;
                previousAni.idle = false;

                previousAni = spriteAniLeft;
            }
            else if (velocity.y > 0)    // up
            {
                spriteAniUp.enabled = true;
                spriteAniDown.enabled = false;
                spriteAniLeft.enabled = false;
                spriteAniRight.enabled = false;
                previousAni.idle = false;

                previousAni = spriteAniUp;
            }       
            else if (velocity.y < 0)    // down
            {
                spriteAniUp.enabled = false;
                spriteAniDown.enabled = true;
                spriteAniLeft.enabled = false;
                spriteAniRight.enabled = false;
                previousAni.idle = false;

                previousAni = spriteAniDown;
            }
        }
        else    // object is NOT moving, so cancel moving animation here
        {
            //previousAni.idle = true;
            spriteAniUp.enabled = false;
            spriteAniDown.enabled = false;
            spriteAniLeft.enabled = false;
            spriteAniRight.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boom"))
        {
            Death();
        }
    }
    public void Death()
    {
        enabled = false;

        Invoke(nameof(Afterdying), 0.25f);
    }

    private void Afterdying()
    {
        gameObject.SetActive(false);
    }
}
