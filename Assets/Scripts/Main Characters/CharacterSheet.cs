using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static StatsSO;

public class CharacterSheet : MonoBehaviour
{
    [SerializeField] string characterName;
    public bool isCurrentChosenChar;

    [SerializeField] StatsSO statsSO;

    public List<Stat> statsList = new List<Stat>();

    private void Start()
    {
        foreach (Stat stat in statsSO.statsDict.Values)
        {
            statsList.Add(stat);
        }
    }

    public float GetStat(Stat stat)
    {
        if (statsSO.statsDict.TryGetValue(stat, out float value))
        {
            return value;
        }
        else
        {
            Debug.LogError($"No stat value found for {stat} on {this.name}");
            return 0f;
        }
    }

    public void SetStat(Stat stat, float value)
    {
        if (statsSO.statsDict.ContainsKey(stat))
        {
            statsSO.statsDict[stat] = value;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
    }
}
