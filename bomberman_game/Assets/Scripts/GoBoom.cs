using UnityEngine;

public class GoBoom : MonoBehaviour
{
    public SpriteAnimation start;
    public SpriteAnimation mid;
    public SpriteAnimation end;

    public void Set_active_renderer(SpriteAnimation renderer)
    {
        start.enabled = renderer == start;
        mid.enabled = renderer == mid;
        end.enabled = renderer == end;
    }

    public void Set_direction (Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void Destroy_After(float t)
    {
        Destroy(gameObject, t);
    }
}
