using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 50f;
    private GameObject _gazedAtObject;
    private PointerEventData _eventData;

    private void Start()
    {
        _eventData = new PointerEventData(EventSystem.current);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        if (Physics.Raycast(transform.position, transform.forward, out var hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                //New GameObject.
                if (_gazedAtObject)
                    _gazedAtObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.GetComponent<IPointerEnterHandler>()?.OnPointerEnter(_eventData);
                //_gazedAtObject?.SendMessage("OnPointerExit");
                //_gazedAtObject = hit.transform.gameObject;
                //_gazedAtObject?.SendMessage("OnPointerEnter");
            }
        }
        else if (_gazedAtObject)
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
            //_gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (_gazedAtObject != null && Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            _gazedAtObject.GetComponent<IPointerClickHandler>()?.OnPointerClick(_eventData);
            //_gazedAtObject?.SendMessage("OnPointerClick");
        }
    }
}
