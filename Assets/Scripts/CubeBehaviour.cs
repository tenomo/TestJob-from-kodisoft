using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CubeBehaviour : MonoBehaviour, ICubeBehaviour
{
  
    public float SpeedOfRise { get; set; }   
    public float SpeedOfExpansion { get; set; }
    public Vector2 PositionInField { set; get; }
    public List<ICubeBehaviour> Neighbors { get; set; }

    private Transform cachTransform;
    

    private void Start()
    {
        this.Neighbors = new List<ICubeBehaviour>();
        this.cachTransform = this.GetComponent<Transform>();
    }

    public void Expansion(float height)
    {
        StopCoroutine(this.CoroutineConstriction());
        StartCoroutine(this.CoroutineExpansion(height));
    }

    private IEnumerator CoroutineExpansion(float v)
    {
        if (transform.localScale.y < v)
        {
            this.cachTransform.localScale += new Vector3(0, Time.deltaTime * SpeedOfRise, 0);
            this.cachTransform.Translate(new Vector3(0, (SpeedOfRise / 2 * Time.deltaTime), 0));
            yield return null;
        }

    }

    public void Constriction()
    {
        StopCoroutine(this.CoroutineExpansion(0));
        StartCoroutine(CoroutineConstriction());
    }
    private IEnumerator CoroutineConstriction()
    {
        while (transform.localScale.y > 1)
        {
            this.cachTransform.localScale -= new Vector3(0, Time.deltaTime * SpeedOfRise, 0);
            this.cachTransform.Translate(new Vector3(0, (-SpeedOfRise / 2 * Time.deltaTime), 0));
            yield return null;
        }
    }
}

public interface ICubeBehaviour
{
    float SpeedOfRise { get; set; }
    void Expansion(float Height);
    void Constriction();
}
 

