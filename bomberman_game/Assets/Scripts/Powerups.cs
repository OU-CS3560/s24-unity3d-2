using UnityEngine;

public class Powerups : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBombs,
        BlastRadius,
        Bombpush,
        shield,
    }

    public ItemType type;

    private void OnItemPickUp(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBombs:
                if (player.GetComponent<Bomb>().bombs_had < 4)
                {
                    player.GetComponent<Bomb>().AddBomb();
                }
                break;
            case ItemType.BlastRadius:
                if (player.GetComponent<Bomb>().explosion_radius < 3)
                {
                    player.GetComponent<Bomb>().explosion_radius++;
                }
                break;
            case ItemType.Bombpush:
                player.GetComponent<MovementController>().player.mass = 1000000;
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
