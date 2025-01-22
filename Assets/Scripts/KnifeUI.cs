using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeUI : MonoBehaviour
{

    [SerializeField] private Transform UIKnifeTemplate;
    [SerializeField] private List<Transform> Knives;
    public int knifeMax { get; private set; }

    private void ClearKnives()
    {
        foreach (Transform item in Knives)
        {
            Destroy(item.gameObject);
        }
        Knives.Clear();
    }

    public void UpdateKnivesMax(int max)
    {
        ClearKnives();
        this.knifeMax = max;
        for (int i = 0; i < knifeMax; i++)
        {
            Transform UIItem = Instantiate(UIKnifeTemplate);
            UIItem.SetParent(this.transform);
            UIItem.gameObject.SetActive(true);
            Knives.Add(UIItem);
        }
    }
   
    public void UpdateUI(int knifeUsed)
    {
        if (knifeUsed > knifeMax) { return; }
        for (int i = 0; i < knifeUsed; i++)
        {
            Knives[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }

}
