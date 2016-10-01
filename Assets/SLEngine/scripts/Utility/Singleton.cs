namespace SLEngine
{
	class Singleton<T> where T:class,new() {
		static private T m_instance;

		public Singleton(){}

		static public T Instance
		{
			get{
				if (null == m_instance) {
					m_instance = new T ();
				}
				return m_instance;
			}
		}
	}
}