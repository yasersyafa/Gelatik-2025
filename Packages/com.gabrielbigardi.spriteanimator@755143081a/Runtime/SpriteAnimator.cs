using System;
using UnityEngine;

namespace GabrielBigardi.SpriteAnimator
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private bool _playAutomatically = false;
        [SerializeField] private SpriteAnimationObject _spriteAnimationObject;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private SpriteAnimation _currentAnimation;
        private float _animationTime = 0f;
        private bool _paused = false;
        private bool _animationCompleted = false;

        public bool HasAnimation(string name) => _spriteAnimationObject.SpriteAnimations.Exists(a => a.Name == name);
        public SpriteAnimation DefaultAnimation => _spriteAnimationObject.SpriteAnimations.Count > 0 ? _spriteAnimationObject.SpriteAnimations[0] : null;
        private int GetLoopingFrame() => (int)_animationTime % _currentAnimation.Frames.Count;
        private int GetPlayOnceFrame() => Mathf.Min((int)_animationTime, _currentAnimation.Frames.Count - 1);

        // Events
        public event Action OnAnimationComplete;

        private void OnEnable()
        {
            if (_playAutomatically)
            {
                if (_spriteAnimationObject.SpriteAnimations[0] == null)
                {
                    Debug.LogError($"PlayAutomatically is set to TRUE but no default animations were found.");
                    return;
                }

                Play(DefaultAnimation);
            }
        }

        private void LateUpdate()
        {
            if (_paused || _spriteRenderer == null)
                return;

            Sprite currentFrame = UpdateAnimation(Time.deltaTime);

            if (currentFrame == null)
                return;

            _spriteRenderer.sprite = currentFrame;
        }

        public SpriteAnimator Play(string name, int startFrame = 0)
        {
            if (!HasAnimation(name))
            {
                Debug.LogError($"Animation with name '{name}' not found");
                return null;
            }

            Play(GetAnimationByName(name), startFrame);
            return this;
        }

        public SpriteAnimator Play(SpriteAnimation spriteAnimation, int startFrame = 0)
        {
            if (spriteAnimation == null || spriteAnimation.Frames.Count <= 0)
            {
                Debug.LogError("An null or invalid SpriteAnimation object was passed.");
                return null;
            }

            Resume();
            ChangeAnimation(spriteAnimation);
            SetCurrentFrame(startFrame);

            return this;
        }

        public SpriteAnimator PlayIfNotPlaying(string name, int startFrame = 0)
        {
            if (!HasAnimation(name))
            {
                Debug.LogError($"Animation with name '{name}' not found");
                return null;
            }

            PlayIfNotPlaying(GetAnimationByName(name), startFrame);
            return this;
        }

        public SpriteAnimator PlayIfNotPlaying(SpriteAnimation spriteAnimation, int startFrame = 0)
        {
            if (spriteAnimation == null)
            {
                Debug.LogError("An null or invalid SpriteAnimation object was passed.");
                return null;
            }

            if (_currentAnimation == null)
            {
                Resume();
                ChangeAnimation(spriteAnimation);
                SetCurrentFrame(startFrame);

                return this;
            }

            if (_currentAnimation.Name == spriteAnimation.Name)
                return null;
            Resume();
            ChangeAnimation(spriteAnimation);
            SetCurrentFrame(startFrame);

            return this;
        }

        public void Pause() => _paused = true;

        public void Resume() => _paused = false;

        public SpriteAnimator OnComplete(Action onAnimationComplete)
        {
            this.OnAnimationComplete = onAnimationComplete;
            return this;
        }

        public SpriteAnimation GetAnimationByName(string name)
        {
            for (int i = 0; i < _spriteAnimationObject.SpriteAnimations.Count; i++)
            {
                if (_spriteAnimationObject.SpriteAnimations[i].Name == name)
                {
                    return _spriteAnimationObject.SpriteAnimations[i];
                }
            }

            Debug.LogError($"Can't find animation named {name}");
            return null;
        }

        private void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            _animationCompleted = false;
            _animationTime = 0f;
            OnAnimationComplete = null;
            _currentAnimation = spriteAnimation;
        }

        public Sprite UpdateAnimation(float deltaTime)
        {
            if (_currentAnimation != null)
            {
                if (!_animationCompleted)
                {
                    _animationTime += deltaTime * _currentAnimation.FPS;

                    var frameDuration = 1f / _currentAnimation.FPS;
                    var animationDuration = frameDuration * (_currentAnimation.Frames.Count);
                    if (_animationTime >= (animationDuration * _currentAnimation.FPS))
                    {
                        OnAnimationComplete?.Invoke();

                        _animationTime = _currentAnimation.SpriteAnimationType == SpriteAnimationType.Looping ? 0f : _currentAnimation.Frames.Count;
                        _animationCompleted = _currentAnimation.SpriteAnimationType == SpriteAnimationType.Looping ? false : true;
                    }
                }

                return GetAnimationFrame();
            }

            return null;
        }

        private Sprite GetAnimationFrame()
        {
            int currentFrame = 0;

            switch (_currentAnimation.SpriteAnimationType)
            {
                case SpriteAnimationType.Looping:
                    currentFrame = GetLoopingFrame();
                    break;
                case SpriteAnimationType.PlayOnce:
                    currentFrame = GetPlayOnceFrame();
                    break;
            }

            return _currentAnimation.Frames[currentFrame];
        }

        public int GetCurrentFrame()
        {
            int currentFrame = 0;

            switch (_currentAnimation.SpriteAnimationType)
            {
                case SpriteAnimationType.Looping:
                    currentFrame = GetLoopingFrame();
                    break;
                case SpriteAnimationType.PlayOnce:
                    currentFrame = GetPlayOnceFrame();
                    break;
            }

            return currentFrame;
        }

        public void SetCurrentFrame(int frame)
        {
            if (frame < 0 || frame >= _currentAnimation.Frames.Count)
            {
                Debug.LogError($"Invalid frame index {frame} for animation '{_currentAnimation.Name}' with {_currentAnimation.Frames.Count} frames");
                return;
            }

            _animationTime = frame;
        }

        public void ChangeAnimationObject(SpriteAnimationObject spriteAnimationObject)
        {
            _spriteAnimationObject = spriteAnimationObject;
        }
    }
}