using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float floatSpeed = 500;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;

    RectTransform rTransform;
    Color starlingColor;

    float timeElapsed = 0.0f;

    void Start(){
        starlingColor = textMesh.color;
        rTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(starlingColor.r, starlingColor.g, starlingColor.b, 1 - (timeElapsed / timeToLive));

        if(timeElapsed > timeToLive){
            Destroy(gameObject);
        }
    }
}
