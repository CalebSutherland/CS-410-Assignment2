using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleColorChange : MonoBehaviour
{
    /*
     * Inspiration Credit: https://stackoverflow.com/questions/43419915/lerp-color-based-on-distance-between-2-objects
     */
    public Transform player;
    
    Color near = Color.red;
    Color far = Color.white;
    const float MAX_DISTANCE = 40;

    void Update()
    {
        //determines distance between player and gargoyle
        float distanceFromPlayer = getDistance(player.position, this.transform.position);

        //Convert distance to decimal float value for lerp
        float lerp = mapValue(distanceFromPlayer, 8, MAX_DISTANCE, 0f, 1f);

        //lerp color between the two colors
        Color lerpColor = Color.Lerp(near, far, lerp);
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", lerpColor);
    }

    public float getDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }

    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
}
