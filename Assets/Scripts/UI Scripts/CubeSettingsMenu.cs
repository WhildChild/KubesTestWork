using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeSettingsMenu : MonoBehaviour
{
    #region Constants
    private const float StandartSpeed = 1f;
    private const float StandartDistance = 3f;
    private const float StandartTimeToSpawn = 5f;
    private const string invalidValueMessage = "Было введено неверное значение. Заменено на значение по-умолчанию";
    #endregion

    [Header("InputFields")]
    [SerializeField]
    private TMP_InputField speedTextField;
    [SerializeField]
    private TMP_InputField distanceTextField;
    [SerializeField]
    private TMP_InputField timeToSpawnTextField;

    [Header("Buttons")]
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button stopButton;

    [Header("Others")]
    [SerializeField]
    private CubeSpawner spawner;
    [SerializeField]
    private GameObject inputFieldsPanel;

    private CustomLogger customLogger;

    private void Start()
    {
        customLogger = GetComponent<CustomLogger>();
        startButton.onClick.AddListener(OnStartButtonClick);
        stopButton.onClick.AddListener(OnStopButtonClick);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(OnStartButtonClick);
        stopButton.onClick.RemoveListener(OnStopButtonClick);
    }

    #region Calculate Values From InputFields
    //Можно было бы свернуть 3 метода в один, предоставляя на вход InputField и defaultValue, но
    //оставляю возможность смены типа данных
    //с float на например int и тогда в методе придётся использовать парсер другого типа.
    //В этом случае разделение оправдано.
    private float GetSpeedFromTextField()
    {
        float.TryParse(speedTextField.text, out float result);
        if (result <=0) 
        {
            result = StandartSpeed;
            customLogger.WriteMessage(invalidValueMessage);
        }
        return result;
    }

    private float GetDistanceFromTextField()
    {
        float.TryParse(distanceTextField.text, out float result);
        if (result <= 0f)
        {
            result = StandartDistance;
            customLogger.WriteMessage(invalidValueMessage);
        }
        return result;
    }

    private float GetTimeToSpawnFromTextField()
    {
        float.TryParse(timeToSpawnTextField.text, out float result);
        if (result <= 0f)
        {
            result = StandartTimeToSpawn;
            customLogger.WriteMessage(invalidValueMessage);
        }
        return result;
    }
    #endregion

    public void OnStartButtonClick()
    {
        spawner.StartSpawn(GetSpeedFromTextField(), GetTimeToSpawnFromTextField(), GetDistanceFromTextField());
        stopButton.gameObject.SetActive(true);
        inputFieldsPanel.SetActive(false);
    }
    public void OnStopButtonClick() 
    {
        spawner.StopSpawn();
        stopButton.gameObject.SetActive(false);
        inputFieldsPanel.SetActive(true);
    }
}
