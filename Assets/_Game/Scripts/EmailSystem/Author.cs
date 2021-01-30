using UnityEngine;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class Author {

		public Author(Sprite portrait, string name, string address) {
			this.portrait = portrait;
			this.name = name;
			this.address = address;
		}

		private Sprite portrait = null;

		private string name = "";

		private string address = "";

		public Sprite Portrait {
			get { return portrait; }
			set { portrait = value; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Address {
			get { return address; }
			set { address = value; }
		}
	}
}