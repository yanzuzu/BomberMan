using UnityEngine;
using System.Collections;

namespace SLEngine.GameState
{
	public class GameState {
		public GameStateManager StateManager;

		public virtual void Init (GameStateManager pStateMgr){
			StateManager = pStateMgr;
		}
		public virtual void Update (float deltaTime){}
		public virtual void FixedUpdate(){}
		public virtual void Destory(){}
	}
}
