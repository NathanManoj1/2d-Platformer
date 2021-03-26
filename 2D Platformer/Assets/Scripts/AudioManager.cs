using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip[] _songs;
    private AudioClip _currentSong;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _currentSong = _songs[0];
        _source.clip = _songs[0];
        _source.Play();
        for(int i = 1; i < 5; i++)
        {
            yield return new WaitForSeconds(_currentSong.length);
            _source.clip = _songs[i];
            _currentSong = _songs[i];
            _source.Play();
            if (i == 3)
                i = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
