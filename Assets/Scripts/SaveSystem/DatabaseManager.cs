using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    // public List<T> workers;
    public List<Transportation> transportations;
    public List<Items> items;

    public Transportation GetTransportation(string name)
    {
        return transportations.Find(t => t.name == name);
    }

    public Items GetItems(string name)
    {
        return items.Find(i => i.name == name);
    }
}
