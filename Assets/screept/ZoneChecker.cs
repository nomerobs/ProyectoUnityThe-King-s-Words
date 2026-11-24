using System.Collections.Generic;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [SerializeField] private RectTransform zone;
    [SerializeField] private List<RectTransform> requiredWords;
    [SerializeField] private List<RectTransform> forbiddenWords;
    public LetterCatch letter;


    public void CheckWords()
    {
        letter.good = true;

        foreach (var w in requiredWords)
            if (!IsInside(w)) letter.good = false;

        foreach (var w in forbiddenWords)
            if (IsInside(w)) letter.good = false;
    }

    private bool IsInside(RectTransform word)
    {
        Vector3 local = zone.InverseTransformPoint(word.TransformPoint(word.rect.center));
        return zone.rect.Contains(local);
    }
}