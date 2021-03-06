﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    
    public static GameObject tooltipPrefab;
    public GameObject nostalgiaSprite, laughterSprite, fulfillmentSprite, friendshipSprite;
    public GameObject nostalgiaHolder, laughterHolder, fulfillmentHolder, friendshipHolder;


    //order is friendship nostaliga, laugher, full
    public void setToolTip( int nostaliga, int laughter, int friendship, int fulfillment )
    {
        foreach (Transform item in nostalgiaHolder.transform )
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in laughterHolder.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in fulfillmentHolder.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in friendshipHolder.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < nostaliga; i++)
        {
           var sprite = Instantiate(nostalgiaSprite) as GameObject;
           sprite.transform.parent = nostalgiaHolder.transform;
        }

        for (int i = 0; i < laughter; i++)
        {
            var sprite = Instantiate(laughterSprite) as GameObject;
            sprite.transform.parent = laughterHolder.transform;
        }

        for (int i = 0; i < friendship; i++)
        {
            var sprite = Instantiate(friendshipSprite) as GameObject;
            sprite.transform.SetParent(friendshipHolder.transform);
        }

        for (int i = 0; i < fulfillment; i++)
        {
            var sprite = Instantiate(fulfillmentSprite) as GameObject;
            sprite.transform.parent = fulfillmentHolder.transform;
        }


    }
	
}
