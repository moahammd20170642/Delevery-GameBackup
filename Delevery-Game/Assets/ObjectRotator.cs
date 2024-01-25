using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 45f; // Adjust this value to control rotation speed
    public float moveSpeed = 1f; // Adjust this value to control movement speed
    public float maxHeight = 5f; // Adjust this value to set the maximum height of the arrow

    private bool movingUp = true;

    void Update()
    {
        // Rotate the arrow smoothly around the Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Move the arrow up and down smoothly along the Y-axis
        float newY = transform.position.y + (movingUp ? 1 : -1) * moveSpeed * Time.deltaTime;
        newY = Mathf.Clamp(newY,3, maxHeight); // Clamp the position to stay within a certain range
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Change direction when reaching the maxHeight or the bottom
        if (newY >= maxHeight || newY <= 3)
        {
            movingUp = !movingUp;
        }
    }
}