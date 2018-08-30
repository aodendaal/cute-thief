using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class GuardNoises : MonoBehaviour
{
    public AudioClip[] audioClips;
    [Space]
    public GameObject speechBubble;

    private AudioSource source;

    private float speechBubbleTime;

    private float TalkTime;
    private float TalkRate = 10f;

    // Use this for initialization
    private void Start()
    {
        source = GetComponent<AudioSource>();
        SetTalkTime();
    }

    // Update is called once per frame
    private void Update()
    {
        if (TalkTime < Time.time)
        {
            source.clip = audioClips[Random.Range(0, audioClips.Length)];
            source.Play();

            speechBubble.SetActive(true);
            speechBubbleTime = Time.time + source.clip.length;

            SetTalkTime();
        }

        if (speechBubbleTime < Time.time && speechBubble.activeSelf)
        {
            speechBubble.SetActive(false);
        }
    }

    private void SetTalkTime()
    {
        TalkTime = Time.time + TalkRate + Random.Range(-2f, 2f);
    }
}