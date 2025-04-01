using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    [SerializeField] private float moveSpeed;
    public Loot droppedItem;
    public GameObject lootGameObject;

    public int points;

    public Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0 )
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)]; //drops randome of eligible - this is where i pick to do the rarest
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        droppedItem = GetDroppedItem();
        if(droppedItem != null )
        {
            lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            //tag object to identify
            if(droppedItem.lootName == "Ring")
            {
                lootGameObject.tag = "Ring";
                points = 12;
            }
                
            if (droppedItem.lootName == "Coin")
                lootGameObject.tag = "Coin";
        }
    }
}
