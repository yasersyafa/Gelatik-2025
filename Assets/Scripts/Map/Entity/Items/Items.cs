using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Item", fileName = "NewItem")]
public class Items : ScriptableObject
{
    public string itemName;
    public string description;
    public int price;
    public string ability;
    public Sprite icon;
}
