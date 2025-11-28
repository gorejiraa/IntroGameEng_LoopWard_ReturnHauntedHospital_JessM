using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    public bool triggerOnce = true;
    public MonoBehaviour playerMovementScript; // Your movement script
    public MonoBehaviour playerCameraScript;   // Your camera look script

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerOnce && hasTriggered)
                return;

            if (timelineToPlay != null)
            {
                // Disable player movement
                if (playerMovementScript != null)
                {
                    playerMovementScript.enabled = false;
                }

                // Disable camera control
                if (playerCameraScript != null)
                {
                    playerCameraScript.enabled = false;
                }

                // Play timeline
                timelineToPlay.Play();
                hasTriggered = true;

                // Subscribe to timeline finished event
                timelineToPlay.stopped += OnTimelineFinished;
            }
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Re-enable player movement
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }

        // Re-enable camera control
        if (playerCameraScript != null)
        {
            playerCameraScript.enabled = true;
        }

        // Unsubscribe from event
        director.stopped -= OnTimelineFinished;
    }
}