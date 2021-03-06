using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    [Header( "- Character" )]

    public float TargetingRange = 50.0f;

    [HideInInspector]
    public Actor currentTarget;

    public StatusFloat MoveBlockingTime;

    #region UnityEvent

    protected virtual void Update()
    {
        MoveBlockingTime.current -= Time.deltaTime;
    }

    #endregion

    public virtual bool IsTargeting()
    {
        return currentTarget != null;
    }

    public override void AddActorForce( Vector3 force, EForceType forceType )
    {
        MoveBlockingTime.Reset();
        base.AddActorForce( force, forceType );
    }
}
