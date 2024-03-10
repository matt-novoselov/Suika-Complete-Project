using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Array of fruit prefabs that can be spawned
    public GameObject[] FruitPrefabs;

    // Update is called once per frame
    void Update()
    {
        // Check if there's any touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch detected
            Touch touch = Input.GetTouch(0);

            // Check if the touch has ended
            if (touch.phase == TouchPhase.Ended)
            {
                // Translate the touch position from screen space to world space coordinates
                Vector2 translatedTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Choose a random index within the range of FruitPrefabs array
                int randomIndex = Random.Range(0, FruitPrefabs.Length);

                // Instantiate a fruit prefab at the translated touch position with no rotation
                Instantiate(FruitPrefabs[randomIndex], translatedTouchPosition, Quaternion.identity);
            }
        }
    }
}
