using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    static Dictionary<EventName, List<IntEventInvoker>> invokers =
    new Dictionary<EventName, List<IntEventInvoker>>();
    static Dictionary<EventName, List<UnityAction<int>>> listeners =
        new Dictionary<EventName, List<UnityAction<int>>>();

    //Freezy
    static List<PickupBlock> freezerInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerListeners = 
                                        new List<UnityAction<float>>();

    //Speddy
    static List<PickupBlock> speddyInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>>    speddyListeners = 
                    new List<UnityAction<float, float>>();
    #endregion

    #region Public methods


    //Freezy
    public static void AddFreezerInvoker(PickupBlock invoker)
    {
        freezerInvokers.Add(invoker);
        foreach (UnityAction<float> freezerListener in freezerListeners)
            invoker.AddFreezListener(freezerListener);
    }
    public static void AddFreezerListener(UnityAction<float> listener)
    {
        freezerListeners.Add(listener);
        foreach (PickupBlock freezerInvoker in freezerInvokers)
            freezerInvoker.AddFreezListener(listener);
    }

    //Speddy
    public static void AddSpeddyInvoker(PickupBlock invoker)
    {
        speddyInvokers.Add(invoker);
        foreach (UnityAction<float, float> speddyListener in speddyListeners)
            invoker.AddSpeddyListener(speddyListener);
    }
    public static void AddSpeddyListener(UnityAction<float, float> listener)
    {
        speddyListeners.Add(listener);
        foreach (PickupBlock pickUpBlock in speddyInvokers)
            pickUpBlock.AddSpeddyListener(listener);
    }

    /// <summary>
    /// Initializes the event manager
    /// </summary>
    public static void Initialize()
    {
        // create empty lists for all the dictionary entries
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<IntEventInvoker>());
                listeners.Add(name, new List<UnityAction<int>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }


    /// <summary>
    /// Adds the given invoker for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="invoker">invoker</param>
    public static void AddInvoker(EventName eventName, IntEventInvoker invoker)
    {
        // add listeners to new invoker and add new invoker to dictionary
        foreach (UnityAction<int> listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(invoker);
    }

    /// <summary>
    /// Adds the given listener for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="listener">listener</param>
    public static void AddListener(EventName eventName, UnityAction<int> listener)
    {
        // add as listener to all invokers and add new listener to dictionary
        foreach (IntEventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    /// <summary>
    /// Removes the given invoker for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="invoker">invoker</param>
    public static void RemoveInvoker(EventName eventName, IntEventInvoker invoker)
    {
        // remove invoker from dictionary
        invokers[eventName].Remove(invoker);
    }

    #endregion
}
