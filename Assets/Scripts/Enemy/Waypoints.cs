
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;

    private void Initialize()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Reset()
    {
        Initialize();
    }

    public Transform GetFirstPoint()
    {
        return points[0];
    }


    public Transform GetRandomPoint()
    {
        int randomIndex = Random.Range(0, points.Length);
        return points[randomIndex];
    }
}
