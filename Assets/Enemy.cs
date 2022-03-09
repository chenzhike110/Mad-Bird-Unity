using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.GetComponent<Bird>() != null) {
            Destroy(gameObject);
            return;
        }
        if (other.collider.GetComponent<Enemy>() != null) {
            return;
        }
        if (other.contacts[0].normal.y < -0.5) {
            Destroy(gameObject);
        }
    }
}
