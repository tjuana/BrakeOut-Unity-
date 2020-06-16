using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StandartBlock : Block
{
    [SerializeField]
    Sprite[] blockSprite = new Sprite[3];
    SpriteRenderer spriteRenderer;

    override protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = blockSprite[Random.Range(0,3)];
        points = ConfigurationUtils.PointsStandart;
        base.Start();
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        AudioManager.Play(AudioClipName.BallHit);
    }
}
