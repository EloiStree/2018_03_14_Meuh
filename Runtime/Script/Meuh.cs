using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Meuh : MonoBehaviour {
    
    public Quaternion m_lastRotation;
    public Quaternion m_currentRotation;
    public float m_angleToTrigger = 180;

    public UnityEvent m_meuhDetected;
    public MeuhCompletionEvent m_pourcentComplete;

    
    public float m_pourcentToMeuh;
    public Text m_viewAngle;
    [System.Serializable]
    public class MeuhCompletionEvent : UnityEvent<float> { }
    
    void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        m_currentRotation = Input.gyro.attitude;
        float currentAngleFromPrevious = Quaternion.Angle(m_currentRotation, m_lastRotation);

        m_pourcentToMeuh = currentAngleFromPrevious / m_angleToTrigger;
        m_pourcentComplete.Invoke(m_pourcentToMeuh);

        if (m_viewAngle)
            m_viewAngle.text = "" + ( (int) currentAngleFromPrevious);// +" ("+ _currentRotation+"  -  "+_lastRotation+" )";

        if (currentAngleFromPrevious >= m_angleToTrigger)
        {
            m_meuhDetected.Invoke();
            m_lastRotation = m_currentRotation;
        }
		
	}
}
