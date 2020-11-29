using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesAndMissionDiary : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject[] missions;
    public GameObject[] missionChecks;
    public int noteToActive;
    public int missionToActive;

    public void MissionStart()
    {
        notes[noteToActive].SetActive(true);
        missions[missionToActive].SetActive(true);
        noteToActive++;
        missionToActive++;
    }

    public void MissionComplete(bool hasNoteEnd)
    {
        if (hasNoteEnd)
        {
            noteToActive++;
            notes[noteToActive - 1].SetActive(true);
        }
        missionChecks[missionToActive-1].SetActive(true);
    }
}
