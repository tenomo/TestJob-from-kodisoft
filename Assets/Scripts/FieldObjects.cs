using UnityEngine;
using System.Collections.Generic;

class FieldObjects : MonoBehaviour
{

    [SerializeField]
    private Vector3 centr;

    public Vector3 Centr { get { return centr; } private set { centr = value; } }
    public Size Size { get; private set; }
    public ICubeBehaviour[,] Field { get; set; }
    

    private void Awake()
    {
        FieldObjectsBuilder fieldObjectsBuilder = new FieldObjectsBuilder();
        this.Field = fieldObjectsBuilder.Build(this.centr, this.Size);
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

class FieldObjectsBuilder
{
    public ICubeBehaviour[,] Build(Vector3 centrField, Size sizeField)
    {


        ICubeBehaviour[,] resultField = new CubeBehaviour[sizeField.Width, sizeField.Depth];

        Vector3 StartPoint = new Vector3(centrField.x - (int)(sizeField.Width / 2), centrField.y, 
            (int)(centrField.z - sizeField.Depth / 2));

        Vector3 tmpPoint = StartPoint;

        GameObject curentGameObj;
        GameObject ColliderGameObject;

        for (int z = 0; z < sizeField.Depth; z++)
        {
            for (int x = 0; x < sizeField.Width; x++)
            {

                curentGameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(curentGameObj.GetComponent<Collider>());
                curentGameObj.transform.position = tmpPoint;
                tmpPoint.x += 1;
                curentGameObj.name = "FIC" + tmpPoint.ToString();
                curentGameObj.isStatic = true;
                curentGameObj.AddComponent<CubeBehaviour>();
                resultField[x, z] = curentGameObj.GetComponent<CubeBehaviour>();


                ColliderGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(ColliderGameObject.GetComponent<Renderer>());
                ColliderGameObject.transform.position = tmpPoint;
                ColliderGameObject.AddComponent<HandlerOnMouseActions>();
            }
            tmpPoint.x = StartPoint.x;
            tmpPoint.z += 1;
        }
        return resultField;
    }
}


