using UnityEngine;

public class Powerups : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBombs,
        BlastRadius,
    }

    public ItemType type;

    private void OnItemPickUp(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBombs:
                player.GetComponent<Bomb>().AddBomb();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<Bomb>().explosion_radius++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickUp(other.gameObject);
        }
    }
}
