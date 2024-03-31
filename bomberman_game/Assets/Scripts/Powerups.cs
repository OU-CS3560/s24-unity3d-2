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
            case ItemType.Bombpush:
                player.GetComponent<MovementController>().player.mass = 1000000;
                break;
            case ItemType.Shield:
                player.GetComponent<MovementController>().shield = true;
                break;
        }

        var bounds = gameObject.GetComponent<BoxCollider2D>().bounds;
        Destroy(gameObject);
        var guo = new Pathfinding.GraphUpdateObject(bounds);
        guo.updatePhysics = true;
        AstarPath.active.UpdateGraphs(guo);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickUp(other.gameObject);
        }
    }
}
