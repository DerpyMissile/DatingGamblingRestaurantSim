using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayBroker : MonoBehaviour
{
    [Header("Objects in Scene")]
    public Button startDayButton;
    public TextMeshProUGUI currTimeText;
    public TextMeshProUGUI currDayText;
    public void StartDay()
    {
        Globals.dayStarted = true;
        // chairPositions.Clear();
        // takenChairs.Clear();
        // doorPosition = new Vector3(0, 0, 0);
        startDayButton.gameObject.SetActive(false);
    }
}
