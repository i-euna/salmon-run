using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TMP_Text percentage;


    private void Start()
    {
        instance = this;
        ProgressImage = GetComponent<Image>();
        
    }

    private void Update()
    {
        CalculateTotalDistance();
        if (AliveFish != null && !GameOverManager.instance.isGameOver)
        {
            CalculateCrossedDistance();
            //UpdateProgressPar();
        }
        float Progres = 0.0f;
        if (TotalDistance >= CrossedDistance)
            Progres = (CrossedDistance / TotalDistance)*100;
        else Progres = 0;
        Debug.Log("TotalDistance: " + TotalDistance);
        Debug.Log("CrossedDistance: " + CrossedDistance);
        int dist = 100-(int)Progres;
        percentage.text = dist.ToString() + "m"; 

        
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
