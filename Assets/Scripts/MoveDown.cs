using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Vector2 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector2 newPosition;
    public float speed = .002f;
    /// <summary>The maximum distance the object may move in either y direction.</summary>
    private int maxDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.y = newPosition.y - speed;//(maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;
    }
}
