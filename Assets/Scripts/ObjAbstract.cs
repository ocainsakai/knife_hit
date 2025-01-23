using UnityEngine;

public abstract class ObjAbstract : MonoBehaviour
{
    protected Rigidbody2D _rb => GetComponent<Rigidbody2D>();

    public abstract void SetTag();
    
}
