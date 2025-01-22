using UnityEngine;

public class Apple : MonoBehaviour
{
    public Health health => GetComponent<Health>();

    private void Start()
    {
        health.OnDead += Health_OnDead;
    }

    private void Health_OnDead()
    {
        
    }
}
