using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingTele : MonoBehaviour
{

    [Header("Keybinds")]
    public KeyCode interaction = KeyCode.E;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(interaction))
        {
            player.position = new Vector3(2, 2, 2);
        }
    }
}
