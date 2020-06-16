using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    #region Fields
    //populate sprites
    [SerializeField]
    Sprite[] blockSprite = new Sprite[2];
    SpriteRenderer spriteRenderer;

    //timers

    //freez & speed
    SpeedUpActivation SpeedyGonzalez = new SpeedUpActivation();
    FreezerEffectActivation FreezEffect = new FreezerEffectActivation();
    //type of effect
    PickupEffect effect;
    #endregion

    #region Constructor
    // Start is called before the first frame update
    override protected void Start()
    {
        //for choise what type of block
        spriteRenderer = GetComponent<SpriteRenderer>();
        effect = (PickupEffect)Random.Range(0, 2);
        spriteRenderer.sprite = blockSprite[(int)effect];

        points = ConfigurationUtils.PointsPickup;

        base.Start();

        //timers init

        EventManager.AddFreezerInvoker(this);
        EventManager.AddSpeddyInvoker(this);
    }
    #endregion

    #region Properties

    public void AddFreezListener(UnityAction<float> listener)
    {
        FreezEffect.AddListener(listener);
    }

    public void AddSpeddyListener(UnityAction<float, float> listener)
    {
        SpeedyGonzalez.AddListener(listener);
    }


    #endregion

    #region Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (effect == PickupEffect.Freezer)
            FreezEffect.Invoke(ConfigurationUtils.TimerFreezy);
        if (effect == PickupEffect.Speedup)
            SpeedyGonzalez.Invoke(ConfigurationUtils.SpeedTimer, 
                                    ConfigurationUtils.SpeedFactor);
    }
    
    #endregion
}
