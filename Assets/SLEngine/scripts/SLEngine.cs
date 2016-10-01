using UnityEngine;
using System.Collections;
using SLEngine.GameState;
using SLEngine.Inputs;
using SLEngine.Debug;

namespace SLEngine
{
	public class SLEngine : MonoBehaviour {
		public string StartGameSceneName = string.Empty;

		private GameStateManager m_stateManager;

		void Awake () 
		{
			DontDestroyOnLoad (this);
			m_stateManager = new GameStateManager ();
		}

		void Start()
		{
			if (StartGameSceneName == string.Empty) {
				SLDebug.LogWarning (string.Format("no setting start scene name!"));
			} else {
				m_stateManager.ChangeState (new MainGameState (),StartGameSceneName);
			}
		}

		void Update () 
		{
			m_stateManager.UpdateState (Time.deltaTime);
			Singleton<TouchProcessor>.Instance.UpdateInput ();
		}

		void FixedUpdate()
		{
			m_stateManager.FixedUpdateState ();
		}
	}
}
