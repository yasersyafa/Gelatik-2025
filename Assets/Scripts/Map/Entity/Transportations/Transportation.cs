using UnityEngine;

[CreateAssetMenu(fileName = "NewTransportation", menuName = "Entity/Transportation")]
public class Transportation : ScriptableObject
{
    public string transportationName;
    public string description;
    public int price;
    [Range(0, 1)]
    public float speed;
    public Sprite icon;
}
