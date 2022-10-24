using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex = 0;
    public GameObject[] CharacterModels;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach(GameObject Character in CharacterModels)
        {
            Character.SetActive(false);
        }

        CharacterModels[currentCharacterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeNext()
    {
        CharacterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex ++;
        if(currentCharacterIndex > 2)
        {
            currentCharacterIndex = 0;
        }
        CharacterModels[currentCharacterIndex].
    }
}
