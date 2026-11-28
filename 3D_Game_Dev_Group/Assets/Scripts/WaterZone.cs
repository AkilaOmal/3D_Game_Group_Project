using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WaterZone : MonoBehaviour
{
    public float SurfaceY => GetComponent<Collider>().bounds.max.y;

    void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}