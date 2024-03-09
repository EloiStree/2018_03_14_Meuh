using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Meuh : MonoBehaviour {
    
    public Quaternion _lastRotation;
    public Quaternion _currentRotation;
    public float _angleToTrigger = 180;

    public UnityEvent _meuhDetected;
    public MeuhCompletionEvent _pourcentComplete;

    
    public float _pourcentToMeuh;
    public Text _ViewAngle;
    [System.Serializable]
    public class MeuhCompletionEvent : UnityEvent<float> { }
    
    void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        _currentRotation = Input.gyro.attitude;
        float currentAngleFromPrevious = Quaternion.Angle(_currentRotation, _lastRotation);

        _pourcentToMeuh = currentAngleFromPrevious / _angleToTrigger;
        _pourcentComplete.Invoke(_pourcentToMeuh);

        if (_ViewAngle)
            _ViewAngle.text = "" + ( (int) currentAngleFromPrevious);// +" ("+ _currentRotation+"  -  "+_lastRotation+" )";

        if (currentAngleFromPrevious >= _angleToTrigger)
        {
            _meuhDetected.Invoke();
            _lastRotation = _currentRotation;
        }
		
	}
}
