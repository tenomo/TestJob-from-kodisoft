using UnityEngine;
using System.Collections.Generic;

public class FieldObjects : MonoBehaviour
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
        

        for (int z = 0; z < sizeField.Depth; z++)
        {
            for (int x = 0; x < sizeField.Width; x++)
            {               
                ICubeBehaviour itemField = CreateItemField(tmpPoint).GetComponent<ICubeBehaviour>();

                resultField[x, z] = itemField;

                IHandlerOnMouseActions handlerOmMauseActions = CreateColliderItem(tmpPoint).GetComponent<HandlerOnMouseActions>();

                handlerOmMauseActions.OnMouseOverEvent += itemField.Expansion;
                handlerOmMauseActions.OnMouseOverEvent += itemField.Rize;

                handlerOmMauseActions.OnMouseExitEvent += itemField.Constriction;
                handlerOmMauseActions.OnMouseExitEvent += itemField.Descend;

                tmpPoint.x += 1;            
               
            }
            tmpPoint.x = StartPoint.x;
            tmpPoint.z += 1;
        }
        return resultField;
    }

    private GameObject CreateItemField(Vector2 pos)
    {
        GameObject item;
        item = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Component.Destroy(item.GetComponent<Collider>());
        item.transform.position = pos;

        item.name = "FIC " + pos.ToString();
        item.isStatic = true;
        item.AddComponent<CubeBehaviour>();

        return item;
    }

    private GameObject CreateColliderItem (Vector2 pos)
    {
        GameObject colliderItem;
        colliderItem = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Component.Destroy(colliderItem.GetComponent<Renderer>());
        colliderItem.transform.position = pos;
        colliderItem.AddComponent<HandlerOnMouseActions>();

        return colliderItem;
    }
}


