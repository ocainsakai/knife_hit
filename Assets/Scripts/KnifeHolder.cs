using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class KnifeHolder : MonoBehaviour
{
    [SerializeField] private Transform knifePrefabs => Resources.Load<Transform>("Prefabs/knifePrefabs");
    [SerializeField] private List<Transform> knifeUsed;
    public bool isProcessing;
    public async void Fire()
    {
        isProcessing = true;

        Transform item = Instantiate(knifePrefabs, transform);
        item.gameObject.SetActive(true);
        item.GetComponent<Knife>().SetSpeed();
        knifeUsed.Add(item);

        Knife lastKnife = item.GetComponent<Knife>();
        var taskCompletionSource = new TaskCompletionSource<bool>();

        lastKnife.OnKnifeHitWood += () => taskCompletionSource.SetResult(true);
        await taskCompletionSource.Task;
        isProcessing = false;

    }
  
}
