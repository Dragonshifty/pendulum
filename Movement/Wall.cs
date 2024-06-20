using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Vector2 startingPosition;

    private void Start() {
        startingPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("wall"))
        {
            transform.position = startingPosition;
        }
    }
}
