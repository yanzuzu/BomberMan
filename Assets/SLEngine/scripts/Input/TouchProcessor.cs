using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLEngine.Debug;

namespace SLEngine.Inputs
{
	public class TouchProcessor {
		List<ITouchListener> m_touches = new List<ITouchListener>();

		#region PUBLIC METHOD
		public void Register(ITouchListener listener )
		{
			if (m_touches.Contains (listener)) {
				SLDebug.LogWarning (string.Format("this listener = {0} is repeat" , listener));
				return;
			}
			m_touches.Add (listener);
		}
			
		public void UpdateInput()
		{
			if (Input.touchCount == 0) {
				return;
			}

			for (int i = 0; i < Input.touchCount; i++) {
				Touch touchData = Input.GetTouch(i);
				if (touchData.phase == TouchPhase.Began) {
					for (int k = 0; k < m_touches.Count; i++) {
						m_touches [i].TouchBegin (touchData);
					}
				}

				if (touchData.phase == TouchPhase.Moved) {
					for (int k = 0; k < m_touches.Count; i++) {
						m_touches [i].TouchMove (touchData);
					}
				}

				if (touchData.phase == TouchPhase.Ended || touchData.phase == TouchPhase.Canceled) {
					for (int k = 0; k < m_touches.Count; i++) {
						m_touches [i].TouchEnd (touchData);
					}
				}

			}
		}
		#endregion
			
	}
}
