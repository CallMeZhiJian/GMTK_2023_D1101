using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    private bool slomo;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (slomo)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            if(Time.timeScale == 1)
                slomo = false;
        }
    }

    public void DoSlowMo()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        slomo = true;
    }
}
