using UnityEngine;
using System.Collections;

public class HandlerOnMouseActions : MonoBehaviour, IHandlerOnMouseActions
{
    public event OnMouseActionHandler OnMouseEnterEvent;
    public event OnMouseActionHandler OnMouseExitEvent;
    public event OnMouseActionHandler OnMouseOverEvent; 

    private Transform cachTransform;

    private void Start ()
    {
        this.cachTransform = this.GetComponent<Transform>();
    }

    private void OnMouseEnter()
    {
        if (this.OnMouseEnterEvent != null)
            OnMouseEnterEvent( );
         
         
    }
    private void OnMouseExit()
    {
        if (this.OnMouseExitEvent != null)
            OnMouseExitEvent( ); 
    }


    private void OnMouseOver()
    {
        if (this.OnMouseOverEvent != null)
            OnMouseOverEvent( );         
    }  

}

public delegate void OnMouseActionHandler( ); 
public interface IHandlerOnMouseActions
{
    event OnMouseActionHandler OnMouseOverEvent;
    event OnMouseActionHandler OnMouseExitEvent;
    event OnMouseActionHandler OnMouseEnterEvent;
     
}

