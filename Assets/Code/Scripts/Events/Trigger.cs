namespace UnityEngine.Events
{
    public class Trigger : Collide
    {
        private void OnTriggerEnter2D(Collider2D collision) => OnCollideEnter(collision);
        private void OnTriggerExit2D(Collider2D collision) => OnCollideExit(collision);
    }
}