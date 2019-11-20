using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    #region Singleton
    public static WaypointManager Instance = null;
    private void Awake()
    {
        Instance = this;
        Initialize();
    }
    #endregion

    public Waypoints[] waypointPaths;

    private void Initialize()
    {
        waypointPaths = GetComponentsInChildren<Waypoints>();
    }
    private void Reset()
    {
        Initialize();
    }

    public Waypoints GetRandomPath()
    {
        int randomIndex = Random.Range(0, waypointPaths.Length);
        return waypointPaths[randomIndex];
    }
}
