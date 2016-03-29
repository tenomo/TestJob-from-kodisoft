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
            OnMouseEnterEvent(this.cachTransform.position);
         
    }
    private void OnMouseExit()
    {
        if (this.OnMouseExitEvent != null)
            OnMouseExitEvent(this.cachTransform.position); 
    }


    private void OnMouseOver()
    {
        if (this.OnMouseOverEvent != null)
            OnMouseOverEvent(this.cachTransform.position);         
    }  

}

public delegate void OnMouseActionHandler(Vector3 Positon); 

public interface IHandlerOnMouseActions
{
    event OnMouseActionHandler OnMouseOverEvent;
    event OnMouseActionHandler OnMouseExitEvent;
    event OnMouseActionHandler OnMouseEnterEvent;
}

