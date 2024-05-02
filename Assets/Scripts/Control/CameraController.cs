using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    //  public Camera MainCamera;

    public float dumping = 0.5f;
    public Vector2 offset = new Vector2(2f, 2f);
    private Vector3 target;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            return;
        }
        
        target = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
    }
}
