using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public float speed = 0.01f;

    private float distance;

    /*
    // Update is called once per frame
    void Update()
    {
        // l2 norm distance between this enemy and the player
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        // direction to chase the player
        Vector2 direction = player.transform.position - this.transform.position;
        direction.Normalize();

        // angle of direction
        float angle = Mathf.Atan2(direction.y, direction.x);

        // move towards player while rotating in an angle calculated above
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
        this.transform.rotation = Quaternion.Euler(Vector3.forward * angle); // Vector3.forward is shorthard for writing Vector3(0, 0, 1).
    }*/
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
