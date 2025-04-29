using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public GameObject[] chests;  // List of chests
    public GameObject[] items;   // List of items to be placed inside the chests

    void Start()
    {
        // Assign random items to chests when the game starts
        AssignItemsToChests();
    }

    void AssignItemsToChests()
    {
        // List to keep track of the items we need to assign
        List<GameObject> itemsToAssign = new List<GameObject>(items);

        // Loop through each chest
        foreach (GameObject chest in chests)
        {
            // Disable all items inside the chest first
            foreach (Transform child in chest.transform)
            {
                child.gameObject.SetActive(false);
            }

            // Pick a random item from the available items
            int randomItemIndex = Random.Range(0, itemsToAssign.Count);

            // Check if the chosen item is the "empty" item (the last item in the array)
            if (itemsToAssign[randomItemIndex] == items[items.Length - 1]) // Assuming the last item is "empty"
            {
                // If it's the "empty" item, place the "empty" inside the chest
                Instantiate(items[items.Length - 1], chest.transform.position, Quaternion.identity, chest.transform);
            }
            else
            {
                // If it's not the "empty" item, place the chosen item inside the chest
                Instantiate(itemsToAssign[randomItemIndex], chest.transform.position, Quaternion.identity, chest.transform);
            }

            // Remove the assigned item from the list to avoid reusing it
            itemsToAssign.RemoveAt(randomItemIndex);
        }
    }
}
