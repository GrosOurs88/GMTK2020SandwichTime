using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsSpawner : MonoBehaviour
{
    public GameObject iconPrefab;
    public float iconSpawnDelay = 0.2f;

    private float timeSinceLastSpawn;
    private List<Sprite> IconToSpawnQueue;

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
        Vector3 pos = new Vector3(Random.Range(-50f, 50f), 0f, 0f);
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

                    break;
                }
            case IconType.Audience:
                {
                    sprite = Resources.Load<Sprite>("Icons/Audience_" + amount.ToString());

                    break;
                }
        }
        
        for (int i = amount; i>0; i--)
        {
            IconToSpawnQueue.Add(sprite);
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