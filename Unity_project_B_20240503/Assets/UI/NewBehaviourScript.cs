using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform targetObject;
    public Slider slider;
    public Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
        if(targetObject != null && slider != null)
        {
         
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position);
            
            RectTransform canvasRect = slider.GetComponent<Camera>().GetComponent<RectTransform>();
            Vector2 cavasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out cavasPos);

            slider.transform.localPosition = cavasPos;
        }
    }
}
