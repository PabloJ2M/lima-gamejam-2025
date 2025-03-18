using UnityEngine;

public class ExternalKill : MonoBehaviour
{
    private const string _tag = "Player";
    private const string _method = "DeathMessage";

    public void OnDeath() => GameObject.FindWithTag(_tag)?.SendMessage(_method);
}