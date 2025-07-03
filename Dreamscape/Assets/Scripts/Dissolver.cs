using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    //Object disappears
    public float dissolveTime = 2;
    public float dissolveStrength;

    public Color startColour;
    public Color endColour;

    bool isLerped = false;

    public void DissolverStart()
    {
        StartCoroutine(dissolver());
    }

    public IEnumerator dissolver()
    {
        float timePassed = 0;
        Color lerpedColour;
        Material dissolveMaterial = GetComponent<Renderer>().material;

        while(timePassed < dissolveTime)
        {
            timePassed += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0, 1, timePassed / dissolveTime); //lerping the time
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);

            lerpedColour = Color.Lerp(startColour, endColour, dissolveStrength); //lerping the colour
            dissolveMaterial.SetColor("_Color", lerpedColour);
            
            yield return null;
        }
        isLerped = true;
    }

    private void Update()
    {
        if (isLerped)
        {
            Destroy(gameObject);
        }
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") 
        {
            DissolverStart();
        }
    }
}
