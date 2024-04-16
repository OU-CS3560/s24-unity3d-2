using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    [Header("Bomb Placing")]
    public GameObject bomb_asset;
    public KeyCode bomb_place_key = KeyCode.Space;
    public float bomb_explode_time = 2f;
    public int bombs_had = 1;
    private int bombs_remaining;

    [Header("Explosion")]
    public GoBoom prefab_explosion;
    public float explosion_time = 0.0f;
    public int explosion_radius = 1;
    public LayerMask explosion_layer;

    [Header("Break Block")]
    public DestroyBlock break_prefab;
    public Tilemap breakable_tile;

    [Header("Pathfinder object")]   // helps update the pathfinding when a block is destroyed
    public GameObject PF_object;
    public bool doScan = false;

    [Header("Sound")]
    public AudioSource explosionSound;


    private void OnEnable()
    {
        bombs_remaining = bombs_had;
    }

    private void Update()
    {
        if (bombs_remaining > 0 && Input.GetKeyDown(bomb_place_key))
        {
            StartCoroutine(PlaceBomb());  
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bomb_asset,position,Quaternion.identity);

        bombs_remaining--;

        yield return new WaitForSeconds(bomb_explode_time-0.4f);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        explosionSound.Play();
        yield return new WaitForSeconds(0.4f);
        GoBoom boom = Instantiate(prefab_explosion,position,Quaternion.identity);
        
        boom.Set_active_renderer(boom.start);
        boom.Destroy_After(explosion_time);

        Explode(position, Vector2.up, explosion_radius);
        Explode(position, Vector2.down, explosion_radius);
        Explode(position, Vector2.left, explosion_radius);
        Explode(position, Vector2.right, explosion_radius);

        Destroy(bomb);
        bombs_remaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }
        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one/2f, 0f, explosion_layer))
        {
            ClearBlock(position);
            return;
        }

        GoBoom boom = Instantiate(prefab_explosion, position, Quaternion.identity);
        if(length > 1)
        {
            boom.Set_active_renderer(boom.mid);
        }
        else
        {
            boom.Set_active_renderer(boom.end);
        }
        boom.Set_direction(direction);
        boom.Destroy_After(explosion_time);

        Explode(position,direction,length-1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }

    private void ClearBlock(Vector2 position)
    {
        Vector3Int cell = breakable_tile.WorldToCell(position);
        TileBase tile = breakable_tile.GetTile(cell);

        if(tile != null)
        {
            DestroyBlock break_instance = Instantiate(break_prefab, position, Quaternion.identity);
            break_instance.GetComponent<DestroyBlock>().PF_object = this.PF_object;

            breakable_tile.SetTile(cell, null);
        }
    }

    public void AddBomb()
    {
        bombs_had++;
        bombs_remaining++;
    }
}
