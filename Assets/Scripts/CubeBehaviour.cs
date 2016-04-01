using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CubeBehaviour : MonoBehaviour, ICubeBehaviour
{
    /// <summary>
    /// Скорость смещения
    /// </summary>
    public float SpeedOfRise { get; set; }
    /// <summary>
    /// Высота маштабирования и смещения
    /// </summary>
    public float height { get; set; }
    /// <summary>
    /// Скорость маштабирования
    /// </summary>
    public float SpeedOfExpansion { get; set; }
    /// <summary>
    /// Позиция в поле
    /// </summary>
    public Vector2 PositionInField { set; get; }
    /// <summary>
    /// Ближайшие элементы в поле
    /// </summary>
    public List<ICubeBehaviour> Neighbors { get; set; }


    private Transform cachTransform;


    public FieldObjects fieldObjects { get; set; }

    /// <summary>
    /// Инициализация списка ближайших элементов 
    /// </summary>
    /// <param name="FieldObjects"></param>
    private void InitNeighbors(FieldObjects FieldObjects)
    {
        int CountNeighbors = 0;
        Vector2 startPoint = new Vector2(this.PositionInField.x - CountNeighbors / 2, this.PositionInField.y - CountNeighbors / 2);
        Vector2 tmpPoint = startPoint;

        for (int i = 0; i < CountNeighbors; i++)
        {
            for (int j = 0; j < CountNeighbors; j++)
            {
                if (tmpPoint != this.PositionInField)
                    if (tmpPoint.x <= FieldObjects.Size.Width && tmpPoint.x >= 0 &&
                        tmpPoint.y <= FieldObjects.Size.Depth && tmpPoint.y >= 0)
                        this.Neighbors.Add(FieldObjects.Field[(int)tmpPoint.x, (int)tmpPoint.y]);
                tmpPoint.x++;
            }
            tmpPoint.x = 0;
            tmpPoint.y++;
        }
    }

    private void Start()
    {
        this.Neighbors = new List<ICubeBehaviour>();
        this.cachTransform = this.GetComponent<Transform>();


        this.InitNeighbors(this.fieldObjects);
    }

    

    #region rize
    public void Rize()
    {
        StopCoroutine(CoroutineDescend());
        StartCoroutine(CoroutineRize(height));

    }

    private IEnumerator CoroutineRize(float v)
    {
        if (transform.position.y < v)
        {
            this.cachTransform.Translate(new Vector3(0, (SpeedOfRise / 2 * Time.deltaTime), 0));
            yield return null;
        }

    }
    #endregion

    #region descend
    public void Descend()
    {
        StopCoroutine(CoroutineRize(0));
        StartCoroutine(CoroutineDescend());

    }

    private IEnumerator CoroutineDescend()
    {
        while (transform.position.y > 1)
        {
            this.cachTransform.Translate(new Vector3(0, (-SpeedOfRise / 2 * Time.deltaTime), 0));
            yield return null;
        }
    }
    #endregion

    #region Expansion
    public void Expansion()
    {
        StopCoroutine(this.CoroutineConstriction());
        StartCoroutine(this.CoroutineExpansion(height));
    }

    private IEnumerator CoroutineExpansion(float v)
    {
        if (transform.localScale.y < v)
        {
            this.cachTransform.localScale += new Vector3(0, Time.deltaTime * SpeedOfExpansion, 0);
            yield return null;
        }

    }
    #endregion

    #region Constriction
    public void Constriction()
    {
        StopCoroutine(this.CoroutineExpansion(0));
        StartCoroutine(CoroutineConstriction());
    }
    private IEnumerator CoroutineConstriction()
    {
        while (transform.localScale.y > 1)
        {
            this.cachTransform.localScale -= new Vector3(0, Time.deltaTime * SpeedOfExpansion, 0);

            yield return null;
        }
    }

    #endregion
}

public interface ICubeBehaviour
{
    float SpeedOfRise { get; set; }
    float SpeedOfExpansion { get; set; }
    void Expansion();
    void Constriction();
    void Rize();
    void Descend();
    float height { get; set; }
}
 

