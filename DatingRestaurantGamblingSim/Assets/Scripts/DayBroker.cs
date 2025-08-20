using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayBroker : MonoBehaviour
{
    [Header("Objects in Scene")]
    public Button startDayButton;
    public TextMeshProUGUI currTimeText;
    public TextMeshProUGUI currDayText;
    public TextMeshProUGUI currMoneyText;

    // Private variables
    private float time = 0f;
    public void StartDay()
    {
        Globals.dayStarted = true;
        // chairPositions.Clear();
        // takenChairs.Clear();
        // doorPosition = new Vector3(0, 0, 0);
        startDayButton.gameObject.SetActive(false);
    }

    public void Start()
    {

    }

    public void Update()
    {
        currMoneyText.text = "Profit: $" + Globals.currency.ToString("N0");
        if (Globals.dayStarted && !Globals.dayOver)
        {
            // Update the current time and day text
            time += Time.deltaTime * 10;
            // currTimeText.text = "Time: " + System.DateTime.Now.ToString("HH:mm");
            // Let's say that 1 second in real life is 1 minute in the game
            int hours = Mathf.FloorToInt(time / 60f) + 8; // Start at 8 AM
            int minutes = Mathf.FloorToInt(time % 60f);
            if (hours / 12 >= 1)
            {
                hours -= 12; // Convert to 12-hour format
                currTimeText.text = $"{hours:D2}:{minutes:D2} PM";
                if (hours == 5)
                {
                    // 5 pm time to clock out
                    Globals.dayOver = true;
                }
            }
            else
            {
                currTimeText.text = $"{hours:D2}:{minutes:D2} AM";
            }

            currDayText.text = "Day: " + Globals.currentDay.ToString() + " (Week " + Globals.week + ")";
        }
        else
        {
            // Show the start day button if the day hasn't started
            startDayButton.gameObject.SetActive(true);
        }
    }
}
