using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public static class Globals
{
    public static List<Vector3> chairPositions = new List<Vector3>();
    public static List<Vector3> takenChairs = new List<Vector3>();
    public static Vector3 doorPosition = new Vector3(0, 0, 0);
    public static List<Vector3> doorPositions = new List<Vector3>(new Vector3[] {
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
    });
    public static bool dayStarted = false;
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public static DayOfWeek currentDay = DayOfWeek.Monday;
    public static int week = 1;
}
