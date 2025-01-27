using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace UnityEngine.SceneManagement
{
    public class SceneController : SingletonBasic<SceneController>
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private FadeScene _fade;
        [SerializeField] private string[] _ignore;

        [SerializeField] private UnityEvent<bool> _onSceneOverlap;

        public List<string> scenes { get; protected set; }
        private bool _lock;

        protected override void Awake() { base.Awake(); scenes = new(); }
        public void CutScene(string value) => SceneManager.LoadScene(value);
        public void SwipeScene(string value) => OnFading(value);
        public void Quit() => OnFading(string.Empty);

        public IEnumerator AddScene(string value)
        {
            if (scenes.Contains(value)) yield break;
            yield return SceneManager.LoadSceneAsync(value, LoadSceneMode.Additive);
            if (!_ignore.Contains(value)) _onSceneOverlap.Invoke(false);
            scenes.Add(value);
        }
        public void RemoveScene(string value)
        {
            if (!scenes.Contains(value)) return;
            SceneManager.UnloadSceneAsync(value, UnloadSceneOptions.None);
            if (!_ignore.Contains(value)) _onSceneOverlap.Invoke(true);
            scenes.Remove(value);
        }
        private void OnFading(string value)
        {
            if (_lock) return;
            FadeScene fade = Instantiate(_fade, transform);
            fade.onComplete += onComplete;
            fade.onUpdate += onUpdate;
            _lock = true;

            void onUpdate(float value) { if (_source) _source.volume = 1 - value; }
            void onComplete()
            {
                Time.timeScale = 1;
                if (string.IsNullOrEmpty(value)) Application.Quit();
                else SceneManager.LoadSceneAsync(value, LoadSceneMode.Single);
            }
        }
    }
}