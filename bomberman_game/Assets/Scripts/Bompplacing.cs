using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombasset;
    public KeyCode bombplacedkey = KeyCode.Space;
    public float bombexplodedtime = 4f;
    public int bombshad = 1;
    private int bombsremaining;

    private void OnEnable()
    {
        bombsremaining = bombshad;
    }

    private void Update()
    {
        if (bombsremaining > 0 && Input.GetKeyDown(bombplacedkey))
        {
            StartCoroutine(PlaceBomb());  
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombasset,position,Quaternion.identity);
        bombsremaining--;

        yield return new WaitForSeconds(bombexplodedtime);

        Destroy(bomb);
        bombsremaining++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }

}
