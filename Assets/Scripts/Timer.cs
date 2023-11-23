using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TimeManeger tm;

    public bool TeleportBack = false;
    public GameObject Clock;
    public GameObject PrefabClock;
    public float TimeLeftSave;

    Vector2 ClockPlacement;
    // Start is called before the first frame update
    void Start()
    {
        ClockPlacement = new Vector2(Clock.transform.position.x, Clock.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(TeleportBack == true)
		{
            transform.position = ClockPlacement- new Vector2(1,0);
            Instantiate(PrefabClock, ClockPlacement, Quaternion.identity);

            TeleportBack = false;
            tm.TimeLeft = TimeLeftSave;
		}
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clock"))
        {
            
            Destroy(other.gameObject);
            tm.TimerOn = true;
        }
    }
}
