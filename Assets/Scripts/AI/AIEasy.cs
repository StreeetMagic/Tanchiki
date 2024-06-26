﻿public class AIEasy : AI
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
      state = States.MOVING;
    }
  }
}