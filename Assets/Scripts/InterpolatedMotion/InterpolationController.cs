///InterpolationController - https://www.kinematicsoup.com/news/2016/8/9/rrypp5tkubynjwxhxjzd42s3o034o8
///Stores the timestamps of the two most recent fixed steps, 
///and by comparing them against the time during Update generates a global interpolation factor. 
///The script must be attached to a single gameobject in the scene.

using UnityEngine;
using System.Collections;

public class InterpolationController : MonoBehaviour
{
    private float[] m_lastFixedUpdateTimes;
    private int m_newTimeIndex;

    private static float m_interpolationFactor;
    public static float InterpolationFactor
    {
        get { return m_interpolationFactor; }
    }

    public void Start()
    {
        m_lastFixedUpdateTimes = new float[2];
        m_newTimeIndex = 0;
    }

    public void FixedUpdate()
    {
        m_newTimeIndex = OldTimeIndex();
        m_lastFixedUpdateTimes[m_newTimeIndex] = Time.fixedTime;
    }

    public void Update()
    {
        float newerTime = m_lastFixedUpdateTimes[m_newTimeIndex];
        float olderTime = m_lastFixedUpdateTimes[OldTimeIndex()];

        if (newerTime != olderTime)
        {
            m_interpolationFactor = (Time.time - newerTime) / (newerTime - olderTime);
        }
        else
        {
            m_interpolationFactor = 1;
        }
    }

    private int OldTimeIndex()
    {
        return (m_newTimeIndex == 0 ? 1 : 0);
    }
}