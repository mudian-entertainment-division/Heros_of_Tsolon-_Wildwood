
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;

    private void Initialize()
    {
        //Spawns the Enemy at the specified location
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
        //Gives the Enemy a random path to follow
        int randomIndex = Random.Range(0, points.Length);
        return points[randomIndex];
    }
}
