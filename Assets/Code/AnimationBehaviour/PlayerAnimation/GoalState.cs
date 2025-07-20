using UnityEngine;

namespace PlayerAnimation
{
    public class GoalState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo state_info, int layer_index)
        {
            PlayerInput pi = animator.GetComponent<PlayerInput>();
            if (pi != null) pi.Enabled(false); // 실제로 pi.'e'nabled(false)를 이용하면, 나중에 이상한 곳에서 null reference가 터질 가능성이 99%가 됨
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log(CustomSceneManager.instance);
            CustomSceneManager.instance.LoadScene(0);
        }
    }
}