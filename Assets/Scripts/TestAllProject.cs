using UnityEngine;
using System.Collections;

public class TestAllProject : MonoBehaviour {

    //   float Height = 0;

    //   ITimer timer;

    //   Renderer rend;
    //// Use this for initialization
    //void Start () {
    //       rend = GetComponent<Renderer>(); 
    //       Collider c = GetComponent<Collider>();
    //       Component.Destroy(c);


    //       timer = Timer.AddTimer(this.gameObject);
    //       timer.Elapsed += Timer_Elapsed;
    //       timer.interval = 0.1f;
    //}

    //   private void Timer_Elapsed()
    //   {
    //       if (Height < 30)
    //       {
    //        GameObject g=   Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),
    //               new Vector3(transform.position.x, Height, transform.position.z), Quaternion.identity) as GameObject;
    //           Collider c = g.GetComponent<Collider>() ;
    //           Component.Destroy(c);
    //           Height++;
    //           timer.startTimer();
    //       }
    //   }

    //   // Update is called once per frame
    //   void OnMouseEnter()
    //   {        
    //           //timer.startTimer();            
    //           this.gameObject.transform.localScale += new Vector3(0, Time.deltaTime * 2, 0);     

    //   }    


    //bool IsInt(object obj)
    //{
    //    return System.Convert.ToInt32(obj) == System.Convert.ToDouble(obj);
    //}

    ICursorBehaviour cursorBehaviour;
    public GameObject objectHandlerCursor;

    FieldObjectsBuilder fieldObjectsBuilder;

    public GameObject objectFieldObjectsBuilder;
    void Start ()
    {
        this.cursorBehaviour = objectHandlerCursor.GetComponent<CursorBehaviour>();
        this.fieldObjectsBuilder = objectFieldObjectsBuilder.GetComponent<FieldObjectsBuilder>();
    }

 ArrayList list = new ArrayList();
    float[,] RegionImpacts;
    public void Update ()
    {

       // RegionImpacts = cursorBehaviour.UpdateRegionImpacts();

        //string str1 = " ", str2 =  "";
        //if (Input.GetMouseButton (0))
        //{
        //    for (int i = 0; i < RegionImpacts.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < RegionImpacts.GetLength(1); j++)
        //        {
        //            str1 += i.ToString()+","+ j+ "  ";
        //        }
        //    }

        //    Debug.Log(str1);
        //}

        //for (int i = 0; i < RegionImpacts.GetLength(0); i++)
        //{
        //    for (int j = 0; j < RegionImpacts.GetLength(1); j++)
        //    {
        //        try
        //        {
        //            fieldObjectsBuilder.Filed[new Vector3(j, i)].GetComponent<CubeBehaviourScript>().test(RegionImpacts[i, j]);
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}
        if (Input.GetMouseButton(0))
        {

            //Vector3 v = cursorBehaviour.CursorPosition;
            //try
            //{

            //    fieldObjectsBuilder.Filed[v].GetComponent<CubeBehaviourScript>().Expansion(cursorBehaviour.MaxHeight);
            //  //  Debug.LogError("try " + v);
            //    fieldObjectsBuilder.Filed[v].GetComponent<Renderer>().material.color = Color.blue;
            //}
            //catch
            //{
            //    Debug.Log("catch " + v);
            //}

            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hit))
            //    //  if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0f))
            //    print("Found an object - distance: " + hit.point);
        }
    }
}
