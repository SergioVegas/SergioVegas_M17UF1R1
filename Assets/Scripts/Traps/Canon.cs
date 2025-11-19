using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjecjtBullet;
    [SerializeField] private Transform _shootPoint;
    private float _bulletdirection; 
    public Stack<GameObject> BulletStack = new Stack<GameObject>();
    private float timeSpawn = 2f;
    private float _nextSpawnTime = 0f;

    private void Awake()
    {
        _bulletdirection = -transform.localScale.x; // - Porque el cañon  esta en el lado contrario a la dirección en la que queremos que se dirija.
    }
    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
           
            
            if (BulletStack.Count == 0)
            {
                InstantiateBullets();
            }
            else
            {
                Pop();
                Debug.Log("Nos gusta reciclar");
            }
            _nextSpawnTime = Time.time + timeSpawn;
        }
    }
    public void Push(GameObject bullet)
    {
        BulletStack.Push(bullet);
        bullet.SetActive(false);
    }
    public GameObject Pop()
    {
        GameObject go = BulletStack.Pop();
        go.SetActive(true);
        go.GetComponent<Collider2D>().enabled = true;
        go.transform.position = _shootPoint.position;
        go.GetComponent<Rigidbody2D>().linearVelocityX = 5f* _bulletdirection;
        return go;
    }

    public void InstantiateBullets()
    {
        GameObject bullet = Instantiate(_gameObjecjtBullet, _shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().canon = this;
        bullet.GetComponent<Rigidbody2D>().linearVelocityX = 5f * _bulletdirection;
    }
}
