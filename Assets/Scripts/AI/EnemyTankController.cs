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
        if (!ai.isNear) 
            return;
        
        playerPos = EnemyGeneral.Instance.GetPlayer();
        
        if (observer.LaunchRay())
        {
            ai.state = States.TARGETING;
            ai.SetTarget(playerPos);
        }

        if (ai.state == States.TARGETING)
        {
            if (observer.LaunchRay())
            {
                ai.state = States.TARGETING;
            }
            else
            {
                ai.state = States.STOPING;
                ai.TargetIsMissing(playerPos);
            }
        }
    }
}
