using UnityEngine;
using GabrielBigardi.SpriteAnimator;

public class WorkerDataObject : MonoBehaviour
{
    [Header("Worker Data Reference")]
    public WorkerDataSO workerDataSO; // Reference to WorkerData

    [Header("Worker Attributes")]
    public Sprite workerSprite;
    public Sprite workerIcon;
    public string transportation;

    [Header("Worker Stats")]
    public string workerName;
    public int age;
    public RarityType rarity;
    public int hireRate;
    public int payRate;
    public int efficiency;
    public float movementSpeed;

    [Header("Worker Animation")]
    public SpriteAnimationObject animationSO;
    public SpriteAnimator spriteAnimator; // Reference to SpriteAnimator

    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    private void Start()
    {
        // Get the SpriteAnimator and SpriteRenderer components
        spriteAnimator = GetComponent<SpriteAnimator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load a random WorkerData from Resources
        LoadRandomWorkerData();
    }

    private void LoadRandomWorkerData()
    {
        WorkerDataSO[] allWorkers = Resources.LoadAll<WorkerDataSO>("WorkerData");

        if (allWorkers.Length > 0)
        {
            workerDataSO = allWorkers[Random.Range(0, allWorkers.Length)];
            AssignData(workerDataSO);
            SetStats();
        }
        else
        {
            Debug.LogError("No WorkerData found in Resources/WorkerData");
        }
    }

    public void AssignData(WorkerDataSO data)
    {
        if (data == null) return;

        workerSprite = data.workerSprite;
        workerIcon = data.workerIcon;
        workerName = data.workerName;
        age = data.age;
        movementSpeed = data.movementSpeed;
        animationSO = data.animationSO as SpriteAnimationObject;

        if (spriteRenderer != null && workerSprite != null)
        {
            spriteRenderer.sprite = workerSprite;
        }

        if (spriteAnimator != null && animationSO != null)
        {
            spriteAnimator.ChangeAnimationObject(animationSO);
        }
    }

    public void SetStats()
    {
        rarity = GetRandomRarity(); // Use weighted chance to determine rarity

        switch (rarity)
        {
            case RarityType.Common:
                hireRate = RoundToNearest(Random.Range(200, 500), 10);
                payRate = RoundToNearest(Random.Range(30, 50), 5);
                efficiency = Random.Range(10, 30);
                break;

            case RarityType.Uncommon:
                hireRate = RoundToNearest(Random.Range(300, 700), 10);
                payRate = RoundToNearest(Random.Range(40, 60), 5);
                efficiency = Random.Range(20, 70);
                break;

            case RarityType.Epic:
                hireRate = RoundToNearest(Random.Range(500, 1000), 10);
                payRate = RoundToNearest(Random.Range(50, 70), 5);
                efficiency = Random.Range(50, 90);
                break;
        }
    }

    private RarityType GetRandomRarity()
    {
        int roll = Random.Range(1, 101); // Random number from 1 to 100

        if (roll <= 60)
            return RarityType.Common;
        else if (roll <= 95) // 60 (Common) + 35 (Uncommon)
            return RarityType.Uncommon;
        else
            return RarityType.Epic; // 5% chance for Epic
    }

    private int RoundToNearest(int value, int multiple)
    {
        return Mathf.RoundToInt(value / (float)multiple) * multiple;
    }
}
