using UnityEngine;
using System.Collections;

public class CubeBehaviourScript : MonoBehaviour , ICubeBehaviourScript
{
   public float MetamorphosesSpeed { get; set; }

    private Transform cachTransform;

    private void Start ()
    {
        // defoult value
        MetamorphosesSpeed = 15;
        this.cachTransform = this.GetComponent<Transform>();
    }

    public void Expansion(float v)
    { 
        StopCoroutine(this.CoroutineConstriction());
        StartCoroutine(this.CoroutineExpansion(v));
    }

    private IEnumerator CoroutineExpansion(float v)
    {
        if (transform.localScale.y < v)
        {
            this.cachTransform.localScale += new Vector3(0, Time.deltaTime * MetamorphosesSpeed, 0);
            this.cachTransform.Translate(new Vector3(0, (MetamorphosesSpeed / 2 * Time.deltaTime), 0));
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
            this.cachTransform.localScale -= new Vector3(0, Time.deltaTime * MetamorphosesSpeed, 0);
            this.cachTransform.Translate(new Vector3(0, (-MetamorphosesSpeed / 2 * Time.deltaTime), 0));
            yield return null;
        }
    }
}

public interface ICubeBehaviourScript
{
    float MetamorphosesSpeed { get; set; }
    void Expansion(float Height);
    void Constriction();
}
