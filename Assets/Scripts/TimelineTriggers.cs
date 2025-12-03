using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timelineToPlay;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered entered");
        if (other.tag == "Player")
        {
            Debug.Log("Player in trigger");
            timelineToPlay.Play();
        }
    }
}