public class AIHard : AI
{
  protected override void Operate()
  {
    CheckPlayerDestination();
        
    if (state == States.STOPING)
    {
      SetTarget();
    }
    else if (state == States.MOVING)
    {
      ReachPoint();
    }
    else if (state == States.TARGETING)
    {
      if (observer.LaunchRay())
      {
        state = States.ATTACKING;
      }
      else
      {
        TargetIsMissing(LastPlayerPosition);
      }
    }
    else if (state == States.ATTACKING)
    {
      fire.Launch();
    }
  }
}