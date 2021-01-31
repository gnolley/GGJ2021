namespace ScoreSystem {

	/// <summary>
	///
	/// </summary>
	public static class RatingFunction {

		private enum Rating {
			D,
			C,
			B,
			A,
			S
		}

		public static string Evaluate(float kpi) {
			float kpiNorm = kpi / KPIManager.MAX_KPI; // normalise
			float ratingRange = kpiNorm * 4; // scale to the 5 ratings

			int rating = (int)ratingRange; // gets floor to a range

			string ratingString = "";

			// between 2 ratings
			float ratingDifference = ratingRange - rating;
			if (ratingDifference >= 0.9f) { // one rating up
				ratingString = $"{IntEnumString(rating + 1)}";

			} else if (ratingDifference < 0.9f && ratingDifference >= 0.5f) {
				ratingString = $"{IntEnumString(rating + 1)}-";

			} else if (ratingDifference < 0.5f && ratingDifference >= 0.1f) {
				ratingString = $"{IntEnumString(rating)}+";
			} else {
				ratingString = $"{IntEnumString(rating)}";
			}

			return ratingString;
		}

		private static string IntEnumString(int num) {
			Rating rating = (Rating)num;

			// Apparently converting int -> rating -> string gives you back the int
			switch (rating) {
				case Rating.D:
					return Rating.D.ToString();

				case Rating.C:
					return Rating.C.ToString();

				case Rating.B:
					return Rating.B.ToString();

				case Rating.A:
					return Rating.A.ToString();

				case Rating.S:
					return Rating.S.ToString();

				default:
					return $"{Rating.D.ToString()}-";
			}
		}

	}
}