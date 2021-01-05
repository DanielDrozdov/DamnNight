using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnController : MonoBehaviour
{
    public List<NoteAndKnifeObjManager> NoteSpawnPositions;
    private static int _noteCount = 3;
    private int _maxMainZoneNoteCount = 2;
    private int _totalMainZoneNoteCount = 0;

    void Start()
    {
        SpawnNotes();
    }
    private void SpawnNotes() {
        for(int i = 0; i < _noteCount; i++) {
            int rnd = Random.Range(0, NoteSpawnPositions.Count);
            NoteSpawnPositions[rnd].Activate();
            NoteSpawnPositions.RemoveAt(rnd);
        }
    }

    public static int GetNoteCount() {
        return _noteCount;
    }
}
