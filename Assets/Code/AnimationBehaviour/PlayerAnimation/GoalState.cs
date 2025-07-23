using UnityEngine;

namespace PlayerAnimation
{
    public class GoalState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo state_info, int layer_index)
        {
            PlayerInput pi = animator.GetComponent<PlayerInput>();
            if (pi != null) pi.Enabled(false); // ������ pi.'e'nabled(false)�� �̿��ϸ�, ���߿� �̻��� ������ null reference�� ���� ���ɼ��� 99%�� ��
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // ���߿� Cutscene �����ؼ� �Ѿ�� ���� ���� + ���� ��ɰ��� �������. ������ �ϴ� �׽�Ʈ���̶� �����ϵ���.
            CustomSceneManager.instance.GoToNextScene();
        }
    }
}