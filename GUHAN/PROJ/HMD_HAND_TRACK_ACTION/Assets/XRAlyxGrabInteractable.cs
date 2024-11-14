using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRAlyxGrabInteractable : XRGrabInteractable
{
    private XRRayInteractor rayInteractor;
    private Vector3 previousPos;
    public float velocityThreshold = 1.5f;
    private Rigidbody interactableRigidbody;
    public float jumpAngleInDegree = 60;
    private bool canJump = true;
    public float boostAmount = 2f; // Small upward boost to help lift off from the ground

    protected override void Awake()
    {
        base.Awake();
        interactableRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactorObject is XRRayInteractor interactor)
        {
            rayInteractor = interactor;
            previousPos = rayInteractor.transform.position;
            canJump = true;

            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }
    }

    private void Update()
    {
        if (isSelected && rayInteractor != null && canJump)
        {
            Vector3 currentPos = rayInteractor.transform.position;
            Vector3 velocity = (currentPos - previousPos) / Time.deltaTime;
            previousPos = currentPos;

            if (velocity.magnitude > velocityThreshold)
            {
                canJump = false;
                interactableRigidbody.isKinematic = false;
                Vector3 computedVelocity = ComputeVelocity();
                interactableRigidbody.velocity = computedVelocity;
                Drop();
            }
        }
    }

    private Vector3 ComputeVelocity()
    {
        Vector3 diff = rayInteractor.transform.position - transform.position;
        Vector3 diffXZ = new Vector3(diff.x, 0, diff.z);
        float diffXZLength = diffXZ.magnitude;
        float diffYLength = diff.y;

        float angleInRadian = jumpAngleInDegree * Mathf.Deg2Rad;

        float jumpSpeed = Mathf.Sqrt(
            -Physics.gravity.y * Mathf.Pow(diffXZLength, 2) /
            (2 * Mathf.Cos(angleInRadian) * Mathf.Cos(angleInRadian) *
            (diffXZLength * Mathf.Tan(angleInRadian) - diffYLength))
        );

        Vector3 jumpVelocityVector = diffXZ.normalized * Mathf.Cos(angleInRadian) * jumpSpeed
                                     + Vector3.up * Mathf.Sin(angleInRadian) * jumpSpeed
                                     + Vector3.up * boostAmount; // Apply upward boost

        return jumpVelocityVector;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        rayInteractor = null;
        canJump = true;
    }
}
