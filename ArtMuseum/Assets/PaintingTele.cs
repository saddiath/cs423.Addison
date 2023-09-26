using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingTele : MonoBehaviour
{

    [Header("Keybinds")]
    public KeyCode interaction = KeyCode.E;

    public Transform painting1;
    public Transform painting2;
    public Transform painting3;
    public Transform painting4;


    private Transform pos;

    public List<Transform> list = new List<Transform>();

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        list.Add(painting1);
        list.Add(painting2);
        list.Add(painting3);
        list.Add(painting4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(interaction))
        {
            pos = list[Random.Range(0, 3)];
            player.position = new Vector3(pos.position.x, pos.position.y, pos.position.z);
        }
    }
}
