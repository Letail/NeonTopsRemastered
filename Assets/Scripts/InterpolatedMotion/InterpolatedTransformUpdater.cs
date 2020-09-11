///InterpolatedTransformUpdater - https://www.kinematicsoup.com/news/2016/8/9/rrypp5tkubynjwxhxjzd42s3o034o8
///Used to call a couple methods in InterpolatedTransform 
///both before and after other script’s FixedUpdates. 
///Must be placed on objects that also have InterpolatedTransform attached.

using UnityEngine;
using System.Collections;

public class InterpolatedTransformUpdater : MonoBehaviour
{
    private InterpolatedTransform m_interpolatedTransform;

    void Awake()
    {
        m_interpolatedTransform = GetComponent<InterpolatedTransform>();
    }

    void FixedUpdate()
    {
        m_interpolatedTransform.LateFixedUpdate();
    }
}