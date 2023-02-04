using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;
    public GameObject StartPoint;
    public GameObject EndPoint;
    //public GameObject MainCamera;

    public Transform AliveFish;

    private Image ProgressImage;

    float TotalDistance = 0.0f;
    float CrossedDistance = 0.0f;


    private void Start()
    {
        instance = this;
        ProgressImage = GetComponent<Image>();
        CalculateTotalDistance();
    }

    private void Update()
    {
        if(AliveFish != null)
        {
            CalculateCrossedDistance();
            UpdateProgressPar();
        }
    }

    void UpdateProgressPar() {
        
        float Progres = 0.0f;
        if (TotalDistance >= CrossedDistance)
            Progres = CrossedDistance / TotalDistance;
        else Progres = 0;

        ProgressImage.fillAmount = Progres;


        float angle = Mathf.Atan2(AliveFish.transform.position.y - EndPoint.transform.position.y, AliveFish.transform.position.x - EndPoint.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
    }

    void CalculateTotalDistance() {
        TotalDistance = Vector3.Distance(StartPoint.transform.position, EndPoint.transform.position);
    }

    void CalculateCrossedDistance()
    {
        CrossedDistance = Vector3.Distance(StartPoint.transform.position, AliveFish.transform.position);
    }
}
