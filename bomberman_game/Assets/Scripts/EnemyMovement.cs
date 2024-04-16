using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public float speed = 0.01f;

    private float distance;

    
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

            }
            else if (velocity.x < 0)    // left
            {

            }
            else if (velocity.y > 0)    // up
            {

            }       
            else if (velocity.y < 0)    // down
            {

            }
        }
        else    // object is NOT moving, so cancel moving animation here
        {

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
