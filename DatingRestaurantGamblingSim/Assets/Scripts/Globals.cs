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
        new Vector3(0, 4, 0),
        new Vector3(0, -4, 0),
    });
    public static bool dayStarted = false;
    public static bool dayOver = false;
    public static int reputation = 999;
    public static int currency = 0;
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
    public static List<SpecialNPCData> inStore = new List<SpecialNPCData>(); // We don't wanna spawn in the guys we already have
}
