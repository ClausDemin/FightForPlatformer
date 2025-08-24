using Assets.Codebase.GameLogic.Common.Actor.Player;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.CameraControls
{
    public class CameraFollow : MonoBehaviour
    {

        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerComponent _player;
        [SerializeField] private Vector3 _offset;

        private void Update()
        {
            if (_player != null) 
            {
                _camera.transform.position = _player.transform.position + _offset;
            }
        }

        public void Init(PlayerComponent player) 
        { 
            _player = player;
        }
    }
}
