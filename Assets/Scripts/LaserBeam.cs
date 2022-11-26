using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CadeBreedlove
public class LaserBeam : MonoBehaviour
{
    private PolygonCollider2D pCollider;
    private SpriteRenderer z;
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        pCollider = GetComponent<PolygonCollider2D>();
        z = GetComponent<SpriteRenderer>();
        pCollider.enabled = !pCollider.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (z.sprite.name == "beam_12" && x == 0)
        {
            pCollider.enabled = !pCollider.enabled;
            x += 1;
        }
        if (z.sprite.name == "None (Sprite)")
        {
            pCollider.enabled = !pCollider.enabled;
        }
        x = 0;
    }

}
