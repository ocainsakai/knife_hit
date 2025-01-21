using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class KnifeHolder : MonoBehaviour
{
    [SerializeField] private Transform knifePrefabs => Resources.Load<Transform>("Prefabs/knifePrefabs");
    [SerializeField] private List<Transform> knifeUsed;
    public bool isProcessing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    public void DestroyKnives()
    {
        for (int i = 0; i < knifeUsed.Count; i++)
        {
           Destroy(knifeUsed[i].gameObject);
           //knifeUsed.RemoveAt(i);
        }
        knifeUsed.Clear();
        Debug.Log("newlv");
    }
    public async void Fire()
    {
        isProcessing = true;

        Transform item = Instantiate(knifePrefabs, transform);
        item.gameObject.SetActive(true);
        knifeUsed.Add(item);

        Knife lastKnife = item.GetComponent<Knife>();
        var taskCompletionSource = new TaskCompletionSource<bool>();

        lastKnife.OnKnifeHitWood += () => taskCompletionSource.SetResult(true);
        await taskCompletionSource.Task;
        isProcessing = false;

    }
  
}
