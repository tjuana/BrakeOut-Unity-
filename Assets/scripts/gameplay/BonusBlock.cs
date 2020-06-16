using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    override protected void Start()
    {
        points = ConfigurationUtils.PointsBonus;
        base.Start();
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
