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
    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.gravityScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wood wood = collision.gameObject.GetComponent<Wood>();

        if (wood != null)
        {
            wood.TakeDamage();
            OnKnifeHitWood?.Invoke();
            transform.SetParent(collision.transform);
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            Bounce(collision);
            GameManager.instance.GameOver();

        }
        
    }
    private void Start()
    {
        _rb.linearVelocityY = speed;
    }
 
    private void Bounce(Collision2D collision)
    {
        float x = UnityEngine.Random.value > 0.5f
        ? UnityEngine.Random.Range(-1f, -0.5f)  // Giá trị âm xa 0
        : UnityEngine.Random.Range(0.5f, 1f);   // Giá trị dương xa 0

        Vector2 bounceDirection = new Vector2(x, UnityEngine.Random.Range(-1f, -0.1f)).normalized;



        _rb.linearVelocity = bounceDirection * bounceForce;
        _rb.angularVelocity = 10000f;

    }

}
