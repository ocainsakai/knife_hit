using System;
using UnityEngine;

public class Knife : ObjAbstract
{
    public float speed = 10f;
    public float bounceForce => 1.5f*speed;
    public event Action OnKnifeHitWood;
    private void Awake()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.gravityScale = 0f;
        this.gameObject.tag = "Knife";
    }
    public void SetSpeed()
    {
        _rb.linearVelocityY = speed;
    }
    public override void SetTag()
    {
        this.gameObject.tag = "Obstacle";
        _rb.freezeRotation = true;
    }
    public void Hitted()
    {
        SetTag();
        OnKnifeHitWood?.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            Bounce(collision);
            GameManager.instance.GameOver();
        }
           
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
