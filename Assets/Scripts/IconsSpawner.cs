using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsSpawner : MonoBehaviour
{
    public GameObject iconPrefab;
    public float iconSpawnDelay = 0.2f;
    public RectTransform[] iconSpawnPositions;

    private RectTransform lastIconSpawnPosition;

    private float timeSinceLastSpawn;
    private List<Sprite> IconToSpawnQueue;

    private void Awake()
    {
        IconToSpawnQueue = new List<Sprite>();

        //DEBUG
        QueueIconSpawn(IconType.Budget, 4);
        QueueIconSpawn(IconType.Appeal, 2);
        QueueIconSpawn(IconType.Audience, 7);
    }

    private void Update()
    {
        if (IconToSpawnQueue.Count > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn > iconSpawnDelay)
            {
                timeSinceLastSpawn -= iconSpawnDelay;

                SpawnIcon(IconToSpawnQueue[0]);
                IconToSpawnQueue.RemoveAt(0);

                if (IconToSpawnQueue.Count == 0)
                {
                    timeSinceLastSpawn = iconSpawnDelay;
                }
            }
        }
    }
    
    private void SpawnIcon(Sprite sprite)
    {
        RectTransform spawn_rect = iconSpawnPositions[Random.Range(0, iconSpawnPositions.Length)];
        if (spawn_rect == lastIconSpawnPosition)
        {
            spawn_rect = iconSpawnPositions[Random.Range(0, iconSpawnPositions.Length)];
        }
        lastIconSpawnPosition = spawn_rect;

        Vector3 pos = iconSpawnPositions[Random.Range(0, iconSpawnPositions.Length)].position;

        Instantiate(iconPrefab, pos, Quaternion.identity, transform).GetComponent<Icon>().image.sprite = sprite;
    }

    public void QueueIconSpawn(Theme theme)
    {
        Sprite sprite = Resources.Load<Sprite>("Icons/" + theme.ToString());
        IconToSpawnQueue.Add(sprite);
    }
    public void QueueIconSpawn(IconType type, int amount)
    {
        Sprite sprite =null;

        switch (type)
        {
            case IconType.Budget:
                {
                    if (amount > 0)
                    {
                        sprite = Resources.Load<Sprite>("Icons/Budget");
                    }
                    else
                    {
                        sprite = Resources.Load<Sprite>("Icons/BudgetDown");
                    }

                    for (int i = amount; i > 0; i--)
                    {
                        IconToSpawnQueue.Add(sprite);
                    }
                    break;
                }
            case IconType.Appeal:
                {
                    if (amount > 0)
                    {
                        sprite = Resources.Load<Sprite>("Icons/Appeal");
                    }
                    else
                    {
                        sprite = Resources.Load<Sprite>("Icons/AppealDown");
                    }

                    for (int i = amount; i > 0; i--)
                    {
                        IconToSpawnQueue.Add(sprite);
                    }
                    break;
                }
            case IconType.Audience:
                {
                    sprite = Resources.Load<Sprite>("Icons/Audience_" + amount.ToString());
                    IconToSpawnQueue.Add(sprite);

                    break;
                }
        }
        
    }

}

public enum IconType
{
    Theme,
    Budget,
    Appeal,
    Audience
}