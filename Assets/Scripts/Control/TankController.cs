using UnityEngine;

public class TankController : MonoBehaviour
{
    public Move mover;
    public Fire fire;

    private int state = 0;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    
    private void Start()
    {
        EnemyGeneral.Instance.SetPlayerTank(this);
    }
    private void Update()
    {
         verticalInput = Input.GetAxis("Vertical");
         
         if (verticalInput > 0)
         {
             state = 1;
         }
         else if (verticalInput < 0)
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
