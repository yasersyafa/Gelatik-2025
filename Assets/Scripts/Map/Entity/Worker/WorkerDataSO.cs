using UnityEngine;

[CreateAssetMenu(fileName = "NewWorker", menuName = "Entity/Worker")]
public class WorkerDataSO : ScriptableObject
{
    [Header("Worker Attributes")]
    public Sprite workerSprite;
    public Sprite workerIcon;

    [Header("Worker Stats")]
    public string workerName; // Will be set to ScriptableObject's name
    public int age;

    [Tooltip("Defines the minimum and maximum possible age")]
    public Vector2Int ageRange = new Vector2Int(18, 60); // Default: min 18, max 60

    public float movementSpeed;
    public bool isInitialized;

    [Header("Worker Animation")]
    public ScriptableObject animationSO; // Another ScriptableObject

    private void OnEnable()
    {
        workerName = this.name; // Automatically set to the ScriptableObject's name

        if (!isInitialized)
        {
            RandomizeAge();
            isInitialized = true;
        }
    }

    /// <summary>
    /// Randomizes the age based on the defined age range.
    /// </summary>
    public void RandomizeAge()
    {
        age = Random.Range(ageRange.x, ageRange.y + 1);
    }
}

public enum RarityType
{
    Common,
    Uncommon,
    Epic
}
