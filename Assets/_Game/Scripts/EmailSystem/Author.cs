using UnityEngine;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class Author {

		private Sprite portait = null;

		private string name = "";

		public Sprite Portrait {
			get { return portait; }
			set { portait = value; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}
	}
}