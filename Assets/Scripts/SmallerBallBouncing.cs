using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerBallBouncing : Bouncing
{
    protected override void SetProperties()
    {
        direction = new Vector3(-0.1f, 1.0f, 0f);
        dampingFactor = 0.95f;
    }
}
