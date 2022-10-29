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
        if(currentCharacterIndex == CharacterModels.Length)
        {
            currentCharacterIndex = 0;
        }
        CharacterModels[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);
    }

    public void ChangePrevoues()
    {
        CharacterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex --;
        if(currentCharacterIndex == -1)
        {
            currentCharacterIndex = CharacterModels.Length -1;
        }
        CharacterModels[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);
    }
}
