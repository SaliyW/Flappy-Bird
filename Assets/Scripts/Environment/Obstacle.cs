using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    private ObjectPool<Obstacle> _pool;

    public ObjectPool<Obstacle> Pool { set => _pool = value; }

    public void Release()
    {
            _pool.Release(this);
    }
}