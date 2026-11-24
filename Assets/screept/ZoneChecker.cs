using System.Collections.Generic;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [SerializeField] private RectTransform zone;
    [SerializeField] private List<RectTransform> requiredWords;
    [SerializeField] private List<RectTransform> forbiddenWords;
    public GameManager manager;


    public void CheckWords()
    {
        manager.IsCompleteW = true;

        foreach (var w in requiredWords)
            if (!IsInside(w)) manager.IsCompleteW = false;

        foreach (var w in forbiddenWords)
            if (IsInside(w)) manager.IsCompleteW = false;
    }

    private bool IsInside(RectTransform word)
    {
        Vector3 local = zone.InverseTransformPoint(word.TransformPoint(word.rect.center));
        return zone.rect.Contains(local);
    }
}