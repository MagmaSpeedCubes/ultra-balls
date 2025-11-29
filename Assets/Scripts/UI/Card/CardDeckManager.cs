using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardDeckManager : MonoBehaviour
{
    [SerializeField] private Vector2 beginPosition;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Ball[] ballPrefabs;
    [SerializeField] private GameObject cardParent;
    [SerializeField] private float separationDistance;
    
    [SerializeField] private int cardsPerRow;



    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        if(cardsPerRow <= 0)
        {
            throw new ArithmeticException("Cards per row needs to be positive");
        }

        for(int i=0; i<ballPrefabs.Length; i++)
        {
            Debug.Log("Creating new card");
            RectTransform prefabRect = cardPrefab.GetComponent<RectTransform>();
            Vector2 offset = new Vector2(
                (i % cardsPerRow) * (prefabRect.rect.width + separationDistance),
                (i / cardsPerRow) * (prefabRect.rect.height + separationDistance)
            );
            
            Vector2 spawnPosition = new Vector2(beginPosition.x + offset.x, beginPosition.y + offset.y);

            GameObject newCard = Instantiate(cardPrefab, spawnPosition, Quaternion.identity);
            RectTransform newCardRect = newCard.GetComponent<RectTransform>();
            newCardRect.parent = cardParent.GetComponent<RectTransform>();
            CardManager cm = newCard.GetComponent<CardManager>();
            cm.subject = ballPrefabs[i];
            Debug.Log("New card created");
        }
        Debug.Log("Created " + ballPrefabs.Length + " cards");
    }

    void SortByName(bool ascending)
    {
        
    }

    void SortByCost(bool ascending)
    {
        
    }

    void SortByRarity(bool ascending)
    {
        
    }


}
