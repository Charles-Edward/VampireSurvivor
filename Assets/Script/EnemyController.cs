using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    


    [SerializeField]
    private Transform _moveTarget;
    [SerializeField]
    public float _speed;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    KillCountManager _killCountManager;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;

    // Private & Protected
    private Rigidbody2D _rb2D;
    public int _killCount;
    private bool _isDead;
    private GameObject _bullet;
    private Vector2 _dirRandom;
    private float _speedBullet = 80f;


    void Start()
    {
        _isDead = false;

        StopAllCoroutines();
        _moveTarget = GameObject.Find("---- Player -----").transform;
        _rb2D = GetComponent<Rigidbody2D>();
        _dirRandom = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
    }




    void Update()
    {
        if (_isDead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, _speed * Time.deltaTime);
           // Vector2 directionToPlayer = _moveTarget.position - transform.position;

            //_rb2D.velocity = directionToPlayer.normalized * _speed * Time.deltaTime;

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("touché");
            _rb2D.velocity = Vector2.zero;
            _isDead = true;
            StartCoroutine(Death());
            Destroy(collision.gameObject);  // detruire le game object qui collisionne et non le game object rattaché au script
            KillCountManager.instance.AddPoint();
            _killCount++;
        }
    }

    IEnumerator Death()
    {
        _animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        EnemyShoot();
        transform.position = transform.position;
        Destroy(gameObject);

    }

    private void EnemyShoot()
    {
        _bullet = Instantiate(_bulletPrefab, new Vector2(transform.position.x + _dirRandom.x, transform.position.y + _dirRandom.y), transform.rotation);
        _bullet.GetComponent<Rigidbody2D>().velocity = _dirRandom * _speedBullet;
        Destroy(_bullet, 2);


    }
}
