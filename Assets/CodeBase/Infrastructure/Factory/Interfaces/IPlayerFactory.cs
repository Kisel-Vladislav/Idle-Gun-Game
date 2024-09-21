using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IPlayerFactory
    {
        PlayerBase Create(Vector3 at);
    }
}