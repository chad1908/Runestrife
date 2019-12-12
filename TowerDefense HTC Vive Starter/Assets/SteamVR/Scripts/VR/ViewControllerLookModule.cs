using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class OcculusGazeInputModule : PointerInputModule
{
    //A reference to the camera attached to the right controller.
    public Camera ControllerCamera;
    //This holds a reference to the right controller itself, to be able to get its input.
    public SteamVR_TrackedObject RightController;
    //Reference to the Reticle.
    public GameObject reticle;
    //A reference to the Laser.
    public Transform laserTransform;
    //Holds the right controller transform.
    private Transform rightControllerTransform;
    // The size of the reticle will get scaled with this value
    public float reticleSizeMultiplier = 0.02f;
    //This stores all events that will happen with the virtual pointer.
    private PointerEventData pointerEventData;
    //Stores the result of the raycasts into the scene from the controller camera.
    private RaycastResult currentRaycast;
    //This holds the IPointerClick events that should happen when the player presses the controller’s trigger button.
    private GameObject currentLookAtHandler;

    public override void Process()
    {
        HandleLook();
        HandleSelection();
    }

    void HandleLook()
    {
        //If there’s no PointerEventData yet for the current Event System, create a new one.
        if (pointerEventData == null)
        {
            pointerEventData = new PointerEventData(eventSystem);
        }
        //Sets the position of the virtual pointer to the center of the screen.
        pointerEventData.position = ControllerCamera.
        ViewportToScreenPoint(new Vector3(.5f, .5f));
        //Create a list to hold the results of the raycasts shot into the scene.
        List<RaycastResult> raycastResults = new
        List<RaycastResult>();
        //Do a raycast for every enabled raycaster in the scene (both for the UI and 3D colliders).
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        //Get the first hit of any raycast and save it.
        currentRaycast = pointerEventData.pointerCurrentRaycast =
        FindFirstRaycast(raycastResults);
        //Move the reticle to the point where the raycast hit.
        reticle.transform.position = rightControllerTransform.position
        + (rightControllerTransform.forward
        * currentRaycast.distance);
        //Move the laser right between the controller and the reticle.
        laserTransform.position = Vector3.Lerp(
        rightControllerTransform.position, reticle.transform.
        position, .5f);
        //Let the laser look at the reticle.
        laserTransform.LookAt(reticle.transform);
        //Size the laser’s Z-scale by the distance between the controller and the reticle.
        laserTransform.localScale = new Vector3(
        laserTransform.localScale.x, laserTransform.localScale.y,
        currentRaycast.distance);
        //1Resize the reticle based on the distance from the controller and the reticleSizeMultiplier.
        float reticleSize = currentRaycast.distance *
        reticleSizeMultiplier;
        //Scale reticle so it’s always the same size
        reticle.transform.localScale = new Vector3(reticleSize,
        reticleSize, reticleSize);
        //Pass the pointer data to the Event System so the entering and exiting of objects are handled correctly.
        ProcessMove(pointerEventData);
    }

    void Awake()
    {
        rightControllerTransform = RightController.transform;
    }

    private bool IsTriggerPressed()
    {
        return SteamVR_Controller.Input((int)
        RightController.index).GetPressDown(
        EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    void HandleSelection()
    {
        //1
        if (pointerEventData.pointerEnter != null)
        {
            //2
            currentLookAtHandler = ExecuteEvents.GetEventHandler
            <IPointerClickHandler>(pointerEventData.pointerEnter);
            //3
            if (currentLookAtHandler != null && IsTriggerPressed())
            {
                //4
                ExecuteEvents.ExecuteHierarchy(currentLookAtHandler,
                pointerEventData, ExecuteEvents.pointerClickHandler);
            }
        }
        else
        { //5
            currentLookAtHandler = null;
        }
    }
}

