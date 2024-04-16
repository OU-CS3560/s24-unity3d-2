using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBombs,
        BlastRadius,
        Bombpush,
        Shield
    }
    [SerializeField] public GameObject EnemyPrefab;

    private GameObject enemy;
    public ItemType type;
    private IEnumerator coroutine;
    private float x;
    private float y;
    private GameObject other_player;

    private void SpawnEnemyAfterPickUp()
    {
        this.enemy = Instantiate(EnemyPrefab, new Vector3(this.x, this.y, 0), Quaternion.identity);
        this.enemy.GetComponent<Pathfinding.AIDestinationSetter>().target = this.other_player.transform;
        
    }

    private void OnItemPickUp(GameObject player_collided)
    {
        switch (type)
        {
            case ItemType.ExtraBombs:
                if(player_collided.GetComponent<Bomb>().bombs_had<4)
                player_collided.GetComponent<Bomb>().AddBomb();
                break;
            case ItemType.BlastRadius:
                if (player_collided.GetComponent<Bomb>().explosion_radius < 4)
                {
                    player_collided.GetComponent<Bomb>().explosion_radius++;
                }
                break;
            case ItemType.Bombpush:
                player_collided.GetComponent<MovementController>().player.mass = 1000000;
                break;
            case ItemType.Shield:
                player_collided.GetComponent<MovementController>().shield = true;
                break;
        }


        var bounds = gameObject.GetComponent<BoxCollider2D>().bounds;
        Destroy(gameObject);
        var guo = new Pathfinding.GraphUpdateObject(bounds);
        guo.updatePhysics = true;
        AstarPath.active.UpdateGraphs(guo);

        
        this.enemy = Instantiate(EnemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
        this.enemy.GetComponent<Pathfinding.AIDestinationSetter>().target = this.other_player.transform;
        //Invoke("SpawnEnemyAfterPickUp", 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.other_player = GameObject.FindGameObjectWithTag("Player2");
            this.x = -7f;
            this.y = -8.8f;
            OnItemPickUp(other.gameObject);
        }
        else if (other.CompareTag("Player2"))
        {
            this.other_player = GameObject.FindGameObjectWithTag("Player");
            this.x = 9f;
            this.y = 4.95f;
            OnItemPickUp(other.gameObject);
        }
    }
}
