using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerObstacle = -2;
    [SerializeField] private float _upperObstacle = 2;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _maxSize = 10;
    [SerializeField] private Obstacle _prefab;
    [SerializeField] private Transform _container;

    private ObjectPool<Obstacle> _pool;
    private Coroutine _coroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Obstacle>(
        createFunc: () => ActionOnCreate(),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => ActionOnRelease(obj),
        actionOnDestroy: (obj) => ActionOnDestroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _maxSize);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnObstacles(_delay));
    }

    public void Reset()
    {
        _pool.Clear();

        if (_container.childCount > 0)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private IEnumerator SpawnObstacles(float delay)
    {
        while (true)
        {
            _pool.Get();

            yield return new WaitForSeconds(delay);
        }
    }

    private Obstacle ActionOnCreate()
    {
        Obstacle obstacle = Instantiate(_prefab);
        obstacle.Pool = _pool;

        return obstacle;
    }

    private void ActionOnGet(Obstacle obj)
    {
        float spawnPositionY = Random.Range(_upperObstacle, _lowerObstacle);
        Vector3 spawnPoint = new(transform.position.x, spawnPositionY, transform.position.z);
        obj.transform.parent = _container;
        obj.transform.position = spawnPoint;

        obj.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Obstacle obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Obstacle obj)
    {
        Destroy(obj.gameObject);
    }
}