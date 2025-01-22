using System.Collections;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationLimit = 180f;
    public float changeIntervalMin = 1.5f;
    public float changeIntervalMax = 3.0f;
    //public float difficultyFactor = 1.0f;
    public Health woodHealth => GetComponent<Health>();
    [SerializeField] private Transform applePrefab => Resources.Load<Transform>("Prefabs/Apple");
    [SerializeField] private Transform knifePrefabs => Resources.Load<Transform>("Prefabs/knifePrefabs");

    private float currentSpeed;
    private float targetAngle;
    private int direction;
    private float radius = 2f;
    
    public void Init(float speed, int hp, int appleCount, int knifeCount)
    {
        rotationSpeed = speed;
        woodHealth.SetMaxHealth(hp);
        CreateItems(appleCount, knifeCount);
    }
    void Start()
    {
        StartCoroutine(ChangeRotation());
        woodHealth.OnDead += OnDead;

    }

    void Update()
    {
        // Xoay wood theo tốc độ hiện tại
        transform.Rotate(Vector3.forward, currentSpeed * Time.deltaTime);

        // Kiểm tra nếu đã đạt giới hạn góc quay thì dừng lại
        if (Mathf.Abs(transform.rotation.eulerAngles.z - targetAngle) < 1f)
        {
            currentSpeed = 0;
        }
    }

    IEnumerator ChangeRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(changeIntervalMin, changeIntervalMax));

            direction = (Random.value > 0.5f) ? 1 : -1;

            targetAngle = transform.rotation.eulerAngles.z + direction * Random.Range(30f, rotationLimit);

            currentSpeed = rotationSpeed * direction;
        }
    }
    private void CreateItems(int appleCount, int knifeCount)
    {
        // Spawn apples
        SpawnItems(applePrefab, appleCount, radius, 0);

        // Spawn knives
        SpawnItems(knifePrefabs, knifeCount, radius, 360 / (appleCount + knifeCount));
    }

    private void SpawnItems(Transform prefab, int count, float radius, float angleOffset)
    {
        float angleStep = 360f / count;  // Góc giữa mỗi vật thể

        for (int i = 0; i < count; i++)
        {
            float angle = i * angleStep + angleOffset;  // Góc quay từng item
            float radian = angle * Mathf.Deg2Rad;  // Chuyển độ sang radian

            // Tính toán vị trí theo công thức đường tròn
            float x = Mathf.Cos(radian) * radius;
            float y = Mathf.Sin(radian) * radius;

            // Tạo object trên đường tròn của wood
            Transform item = Instantiate(prefab, transform);
            item.localPosition = new Vector3(x, y, 0f);
            item.localRotation = Quaternion.Euler(0, 0, angle+90);
            item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            item.gameObject.SetActive(true);
        }
    }

    private void OnDead()
    {
        GameManager.instance.NextLevel();
    }
}
