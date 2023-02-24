using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _fireRate = 0.35f;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _speed = 30f;
    [SerializeField]
    private GameObject _panelRetry;

    //  Private & Protected
    private float _nextTimeToShoot;
    private Rigidbody2D _rb2D;
    private Vector2[] _direction =
    {
        new Vector2(0,1),
        new Vector2(1,0),
        new Vector2(-1,0),
        new Vector2(0,-1)

    };
    private Vector2[] _newDirection =
    {
        new Vector2(1,1),
        new Vector2(1,-1),
        new Vector2(-1,-1),
        new Vector2(-1,1)

    };

    private GameObject _bullet;
    private UIController _uiController;
  

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _animator.SetBool("isShooting", false);
        
    }



    void Update()
    {
        Shoot();
        //NewShoot();
        //ExtraBullet();

    }

    

    private void Shoot()
    {
        if (Time.timeSinceLevelLoad > _nextTimeToShoot)
        {
        
            _animator.SetBool("isShooting", true);
            for (int i = 0; i <= 3; i++)
            {

                //NewShoot();
                //IncreaseFireRate();
                _nextTimeToShoot = Time.timeSinceLevelLoad + _fireRate;
                _bullet = Instantiate(_bulletPrefab, new Vector2(transform.position.x + _direction[i].x, transform.position.y + _direction[i].y), transform.rotation);
                
                _bullet.GetComponent<Rigidbody2D>().velocity = _direction[i] * _speed;
                //ExtraBullet();
                Destroy(_bullet, 2);
            
            }

        }
        else if (Time.timeSinceLevelLoad > _nextTimeToShoot - 0.7f)
        {
            _animator.SetBool("isShooting", false);
        }

    }

    // Shoot en diagonale
    private void NewShoot()
    {
        if (Time.timeSinceLevelLoad >_nextTimeToShoot)
        {

            _animator.SetBool("isShooting", true);
            for (int i = 0; i <= 3; i++)
            {
                _nextTimeToShoot = Time.timeSinceLevelLoad + _fireRate;

                _bullet = Instantiate(_bulletPrefab, new Vector2(transform.position.x + _newDirection[i].x, transform.position.y + _newDirection[i].y), transform.rotation);
                _bullet.GetComponent<Rigidbody2D>().velocity = _newDirection[i] * _speed;

            }

        }
        


    }

    // Double Shoot
    private void ExtraBullet()
    {
        if (Time.timeSinceLevelLoad > _nextTimeToShoot)
        {
            _animator.SetBool("isShooting", true);
            for (int i = 0; i <= 3; i++)
        {
        _nextTimeToShoot = Time.timeSinceLevelLoad + 0.8f;

        _bullet = Instantiate(_bulletPrefab, new Vector2(transform.position.x + _direction[i].x, transform.position.y + _direction[i].y), transform.rotation);

        _bullet.GetComponent<Rigidbody2D>().velocity = _direction[i] * _speed;
        Destroy(_bullet, 2);
        }

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Perdu");
            Destroy(gameObject);
            Time.timeScale = 0;
            _panelRetry.SetActive(true);
            _uiController.RestartGame();
        }


    }

    // Increase fire rate by 25%
    private void IncreaseFireRate()
    {

        _nextTimeToShoot = Time.timeSinceLevelLoad + _fireRate * 0.75f;

    }


    // Increase player movement by 25%





}
