using UnityEngine;

public class PassthroughPlatform : MonoBehaviour
{
    private Collider2D _collider2D;
    private Collider2D _playerCollider2D;
    private bool active = false;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public void TogglePassthrough(Collider2D playerCol)
    {
        _playerCollider2D = playerCol;
        active = !active;
        Physics2D.IgnoreCollision(playerCol, _collider2D, active);
    }
    
}
