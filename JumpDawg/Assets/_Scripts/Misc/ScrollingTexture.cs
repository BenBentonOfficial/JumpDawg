using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Vector2 scrollSpeed;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // keeps background moving during pause
        sr.material.mainTextureOffset += new Vector2(Time.fixedUnscaledDeltaTime * scrollSpeed.x,
                                                     Time.fixedUnscaledDeltaTime * scrollSpeed.y); 
    }
}
