using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AI : MonoBehaviour
{
    public States state;
    [SerializeField]
    private AIDestinationSetter aIDestination;
    [SerializeField]
    private AIPath aIPath;
    private int countOfPoints;
    public Transform LastPlayerPosition;
    public bool isNear = false;
    void Start()
    {
        state = States.STOPING;
        countOfPoints = PointManager.Instance.points.Count;
    }

    void Update()
    {
        if (state == States.STOPING)
        {
            SetTarget();

            CheckPlayerDestination();
        }

        else if (state == States.MOVING)
        {
            CheckPlayerDestination();
            ReachPoint();
        }
        else if (state == States.TARGETING)
        {

        }
    }
    private void CheckPlayerDestination()
    {
        isNear = Vector3.Distance(transform.position, EnemyGeneral.Instance.GetPlayer().position) <= 5;
    }

    private void ReachPoint()
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
            Debug.Log(pos);
        }
        Debug.Log(1);
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
