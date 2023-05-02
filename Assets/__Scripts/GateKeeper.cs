using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeeper : MonoBehaviour
{
    //плитки с запертыми дверьми
    const int lockedR = 73;
    const int lockedUR = 57;
    const int lockedUL = 56;
    const int lockedL = 72;
    const int lockedDL = 88;
    const int lockedDR = 89;

    //плитки с открытыми дверьми
    const int openR = 77;
    const int openUR = 61;
    const int openUL = 60;
    const int openL = 76;
    const int openDL = 92;
    const int openDR = 93;

    private IKeyMaster keys;

    void Awake()
    {
        keys = GetComponent<IKeyMaster>();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (keys.keyCount < 1) return;

        Tile ti = coll.gameObject.GetComponent<Tile>();
        if (ti == null) return; 

        int facing = keys.GetFacing();

        Tile ti2;
        switch (ti.tileNum)
        {
            case lockedR:
                if (facing != 0) return;
                ti.SetTile(ti.x, ti.y, openR);
                break;
            case lockedUR:
                if (facing != 1) return;
                ti.SetTile(ti.x,ti.y,openUR);
                ti2 = TileCamera.TILES[ti.x-1, ti.y];
                ti2.SetTile(ti2.x,ti2.y,openUL);
                break;
            case lockedUL:
                if (facing !=1) return;
                ti.SetTile(ti.x, ti.y, openUL);
                ti2 = TileCamera.TILES[ti.x+1, ti.y];
                ti2.SetTile(ti2.x,ti2.y,openUR);
                break;
            case lockedL:
                if (facing != 2) return;
                ti.SetTile(ti.x,ti.y,openL); break;
            case lockedDL:
                if (facing != 3) return;
                ti.SetTile(ti.x, ti.y, openDL);
                ti2 = TileCamera.TILES[ti.x+1, ti.y];
                ti2.SetTile(ti2.x, ti2.y,openDL);
                break;
            case lockedDR:
                if (facing != 3) return;
                ti.SetTile(ti.x, ti.y, openDR);
                ti2 = TileCamera.TILES[ti.x-1,ti.y];
                ti2.SetTile(ti2.x, ti2.y, openDL);
                break;
            default: return;
              
        }
        keys.keyCount--;
    }
}
