using UnityEngine;

public class Apple : ObjAbstract
{
    public Health health => GetComponent<Health>();
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Knife")
        health.TakeDame();
    }
    private void Start()
    {
        health.OnDead += Health_OnDead;
    }

    private void Health_OnDead()
    {
        Debug.Log("add apple");
        gameObject.SetActive(false);
        Destroy(gameObject);
        // increase apple you get
    }

    public override void SetTag()
    {
        this.gameObject.tag = "Untagged";
    }
}
