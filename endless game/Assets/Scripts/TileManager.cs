using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zspawn = 0; // where the tile will spawn on the z position
        public int Tilelength = 30; // how long a tile is
    public int numberoftiles = 5;// how many tiles that CAN be on the screen at the same time
    // Start is called before the first frame update
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
        for(int i = 0; i < numberoftiles; i++)// parts of a for loop(thing that happends one time(created a variable and set value), condition, thing that happens over and over after condition is met(i++)
        {
            
            if(i == 0)
            {
                SpawnTile(0);//spawns the first tile if the numberoftiles i =0. if not then it will spawn a random tile from code below.
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));//calls the spawntile function and spawns a random tile from the tileprefabs
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zspawn - (numberoftiles * Tilelength))// if the z position of the player -35 is greater than the things on the right then it will do the stuff inside the body
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));//spawn a random tile 
            DeleteTile();// this code calls the deletetile function
        }

    }
    public void SpawnTile( int TileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[TileIndex], transform.forward * zspawn, transform.rotation);// this code instantiates(creates) a new tile from the tileprefab by accessing its index and creates forward multiplies by the zspawn,no rotation
        //^ created new gameobject to access in the activetiles variable to be able to delete the first tile.
        activeTiles.Add(go);//addingt the go variable ( which will be the new tile because of the code above) to the activetiles
        zspawn += Tilelength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);//destroying the first tile
        activeTiles.RemoveAt(0);//removing the first tile from the hierchy/ the whole game
    }
}



