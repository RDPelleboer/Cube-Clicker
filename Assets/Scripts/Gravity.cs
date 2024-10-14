using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            Physics2D.gravity = new Vector2(-9.8f, 0);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Physics2D.gravity = new Vector2(0, -9.8f);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Physics2D.gravity = new Vector2(9.8f, 0);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            Physics2D.gravity = new Vector2(0, 9.8f);
        }
    }
}
