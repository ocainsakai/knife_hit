using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDots : MonoBehaviour
{
    [SerializeField] List<Transform> dots;


    private void Awake()
    {
        foreach (Transform item in this.transform)
        {
            dots.Add(item);
        }
    }
    public void UpdateUI(int used)
    {
        int dotCount = (used % 5) + 1;
        ClearDots();
        for (int i = 0; i < dotCount; i++)
        {
            dots[i].GetComponent<Image>().color = Color.yellow;
        }
    }
    private void ClearDots()
    {
        for (int i = 0; i < 5; i++)
        {
            dots[i].GetComponent<Image>().color = Color.gray;
        }
    }
}
