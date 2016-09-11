using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using MovementEffects;

namespace SLEngine.GameState
{
	public class GameStateManager {
		#region private member
		private GameState m_currentState;
		private bool m_isLoadingScene = false;
		#endregion

		#region public function
		public void UpdateState(float deltaTime)
		{
			if (null == m_currentState) {
				return;
			}
			if (m_isLoadingScene) {
				return;
			}
			m_currentState.Update (deltaTime);
		}

		public void FixedUpdateState()
		{
			if (null == m_currentState) {
				return;
			}
			m_currentState.FixedUpdate ();
		}

		public void ChangeState(GameState pChangeState, string pSceneName = "")
		{
			if (m_currentState != null) {
				m_currentState.Destory ();
			}
			m_currentState = pChangeState;
			pChangeState.Init (this);
			if (pSceneName != string.Empty) {
				Timing.RunCoroutine (LoadScene (pSceneName));
			}
		}
		#endregion

		#region private function
		IEnumerator<float> LoadScene(string pSceneName)
		{
			m_isLoadingScene = true;
			AsyncOperation ao = SceneManager.LoadSceneAsync (pSceneName,LoadSceneMode.Single);
			ao.allowSceneActivation = false;
			while (!ao.isDone) {
				if (ao.progress >= 0.9f) {
					ao.allowSceneActivation = true;
					m_isLoadingScene = false;
				}
				yield return 0f;
			}
		}
		#endregion
	}
}
