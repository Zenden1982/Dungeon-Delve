using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int x;
    public int y;
    public int tileNum;

    private BoxCollider2D bColl;
    void Awake()
    {
        bColl = GetComponent<BoxCollider2D>(); // a
    }

    public void SetTile(int eX, int eY, int eTileNum = -1) // a
    {
        x = eX;
        y = eY;
        transform.localPosition = new Vector3(x, y, 0);
        gameObject.name = x.ToString("D3") +"x" + y.ToString("D3"); // b
        if (eTileNum == -1)
        {
            eTileNum = TileCamera.GET_MAP(x, y);
        }
        tileNum = eTileNum;
        GetComponent<SpriteRenderer>().sprite = TileCamera.SPRITES[tileNum];
        SetCollider();
    }

    void SetCollider()
    {
        // Получить информацию о коллайдере из Collider DelverCollisions.txt
        bColl.enabled = true;
        char c = TileCamera.COLLISIONS[tileNum]; // c
        switch (c)
        {
            case 'S': // Вся плитка
                bColl.offset = Vector3.zero;
                bColl.size = Vector3.one;
                break;
            case 'W': // Верхняя половина
                bColl.offset = new Vector3(0, 0.25f, 0);
                bColl.size = new Vector3(1, 0.5f, 1);
                break;
            case 'A': // Левая половина
                bColl.offset = new Vector3(-0.25f, 0, 0);
                bColl.size = new Vector3(0.5f, 1, 1);
                break;
            case 'D': // Правая половина
                bColl.offset = new Vector3(0.25f, 0, 0);
                bColl.size = new Vector3(0.5f, 1, 1);
                break;
            default: // Все остальное: |, и др. // е
                bColl.enabled = false;
                break;
                
        }

    } 
}
