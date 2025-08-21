using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SpecialNPCData", menuName = "Scriptable Objects/SpecialNPCData")]
public class SpecialNPCData : ScriptableObject
{
    public string specialName;
    [TextArea] public string firstImpression;
    public int currencyReward;
    public int likeMeter = 50; // Starts at 50, can go up to 100 or down to 0
    public Sprite image;
    public Sprite sprite;
}
