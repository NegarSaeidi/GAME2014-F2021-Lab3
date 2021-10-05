using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    [Header("playerMovement")]
    public float horizontalForce;
    public Bounds bounds;
    [Range(0.0f,0.99f)]
    public float decay;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        body.AddForce(new Vector2(x*horizontalForce,0.0f));
        body.velocity *= (1-decay);
        checkBounds();
    }
    private void checkBounds()
    {
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }

        // right bounds
        if (transform.position.x > bounds.max)
        { 
          transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
