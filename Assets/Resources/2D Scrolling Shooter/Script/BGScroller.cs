using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
    }

    [SerializeField] private Direction direction = Direction.Down;

    [SerializeField] private float speed = 0.1f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float finalScroll = (float)direction;
        meshRenderer.material.mainTextureOffset += new Vector2(0f, speed) * Time.deltaTime * finalScroll;
    }
}
