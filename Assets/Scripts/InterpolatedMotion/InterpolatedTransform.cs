///InterpolatedTransform - https://www.kinematicsoup.com/news/2016/8/9/rrypp5tkubynjwxhxjzd42s3o034o8
///Stores the transforms for an object after the two most recent fixed steps, 
///and interpolates the object between them using the global interpolation factor. 
///It also ensures that the object is placed back where it was last fixed step 
///before the current fixed step executes, instead of where it was interpolated to last. 
///This means that any scripts moving the transform are working from the correct state. 
///If you teleport an object and want to prevent interpolation, 
///call the ForgetPreviousTransforms method after moving the object. 
///This script should be attached to any objects moved during a FixedUpdate.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InterpolatedTransformUpdater))]
public class InterpolatedTransform : MonoBehaviour
{
    private TransformData[] m_lastTransforms;
    private int m_newTransformIndex;

    void OnEnable()
    {
        ForgetPreviousTransforms();
    }

    public void ForgetPreviousTransforms()
    {
        m_lastTransforms = new TransformData[2];
        TransformData t = new TransformData(
                                transform.localPosition,
                                transform.localRotation,
                                transform.localScale);
        m_lastTransforms[0] = t;
        m_lastTransforms[1] = t;
        m_newTransformIndex = 0;
    }

    void FixedUpdate()
    {
        TransformData newestTransform = m_lastTransforms[m_newTransformIndex];
        transform.localPosition = newestTransform.position;
        transform.localRotation = newestTransform.rotation;
        transform.localScale = newestTransform.scale;
    }

    public void LateFixedUpdate()
    {
        m_newTransformIndex = OldTransformIndex();
        m_lastTransforms[m_newTransformIndex] = new TransformData(
                                                    transform.localPosition,
                                                    transform.localRotation,
                                                    transform.localScale);
    }

    void Update()
    {
        TransformData newestTransform = m_lastTransforms[m_newTransformIndex];
        TransformData olderTransform = m_lastTransforms[OldTransformIndex()];

        transform.localPosition = Vector3.Lerp(
                                    olderTransform.position,
                                    newestTransform.position,
                                    InterpolationController.InterpolationFactor);
        transform.localRotation = Quaternion.Slerp(
                                    olderTransform.rotation,
                                    newestTransform.rotation,
                                    InterpolationController.InterpolationFactor);
        transform.localScale = Vector3.Lerp(
                                    olderTransform.scale,
                                    newestTransform.scale,
                                    InterpolationController.InterpolationFactor);
    }

    private int OldTransformIndex()
    {
        return (m_newTransformIndex == 0 ? 1 : 0);
    }

    private struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public TransformData(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}