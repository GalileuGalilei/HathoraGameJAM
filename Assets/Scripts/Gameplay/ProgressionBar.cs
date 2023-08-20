using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressionBar : MonoBehaviour
{
    [SerializeField]
    private float StartX;
    [SerializeField]
    private float FinalX;
    [SerializeField]
    private float TimeUntilEnd = 60.0f;

    Image spaceShip;

    public UnityEvent OnFinishTimer;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<Image>();
        StartCoroutine(MoveSpaceShip());
    }

    public void SpeedUp(float multiplier)
    {
        TimeUntilEnd /= multiplier;
    }

    IEnumerator MoveSpaceShip()
    {
        float time = 0.0f;
        while (time < TimeUntilEnd)
        {
            float newX = Mathf.Lerp(StartX, FinalX, time / TimeUntilEnd);
            spaceShip.rectTransform.anchoredPosition = new Vector2(newX, spaceShip.rectTransform.anchoredPosition.y);
            time += Time.deltaTime;
            yield return new WaitForSeconds(2);
        }

        OnFinishTimer.Invoke();
    }
}
