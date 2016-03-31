using UnityEngine;
using ObjectPool;
using System.Collections.Generic;

class FieldObjects : MonoBehaviour
{

    [SerializeField]
    private Vector3 centr;

    public Vector3 Centr { get { return centr; } private set { centr = value; } }
    public Size Size { get; private set; }
    public ICubeBehaviour[,] Field { get; set; }
 

    private void Start()
    {
        BuildFiled();
    }


    private ICubeBehaviour[,] BuildFiled()
    {
        ICubeBehaviour[,] resultField = new CubeBehaviour[this.Size.Width, this.Size.Depth];

        Vector3 StartPoint = new Vector3(Centr.x - (int)(this.Size.Width / 2), Centr.y, (int)(Centr.z - this.Size.Depth / 2));

        Vector3 tmpPoint = StartPoint;

        GameObject tmpFIeldItemCube;
        GameObject tmpFIC_Collider;

        for (int z = 0; z < Size.Depth; z++)
        {
            for (int x = 0; x < Size.Width; x++)
            {

                tmpFIeldItemCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(tmpFIeldItemCube.GetComponent<Collider>());
                tmpFIeldItemCube.transform.position = tmpPoint;
                tmpPoint.x += 1;
                tmpFIeldItemCube.name = "FIC" + tmpPoint.ToString();
                tmpFIeldItemCube.isStatic = true;
                tmpFIeldItemCube.AddComponent<CubeBehaviour>();
                resultField[x, z] = tmpFIeldItemCube.GetComponent<CubeBehaviour>();


                tmpFIC_Collider = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(tmpFIC_Collider.GetComponent<Renderer>());
                tmpFIC_Collider.transform.position = tmpPoint;
                tmpFIC_Collider.AddComponent<HandlerOnMouseActions>();
            }
            tmpPoint.x = StartPoint.x;
            tmpPoint.z += 1;
        }
        return resultField;
    }
}

[System.Serializable]
public struct Size
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int depth;

    public int Width { get { return this.width; } set { this.width = value; } }

    public int Depth { get { return this.depth; } set { this.depth = value; } }
}




