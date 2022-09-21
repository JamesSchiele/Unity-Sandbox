using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float targetPosMaxY = 5f;
    public float targetPosMinY = -5f;

    public float targetPosMaxZ = 5f;
    public float targetPosMinz = -5;

    public float startingPos = 0f;

    public Transform Sunrise;
    public Transform Sunset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SunRiseSunSet();
    }
    public void MoveUpAndDown()
    {
        transform.position = new Vector3(0, Mathf.Lerp(targetPosMinY, targetPosMaxY, startingPos), 0);

        startingPos += 0.25f * Time.deltaTime;

        if (startingPos > 1f)
        {
            Debug.Log("Yes");

            float temp = targetPosMaxY;
            
            targetPosMaxY = targetPosMinY;
            targetPosMinY = temp;

            startingPos = 0f;
        }
        Debug.Log("Fuck yes");
        Debug.Log(startingPos);
    }

    public void MoveRight()
    {
        transform.position = new Vector3(0, 0, Mathf.Lerp(targetPosMinz, targetPosMaxZ, startingPos));

        startingPos += 0.75f * Time.deltaTime;

        if (startingPos > 1f)
        {
            float temp = targetPosMaxZ;

            targetPosMaxZ = targetPosMinz;
            targetPosMinz = temp;

            startingPos = 0f;
        }
    }

    public void SunRiseSunSet()
    {
        Vector3 centre = (Sunrise.position + Sunset.position) * 0.5f;

        centre -= new Vector3(0, 1f, 0f);

        Vector3 riseFromCenter = Sunrise.position - centre;
        Vector3 setFromCenter = Sunset.position - centre;

        transform.position = Vector3.Slerp(riseFromCenter, setFromCenter, 0.1f);

        transform.position += centre;
    }
}
