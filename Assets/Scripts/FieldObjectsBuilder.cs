using UnityEngine;
using ObjectPool;
using System.Collections.Generic;

class FieldObjectsBuilder : MonoBehaviour
{
    [SerializeField]
    public Vector2 SizeFiled;
    [SerializeField]
    public Vector3 Centr;


    public GameObject CursorBehaviourObject;
    private CursorBehaviour cursorBehaviour;

   public Dictionary<Vector3, ICubeBehaviourScript> Filed = new Dictionary<Vector3, ICubeBehaviourScript>();

    private void Start ()
    {
        cursorBehaviour = CursorBehaviourObject.GetComponent<CursorBehaviour>();
        BuildFiled(); 
        
    }


    void BuildFiled()
    { 

        Vector3 StartPoint = new Vector3(Centr.x - SizeFiled.x / 2, Centr.y, Centr.z - SizeFiled.y/2);
        Vector3 tmpPoint = StartPoint;
        GameObject tmpGameObject;
        GameObject t;
        for (int y = 0; y < SizeFiled.y; y++)
        {
            for (int x = 0; x < SizeFiled.x; x++)
            {

                tmpGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(tmpGameObject.GetComponent<Collider>());
                tmpGameObject.transform.position = tmpPoint;
                tmpPoint.x += 1;
                tmpGameObject.name = "My true cube "+ tmpPoint.ToString() ;
                tmpGameObject.isStatic = true;
                tmpGameObject.AddComponent<CubeBehaviourScript>();
                Filed.Add(tmpPoint,tmpGameObject.GetComponent<CubeBehaviourScript>());
               

                t = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Component.Destroy(t.GetComponent<Renderer>());
                t.transform.position = tmpPoint; 

                 t.AddComponent<HandlerOnMouseActions>();
                t.GetComponent<IHandlerOnMouseActions>().OnMouseExitEvent += cursorBehaviour.CursorBehaviour_OnMouseExitEvent;
                t.GetComponent<IHandlerOnMouseActions>().OnMouseOverEvent += cursorBehaviour.CursorBehaviour_OnMouseOverEvent;
            }
            tmpPoint.x = StartPoint.x;
            tmpPoint.z += 1;
        }
    }

    

   
}


