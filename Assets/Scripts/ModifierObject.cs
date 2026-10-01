using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ModiferObject", menuName = "ScriptableObj/Modifiers")]
public class ModifierObject : ScriptableObject
{
    public Sprite sprite;
    public string nameText = "";
    public string descriptionText = "";
    public string mod = "";
}
