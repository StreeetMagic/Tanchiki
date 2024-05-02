using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    [SerializeField] private Fire fire;
    [SerializeField] private Observer observer;
    [SerializeField] private AI ai;
    
    private Transform playerPos;
    
    void Start()
    {
        EnemyGeneral.Instance.SetTankToSquad(this);
    }

    private void FixedUpdate()
    {
        if (ai.isNear)
        {
            playerPos = EnemyGeneral.Instance.GetPlayer();

            if (observer.LaunchRay())
            {
                ai.state = States.ATTACKING;
            }
            else
            {
                ai.TargetIsMissing(playerPos );
            }
        }
    }
}
