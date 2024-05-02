using Pathfinding;
using UnityEngine;

public abstract class AI : MonoBehaviour
{
    public States state;
    public Transform LastPlayerPosition;
    
    [SerializeField] private AIDestinationSetter aIDestination;
    [SerializeField] private AIPath aIPath;
    [SerializeField] protected Fire fire;
    [SerializeField] protected Observer observer;
    
    private int countOfPoints;
    public bool isNear = false;
    
    void Start()
    {
        state = States.STOPING;
        countOfPoints = PointManager.Instance.points.Count;
    }

    void Update()
    {
        Operate();
    }

    protected abstract void Operate();

    protected void CheckPlayerDestination()
    {
        if (EnemyGeneral.Instance.GetPlayer() == null)
        {
            return;
        }
        
        isNear = Vector3.Distance(transform.position, EnemyGeneral.Instance.GetPlayer().position) <= 5;
    }

    protected void ReachPoint()
    {
        if (aIPath.reachedDestination)
        {
            state = States.STOPING;
        }
    }

    public void SetTarget(Transform pos = null)
    {
        if (pos == null)
        {
            pos = PointManager.Instance.points[Random.Range(0, countOfPoints)];
        }
        
        LastPlayerPosition.position = pos.position;
        aIDestination.target = LastPlayerPosition;
        state = States.MOVING;
    }
    
    public void TargetIsMissing(Transform lastPos)
    {
        SetTarget(lastPos);

        state = States.MOVING;
    }
}