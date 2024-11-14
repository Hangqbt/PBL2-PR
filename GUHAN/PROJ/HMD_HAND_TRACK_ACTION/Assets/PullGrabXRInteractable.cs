using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PullGrabXRInteractable : XRGrabInteractable
{
    private XRRayInteractor rayInteractor;
    private Vector3 previousPos;

    private void update()
    {
        if(isSelected && firstInteractorSelecting is XRRayInteractor)
        {
            Vector3 velocity = (rayInteractor.transform.position - previousPos)/ Time.deltaTime;
            previousPos = rayInteractor.transform.position;
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject is XRRayInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;

            rayInteractor = (XRRayInteractor)args.interactorObject;
            previousPos = rayInteractor.transform.position;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }
        base.OnSelectEntered(args);
    }

}

