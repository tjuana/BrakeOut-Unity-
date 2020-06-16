using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;

    //blockHieght
    float blokHeight;

    //position of ball
    Vector3 position;

    // placement support
    GameObject[] block;
    float[] xPositions;
    float baseY;

    // save for efficiency
    int numBlok;
    Vector2 blokLocation = Vector2.zero;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject[] bloksPrefabs = new GameObject[3];
    int blokPrefabNumber;



    // Start is called before the first frame update
    void Start()
    {
        GameObject paddle = Instantiate<GameObject>(paddlePrefab);
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        //take size of block
        GameObject tempBlock = Instantiate<GameObject>(bloksPrefabs[0]);
        CapsuleCollider2D collider = tempBlock.GetComponent<CapsuleCollider2D>();
        float blokWidth = collider.size.x;
        blokHeight = collider.size.y;
        Destroy(tempBlock);

        // calculate blok in row and make sure left blok position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        numBlok = (int)(screenWidth / blokWidth);
        float totalBlokWidth = numBlok * blokWidth;
        float leftBlokOffset = ScreenUtils.ScreenLeft +
                               (screenWidth - totalBlokWidth) / 2 +
                               blokWidth / 2;
        float screenheight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
        // save y location for blok and create arrays
        baseY = -ScreenUtils.ScreenBottom - (screenheight / 5);
        block = new GameObject[numBlok];
        xPositions = new float[numBlok];
        // add row of blok
        for (int line = 0; line < ConfigurationUtils.LineBlock; line++)
        {

            blokLocation = new Vector2(leftBlokOffset, baseY);
            int blokIndex = 0;
            for (int column = 0; column < numBlok; column++)
            {
                int probabilites = Random.Range(0, ConfigurationUtils.PickupBlockProbabilities + 
                    ConfigurationUtils.StandartBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities);
                if (probabilites <= ConfigurationUtils.StandartBlockProbabilities)
                    blokPrefabNumber = 0;
                else if (probabilites > ConfigurationUtils.StandartBlockProbabilities && 
                            probabilites <= ConfigurationUtils.StandartBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities)
                    blokPrefabNumber = 1;
                else if (probabilites > ConfigurationUtils.StandartBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities && 
                    probabilites <= ConfigurationUtils.PickupBlockProbabilities +
                    ConfigurationUtils.StandartBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities)
                    blokPrefabNumber = 2;

                block[blokIndex] = Instantiate<GameObject>(bloksPrefabs[blokPrefabNumber],
                    blokLocation, Quaternion.identity);

                xPositions[blokIndex] = blokLocation.x;
                blokLocation.x += blokWidth;
                blokIndex++;
            }
            baseY -= blokHeight;
        }
    }
}
 