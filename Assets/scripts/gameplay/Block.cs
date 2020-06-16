using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IntEventInvoker
{
    protected int points;

    virtual protected void Start()
    {
        // add as invoker for PointsAddedEvent
        unityEvents.Add(EventName.PointsAddedEvent, new PointsAddedEvent());
        EventManager.AddInvoker(EventName.PointsAddedEvent, this);
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (gameObject != null)
            {
                unityEvents[EventName.PointsAddedEvent].Invoke(points);
                EventManager.RemoveInvoker(EventName.PointsAddedEvent, this);
                Destroy(gameObject);
            }
        }
    }
}
