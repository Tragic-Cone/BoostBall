using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class LaserBeam : MonoBehaviour
{
    private PolygonCollider2D collider;
    private SpriteRenderer z;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        z = GetComponent<SpriteRenderer>();
        collider.enabled = !collider.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (z.sprite.name == "beam_12")
        {
            collider.enabled = !collider.enabled;
        }
    }

}
