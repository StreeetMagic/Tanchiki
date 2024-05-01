using UnityEngine;

public class TankController : MonoBehaviour
{
    public Move mover;
    public Fire fire;

    private int state = 0;
    private float horizontalInput = 0;
    private void Start()
    {
        EnemyGeneral.Instance.SetPlayerTank(this);
    }
    private void Update()
    {
        if (Input.GetKey("up"))
        {
            state = 1;
        }
        else if (Input.GetKey("down"))
        {
            state = -1;
        }
        else
        {
            state = 0;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            fire.Launch();
        }
    }
    private void FixedUpdate()
    {
        Debug.Log(transform.position);

        mover.Forward(state);

        if (horizontalInput != 0)
        {
            mover.Rotate(horizontalInput);
        }
    }
}
