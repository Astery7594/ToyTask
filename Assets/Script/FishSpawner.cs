using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;
    public List<Sprite> fishSprites = new List<Sprite>(); //list used to change fish's image
    public int maxFishNum = 10; // maximased spawned fish's number
    private int currentFishNum = 0; //current number
    private List<GameObject> fishList = new List<GameObject>(); //store spawned objects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFish() //use button to contral spawn fish
    {
        if(currentFishNum >= maxFishNum)
        {
            //make sure that fish num won't exceed the maximum limit
            return;
        }

        Vector2 fishP = GetRandomP(); //a functiom to get random position in screen
        
        GameObject newFish = Instantiate(fish,fishP,Quaternion.identity); // spawn fish object (though prefab)

        //Give fish random fish images
        SpriteRenderer spriteRenderer = newFish.GetComponent<SpriteRenderer>(); //get sprite image
        if (spriteRenderer != null && fishSprites.Count >0) //when there's sprite in the list
        {
            Sprite rSprite = fishSprites[Random.Range(0,fishSprites.Count-1)]; //random those a image
            spriteRenderer.sprite = rSprite; //thorw it in the object
        }

        fishList.Add(newFish); //add new spawned object in a list
        currentFishNum++; // write down how many fish that spwan

    }
     public Vector2 GetRandomP()
    {
        //make fish ramdom spawned in screen.
        Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(5,Screen.width), Random.Range(5,Screen.height-15f)));
        return p;
    }

    public void ClearAllFish() //destory all spawned fish object with a button
    {
        for(int i = 0; i < fishList.Count; i++) //Delete objects in the list one by one
        {
            if (fishList[i] != null)
            {
                Destroy(fishList[i]);//destory all fish object
            }
        }
        currentFishNum = 0; //reset
    }

}
