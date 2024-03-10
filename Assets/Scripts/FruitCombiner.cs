using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCombiner : MonoBehaviour
{
    // Bool to check if this object has already collided
    public bool HasCollided = false;

    // The prefab to spawn after combining
    public GameObject FruitToSpawnAfterCombining;

    // This function is called when a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding objects have the same name
        if (collision.gameObject.name != gameObject.name)
        {
            return;
        }

        // Check if this object has already collided
        if (HasCollided)
        {
            return;
        }

        // Get the FruitCombiner script of the colliding object
        var OtherFruitCombinerScript = collision.gameObject.GetComponent<FruitCombiner>();

        // Set the collision flag for both objects to true to prevent further collisions detections
        HasCollided = true;
        OtherFruitCombinerScript.HasCollided = true;

        // Spawn the prefab after combining at the position of this object
        Instantiate(FruitToSpawnAfterCombining, gameObject.transform.position, Quaternion.identity);

        // Destroy both the colliding object and this object
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
