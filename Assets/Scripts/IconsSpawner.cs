using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsSpawner : MonoBehaviour
{
    public RoomController roomController;
    public GameObject iconPrefab;
    public float iconSpawnDelay = 0.2f;
    public RectTransform[] iconSpawnPositions;

    private RectTransform lastIconSpawnPosition;

    private float timeSinceLastSpawn;
    private List<Sprite> IconToSpawnQueue;

    private void Awake()
    {
        IconToSpawnQueue = new List<Sprite>();
        roomController.IdeaSelected += OnIdeaSelected;
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

    private void OnIdeaSelected( Idea idea )
    {
        QueueIconSpawn(IconType.Budget, idea.budgetChange);
        QueueIconSpawn(IconType.Appeal, idea.appealing);
        QueueIconSpawn(IconType.Audience, idea.pegi);

        foreach (Theme theme in idea.themes)
        {
            QueueIconSpawn(theme);
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
                    if (amount == 0)
                    {
                        return;
                    }
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