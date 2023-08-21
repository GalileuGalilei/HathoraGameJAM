using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class BuildingBar : MonoBehaviour
{
    [SerializeField]
    private GameObject bar;
    [SerializeField]
    private float TimeToFinish = 5; //in seconds
    [SerializeField]
    private UnityEvent OnFinishBuilding;

    private float progress;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            progress += Time.deltaTime / TimeToFinish;
            bar.transform.localScale = new Vector3(progress, 1, 1);
        }
        else
        {
            progress = 0;
            bar.transform.localScale = new Vector3(progress, 1, 1);
        }

        if (progress >= 1)
        {
            OnFinishBuilding.Invoke();
            GameObject.Destroy(gameObject);
        }
    }
}
