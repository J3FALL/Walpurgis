using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chalk : MonoBehaviour
{
    enum State { Drag, StartDraw, Draw, SuccessDraw };

    private Vector3 defaultPos;
    private float delta = 0.0f;
    private LineRenderer line;
    private bool isKeyPressed;
    private State state;

    public List<Vector3> pointsList;
    private Vector3 pos;
    public Camera myCamera;
    public Player player;


    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };

    public float MAX_OFFSET = -70;

    public void Start()
    {
        state = State.Drag;
        defaultPos = transform.position;
    }

    void Awake()
    {
        //create line renderer and set its property
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetVertexCount(0);
        line.SetWidth(1f, 1f);
        line.SetColors(Color.white, Color.white);
        line.useWorldSpace = true;
    }

    void Update()
    {

        if (state == State.StartDraw)
        {
            InitDrawMode();
            state = State.Draw;
            Debug.Log("draw");
        } else if(state == State.Draw)
        {
            //check if player collides with line
            if (player.GetComponent<BoxCollider2D>().OverlapPoint(pos))
            {
                state = State.StartDraw;
                Debug.Log("start draw");
            } else
            {
                //checking key inputs
                if (Input.GetKey(KeyCode.W))
                {
                    pos.y += 1.0f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    pos.x -= 1.0f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    pos.x += 1.0f;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    pos.y -= 1.0f;
                }

                pos.z = 0;
                if (!pointsList.Contains(pos))
                {
                    pointsList.Add(pos);
                    line.SetVertexCount(pointsList.Count);
                    line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                    if (isLineCollide())
                    {
                        line.SetColors(Color.red, Color.red);
                        //success
                        state = State.StartDraw;
                    }
                }
            }
            
        }
        //pos = myCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    private void InitDrawMode()
    {
        //Remove last lines
        pointsList = new List<Vector3>();
        line.SetColors(Color.white, Color.white);
        pos = player.transform.position;
        pos.y += 30.0f;
    }

    public void OnDrag()
    {
        delta = Input.mousePosition.x - defaultPos.x;
        if (delta < 0 && delta > MAX_OFFSET)
        {
            transform.position = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);
        }
        else if (delta <= MAX_OFFSET)
        {
            Debug.Log("finish drag");
            state = State.StartDraw;
            //enable draw mode
        }
    }

    private bool isLineCollide()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1)
        {
            for (int i = 0; i < TotalLines; i++)
            {
                lines[i].StartPoint = (Vector3)pointsList[i];
                lines[i].EndPoint = (Vector3)pointsList[i + 1];
            }
        }
        for (int i = 0; i < TotalLines - 1; i++)
        {
            myLine currentLine;
            currentLine.StartPoint = (Vector3)pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList[pointsList.Count - 1];
            if (isLinesIntersect(lines[i], currentLine))
                return true;
        }
        return false;
    }


    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
    //    -----------------------------------    
    //    Following method checks whether given two line intersect or not
    //    -----------------------------------    
    private bool isLinesIntersect(myLine L1, myLine L2)
    {
        if (checkPoints(L1.StartPoint, L2.StartPoint) ||
            checkPoints(L1.StartPoint, L2.EndPoint) ||
            checkPoints(L1.EndPoint, L2.StartPoint) ||
            checkPoints(L1.EndPoint, L2.EndPoint))
            return false;

        return ((Mathf.Max(L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min(L2.StartPoint.x, L2.EndPoint.x)) &&
            (Mathf.Max(L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min(L1.StartPoint.x, L1.EndPoint.x)) &&
            (Mathf.Max(L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min(L2.StartPoint.y, L2.EndPoint.y)) &&
            (Mathf.Max(L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min(L1.StartPoint.y, L1.EndPoint.y))
         );
    }
}
