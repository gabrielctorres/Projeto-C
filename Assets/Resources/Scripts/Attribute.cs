using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attribute", menuName = "SO/Attribute", order = 1)]
public class Attribute : ScriptableObject
{
    [Header("Informacoes Base")]
    public float valueBase;
    public float valueMax;
    [Header("Outros")]
    // public float valueTotalMax;
    public float valueTotal;
    public List<float> modiferList = new List<float>();

    public void AddModifier(float modifier)
    {
        modiferList.Add(modifier);
        CalculateModifer();
    }

    public void RemoveModifier(float modifier)
    {
        if (modiferList.Contains(modifier))
        {
            modiferList.Remove(modifier);
            CalculateModifer();
        }
    }

    public void CalculateModifer()
    {
        if (valueTotal < valueMax)
        {
            float totalModifer = 0;
            for (int i = 0; i < modiferList.Count; i++)
            {
                totalModifer += modiferList[i];
            }
            valueTotal = valueBase + totalModifer;
        }

    }

    public void ResetTotalValue()
    {
        valueTotal = 0f;
        modiferList.Clear();
    }
}
