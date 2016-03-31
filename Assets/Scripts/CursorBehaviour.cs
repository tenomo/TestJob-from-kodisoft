using UnityEngine;
using System.Collections;
    using System.Collections.Generic;
using System;

public class CursorBehaviour : MonoBehaviour, ICursorBehaviour
{
    //private   Point[] RegionImpacts { get; set; }



    private Dictionary<Vector3, float> RegionImpacts = new Dictionary<Vector3, float>();
    [SerializeField]
    private Vector2 sizeRegion;
    public Vector2 SizeRegion { get { return sizeRegion; } set { sizeRegion = value; } }
    [SerializeField]
    private float maxHeight;
    public float MaxHeight { get { return maxHeight; } set { maxHeight = value; } }

    private FieldObjects fieldObjectsBuilder;
    public GameObject GOFieldObjectsBuilder;

    void Start()
    {
        fieldObjectsBuilder = GOFieldObjectsBuilder.GetComponent<FieldObjects>();
    }

    public Dictionary<Vector3, float> GetRegionImpacts(Vector3 pos)
    {
        int startPosX = (int)(pos.x - (SizeRegion.x / 2));
        int startPosZ = (int)(pos.z - (SizeRegion.y / 2));
        Vector3 StartPos = new Vector3(startPosX, pos.y, startPosZ);
        Vector3 tmpPos = StartPos;


        for (int i = 0; i < SizeRegion.y; i++)
        {
            for (int j = 0; j < SizeRegion.x; j++)
            {
                //if (fieldObjectsBuilder.Filed.ContainsKey(tmpPos))
                //{
                //    RegionImpacts.Add(tmpPos, GetPercentageHeight(pos, tmpPos));
                //}
                tmpPos.x++;
            }
            tmpPos.x = startPosX;
            tmpPos.z++;
        }


        return RegionImpacts;
    }

    private float GetPercentageHeight(Vector3 centrRegion, Vector2 pos)
    {
        float dist = Vector3.Distance(centrRegion, pos);
        float result;
        if (Vector3.Distance(centrRegion, pos) != 0)
            result = MaxHeight / dist;
        else
            result = MaxHeight;

        return result;
    }

    public void CursorBehaviour_OnMouseOverEvent(Vector3 Position)
    {
        foreach (KeyValuePair<Vector3, float> item in GetRegionImpacts(Position))
        {
            //if (fieldObjectsBuilder.Filed.ContainsKey(item.Key))
            //{
            //    fieldObjectsBuilder.Filed[item.Key].Expansion(item.Value);
            //}
        }
    }


    public void CursorBehaviour_OnMouseExitEvent(Vector3 Position)
    { 
        foreach (KeyValuePair<Vector3, float> item in GetRegionImpacts(Position))
        {
            //if (fieldObjectsBuilder.Filed.ContainsKey(item.Key))
            //{
            //    fieldObjectsBuilder.Filed[item.Key].Constriction();
            //}
        }
    }
}

//public class Point
//{
//    public Vector3 Positon;
//    public float Height;

//    public Point ( Vector3 Positon, float Height)
//    {
//        this.Positon = Positon;
//        this.Height = Height;
//    }
//}

public interface ICursorBehaviour
{
    Vector2 SizeRegion { get; set; } 
    float MaxHeight { get;set;}
    Dictionary<Vector3, float> GetRegionImpacts(Vector3 pos);
}
