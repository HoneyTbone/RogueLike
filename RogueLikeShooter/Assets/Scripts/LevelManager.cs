using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.MemoryProfiler;


//using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelManager : MonoBehaviour
{
    [Header("Rooms List")]
    public List<GameObject> Rooms;
    public List<GameObject> RandRooms;
    public List<GameObject> Connections; 
    public List<GameObject> RandConnections; 


    private Transform posToSpawn;

    [Header("Level Settings")]
    [SerializeField] int numberOfRoomsToBuild;

    // Start is called before the first frame update

    void Start()
    {
        BuildRooms(numberOfRoomsToBuild);
    }
    void BuildRooms(int roomCount)
    {
        posToSpawn = this.transform;
        var yRot = 0;
        int connectionCounter = 1;
        for (int i = roomCount; i > 0; i--)
        {
            var randomRoom = Rooms[Random.Range(0,Rooms.Count)];
            var randomConnection = Connections[Random.Range(0,Connections.Count)];
            RandRooms.Add(randomRoom);
            RandConnections.Add(randomConnection);
                
        }
        foreach(GameObject room in RandRooms)
        {
                // Rotation of previous, not current
                GameObject newRoom = Instantiate(room, posToSpawn.position, Quaternion.Euler(0, yRot, 0));
                yRot = newRoom.GetComponent<Room>().exitRotation;
                Debug.Log(yRot);
                posToSpawn = newRoom.GetComponent<Room>().exitPoint;
                if(connectionCounter < RandRooms.Count)
                {
                    GameObject newConnetion = Instantiate(RandConnections[Random.Range(0, RandConnections.Count)], posToSpawn.position, Quaternion.Euler(0, yRot, 0));
                    yRot = newConnetion.GetComponent<Room>().exitRotation;
                    Debug.Log(yRot);
                    posToSpawn = newConnetion.GetComponent<Room>().exitPoint;
                    connectionCounter++;
                }
        }
        
    }
}
