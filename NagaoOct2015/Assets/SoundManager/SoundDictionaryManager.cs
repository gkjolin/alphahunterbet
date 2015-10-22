using System;
using System.Collections.Generic;
using UnityEngine;

    public class SoundDictionaryManager: MonoBehaviour,ISoundDictionary
    {
        //Always include the inspectionary attribute for custom inspectionaries to enable the custom inspector drawer display
        [Inspectionary("Name", "Audio Clip")]
        public SoundDictionary _soundDictionary;
        public AudioClip defaultAudioClip;

        void Start()
        {
            DontDestroyOnLoad(this);
        }

        public AudioClip audioClipValue(string key)
        {
            return _soundDictionary.ContainsKey(key) ? _soundDictionary[key] : defaultAudioClip;
        } 

        private void OnEnable()
        {
            //Use it just like a normal dictionary
            foreach (KeyValuePair<string, AudioClip> kvp in _soundDictionary)
            {
                Debug.Log(kvp.Key);
            }
        }
    }

    //Simple dictionary example
    [Serializable]
    public class SoundDictionary : SerializableDictionary<string, AudioClip> { }
