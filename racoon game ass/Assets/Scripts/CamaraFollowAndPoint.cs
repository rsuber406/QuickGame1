using System;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraFollowAndPoint : MonoBehaviour
{
    [SerializeField] GameObject cameraParent;
    /// <summary>
    /// DO NOT ATTACH THE CAMERA DIRECTLY
    /// The camera must be the child of an empty for this to function correctly.
    /// 
    /// </summary>

    [SerializeField] GameObject cameraViewTarget;
    /// <summary>
    /// This is the object that the camera will try to point to
    /// Do not make this the player, make it an empty so the camera view can
    /// be moved to another target.
    /// </summary>

    [SerializeField] GameObject cameraFollowTarget;
    /// <summary>
    /// This is the object that the camera parent will attempt to follow.
    /// Needed for soft follow and not to snap to position
    /// </summary>

    [SerializeField] float cameraAngleOfTolerance = 0.01f;
    /// <summary>
    /// This is the angle between camera parent and camera target in which the camera parent
    /// will not rotate. This is for the rotation only not the position.
    /// </summary>

    [SerializeField] float cameraFollowDistanceTolerance = 0.01f;
    /// <summary>
    /// How far the camera can be from X, Y, or Z before it starts moving
    /// </summary>

    [SerializeField] float cameraLerpAngleSpeed = 1.0f;
    [SerializeField] float cameraLerpDistanceSpeed = 0.1f;


    void Start()
    {
        if (cameraParent == null || cameraViewTarget == null || cameraFollowTarget == null)
        {
            Debug.Log("CAMERA IS SET UP INCORRECTLY");

            if (cameraParent == null)
            {
                Debug.Log("Camera parent not declared");
            }

            if (cameraViewTarget == null)
            {
                Debug.Log("Camera view target not declared");
            }

            if (cameraFollowTarget == null)
            {
                Debug.Log("Camera does not have an object to follow");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /// 
        /// Camera Follow Logic
        /// 

        if (
            (Math.Abs(cameraParent.transform.position.x - cameraFollowTarget.transform.position.x) > cameraFollowDistanceTolerance)
            ||
            (Math.Abs(cameraParent.transform.position.y - cameraFollowTarget.transform.position.y) > cameraFollowDistanceTolerance)
            ||
            (Math.Abs(cameraParent.transform.position.z - cameraFollowTarget.transform.position.z) > cameraFollowDistanceTolerance)
            )
        {
            //Camera needs to lerp to follow "Follow Target"
            cameraParent.transform.position = Vector3.Lerp(cameraParent.transform.position, cameraFollowTarget.transform.position, cameraLerpDistanceSpeed);
        }


        /// 
        /// Camera Rotation Logic
        /// 

        Vector3 cameraDirection = cameraViewTarget.transform.position - cameraParent.transform.position;
       
        Quaternion cameraRotation = Quaternion.LookRotation(cameraDirection);

        if (
            (Math.Abs(cameraParent.transform.rotation.x - cameraRotation.x) > cameraAngleOfTolerance)
            ||
            (Math.Abs(cameraParent.transform.rotation.y - cameraRotation.y) > cameraAngleOfTolerance)
            )
            //NO Z
        {
            //Camera needs to lerp to look at camera view target in all 3 dimensions
          cameraParent.transform.rotation =  Quaternion.Lerp(cameraParent.transform.rotation, cameraRotation, cameraLerpAngleSpeed *Time.deltaTime);
        }
    }
}
