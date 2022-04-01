using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonToggler : MonoBehaviour
{
    [SerializeField] private GameObject _toggler;
    [SerializeField] private CanvasRenderer _backCanvas;
    [SerializeField] private Material _OnColorMat;
    [SerializeField] private Material _OffColorMat;
    [SerializeField] private bool _switchState = false;
    [SerializeField] private float _speed = 3.0F; // Movement speed in units per second.
    private Vector3 _togglerOnPosition;
    private Vector3 _togglerOffPoistion;
    
    // Start is called before the first frame update
    private void Start()
    {
        _togglerOffPoistion = this.GetComponentInChildren<TogglerOffPoseMarker>().transform.position;
        _togglerOnPosition = this.GetComponentInChildren<TogglerOnPoseMarker>().transform.position;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_switchState == true)
            SwitchOn();
        else
            SwitchOff();
    }

    private void SwitchOff()
    {
        var startPosition = _toggler.transform.position;
        _toggler.transform.position = Vector3.Lerp(startPosition, _togglerOffPoistion, _speed * Time.deltaTime);
        _backCanvas.SetMaterial(_OffColorMat, 0);
    }

    private void SwitchOn()
    {
        var startPosition = _toggler.transform.position;
        _toggler.transform.position = Vector3.Lerp(startPosition, _togglerOnPosition, _speed * Time.deltaTime);
        _backCanvas.SetMaterial(_OnColorMat, 0);
    }
}
