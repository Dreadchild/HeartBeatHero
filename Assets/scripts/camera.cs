using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    // Use this for initialization
    void Start()
    {
        //offset = new Vector3(0, 0, -1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y + offset.y, player.position.z + offset.z);
    }
}
