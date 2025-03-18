using System;

namespace UnityEngine.Events
{
    public abstract class Collide : MonoBehaviour
    {
        [Flags] private enum Interaction { Enter = 1, Exit = 2 }

        [SerializeField] private string _tag;
        [SerializeField] private Interaction _interaction;
        [SerializeField] private UnityEvent<Collider2D> _onCollide, _onCollideEnter, _onCollideExit;

        protected void OnCollideEnter(Collider2D collision)
        {
            if (!_interaction.HasFlag(Interaction.Enter)) return;
            _onCollide.Invoke(collision);
            _onCollideEnter.Invoke(collision);
        }
        protected void OnCollideExit(Collider2D collision)
        {
            if (!_interaction.HasFlag(Interaction.Exit)) return;
            _onCollide.Invoke(collision);
            _onCollideExit.Invoke(collision);
        }
    }
}