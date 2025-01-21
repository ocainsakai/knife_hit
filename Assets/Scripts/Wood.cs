using UnityEngine;

public class Wood : MonoBehaviour
{
    public float rotationSpeed;
    public int hitPoints;

    private bool rotatingRight = true;

    public void Init(float speed, int hp)
    {
        rotationSpeed = speed;
        hitPoints = hp;
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * (rotatingRight ? 1 : -1));
    }

    public void TakeDamage()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            GameManager.instance.LevelComplete();
        }
    }
}
