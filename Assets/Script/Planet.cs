using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public Vector2 pos;
    public float radius;
    public Vector2 offset;
    public float fetchForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        circleCollider= GetComponent<CircleCollider2D>();
        radius = circleCollider.radius*transform.localScale.x;
        offset =circleCollider.offset * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        pos = (Vector2)transform.position+ offset;
    }
    public Vector2 ChangeDegreeToPos(float _degree,float height=0)
    {
        Vector2 returnPos = new Vector2();
        returnPos = pos + (radius+ height) * new Vector2(Mathf.Sin(_degree), Mathf.Cos(_degree));
        return returnPos;
    }
    //public float ChangePosToDegree(Vector2 _pos)
    //{
    //    Vector2 rePos = _pos - pos;//œ‡∂‘Œª÷√ 
    //}
}
