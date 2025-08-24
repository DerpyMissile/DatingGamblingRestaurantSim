using UnityEngine;
using System.Linq;
using System.Collections;

public class Customer : MonoBehaviour
{
    // Variables
    bool isSeated = false;
    bool doneActions = false;
    bool exiting = false;
    bool calledAngry = false;
    bool slowlyMakeRed = false;
    float fustrationTimer = 10f;
    float seatTimer = 5f;
    Vector3 targetSeat;
    Vector3 targetDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond); // Seed rng
        Debug.Log(Globals.chairPositions.Count);
        int randomIndex = Random.Range(0, Globals.chairPositions.Count);
        targetSeat = Globals.chairPositions[randomIndex];
        int randomDoorIndex = Random.Range(0, Globals.doorPositions.Count);
        targetDoor = Globals.doorPositions[randomDoorIndex];
    }

    void CheckSeatValidity()
    {
        // If the target seat is already taken, find a new one
        bool isAnyMoreSeatsLeft = Globals.chairPositions.All(seat => Globals.takenChairs.Contains(seat));   // if bool true this means that globals.chairpositions is entirely contained in globals.takenChairs
        if (isAnyMoreSeatsLeft && !calledAngry)
        {
            Debug.Log("No seats? *megamind meme*");
            StartCoroutine(AngryTimer());
            calledAngry = true;
            return;
        }
        if (Globals.takenChairs.Contains(targetSeat))
        {
            // Grab another one
            int randomIndex = Random.Range(0, Globals.chairPositions.Count);
            targetSeat = Globals.chairPositions[randomIndex];
        }
        else
        {
            StopAllCoroutines(); // nuke :3
            calledAngry = false; // reset anger
        }
    }

    IEnumerator AngryTimer()
    {
        slowlyMakeRed = true;
        yield return new WaitForSeconds(fustrationTimer);
        isSeated = false;
        doneActions = true;
        while (Vector3.Distance(transform.position, targetDoor) > 0.1f)
        {
            // Move towards the door
            transform.position = Vector3.MoveTowards(transform.position, targetDoor, Time.deltaTime * 2f);
            yield return null; // Wait for the next frame
        }
        StopAllCoroutines();
        exiting = true;
    }

    IEnumerator SeatTimer()
    {
        yield return new WaitForSeconds(seatTimer);
        isSeated = false;
        Globals.takenChairs.Remove(targetSeat);
        Debug.Log("Customer left the seat.");
        doneActions = true;
        while (Vector3.Distance(transform.position, targetDoor) > 0.1f)
        {
            // Move towards the door
            transform.position = Vector3.MoveTowards(transform.position, targetDoor, Time.deltaTime * 2f);
            yield return null; // Wait for the next frame
        }
        StopAllCoroutines();
        exiting = true;
        Globals.currency += 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Randomly walk to a chair position from Globals
        if (!isSeated && Globals.chairPositions.Count > 0 && !Globals.takenChairs.Contains(targetSeat) && !doneActions)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetSeat, Time.deltaTime * 2f);

            // Check if reached the chair position
            if (Vector3.Distance(transform.position, targetSeat) < 0.1f)
            {
                Debug.Log(transform.position);
                Debug.Log(targetSeat);
                isSeated = true;
                Globals.takenChairs.Add(targetSeat);
                StartCoroutine(SeatTimer());
            }
        }
        if (!isSeated && !doneActions && Globals.chairPositions.Count > 0)
        {
            CheckSeatValidity();
        }
        if (exiting)
        {
            // Destroy the customer object if they have left
            Destroy(gameObject);
        }
        if (slowlyMakeRed)
        {
            // Slowly change the color to red
            Color currentColor = GetComponent<Renderer>().material.color;
            currentColor.r = Mathf.Min(currentColor.r + Time.deltaTime * 0.1f, 1f);
            GetComponent<Renderer>().material.color = currentColor;

            if (currentColor.r >= 1f)
            {
                slowlyMakeRed = false; // Stop changing color once fully red
            }
        }
    }
}
