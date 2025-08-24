using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Ground
{
    public class GroundChecker
    {
        private const string GroundLayerName = "Ground";
        private LayerMask _ground = LayerMask.GetMask(GroundLayerName);

        public bool CheckGround(Vector2 position, float epsilon = 0.01f) 
        {
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, epsilon, _ground);

            if (hit.collider != null && hit.collider.GetComponent<GroundComponent>() != null)
            {
                return hit.distance <= epsilon;
            }
            
            return false;
        }
    }
}
