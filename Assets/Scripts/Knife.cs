using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Knife : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D _rb;
    private Collider2D _col;
    public float bounceForce => 1.5f*speed;
    public event Action OnKnifeHitWood;
    private bool _hitted = false;
    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.gravityScale = 0f;
        _hitted = false; 
    }
    private void Start()
    {
        _rb.linearVelocityY = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hitted) return;

        switch (collision.gameObject.GetComponent<MonoBehaviour>())
        {
            case Knife:
                Bounce(collision);
                GameManager.instance.GameOver();
                break;
            case Wood:
                Wood wood = collision.gameObject.GetComponent<Wood>();
                wood.woodHealth.TakeDame();
                OnKnifeHitWood?.Invoke();
                transform.SetParent(collision.transform);
                _rb.bodyType = RigidbodyType2D.Kinematic;
                break;
            case Apple:

                break;
            
        }
        _hitted = true;
    }
 
    private void Bounce(Collision2D collision)
    {
        float x = UnityEngine.Random.value > 0.5f
        ? UnityEngine.Random.Range(-1f, -0.5f)  
        : UnityEngine.Random.Range(0.5f, 1f);
        Vector2 bounceDirection = new Vector2(x, UnityEngine.Random.Range(-1f, -0.1f)).normalized;
        _rb.linearVelocity = bounceDirection * bounceForce;
        _rb.angularVelocity = 10000f;

    }

}
