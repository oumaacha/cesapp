using System.Text.RegularExpressions;

namespace cesapp.Services
{
	public interface IDateValidation
	{
		bool IsValidDateFormat(string input);
	}
	public class DateValidation : IDateValidation
	{
		public bool IsValidDateFormat(string input)
		{
			string pattern1 = @"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}$";
			string pattern2 = @"^\d{1}/\d{1}/\d{4} \d{2}:\d{2}:\d{2}$";
			string pattern3 = @"^\d{1}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}$";
			string pattern4 = @"^\d{2}/\d{1}/\d{4} \d{2}:\d{2}:\d{2}$";
			string pattern5 = @"^\d{2}/\d{2}/\d{4}$";
			string pattern6 = @"^\d{1}/\d{1}/\d{4}$";
			string pattern7 = @"^\d{1}/\d{2}/\d{4}$";
			string pattern8 = @"^\d{2}/\d{1}/\d{4}$";
			return
				Regex.IsMatch(input, pattern1) ||
				Regex.IsMatch(input, pattern2) ||
				Regex.IsMatch(input, pattern3) ||
				Regex.IsMatch(input, pattern4) ||
				Regex.IsMatch(input, pattern5) ||
				Regex.IsMatch(input, pattern6) ||
				Regex.IsMatch(input, pattern7) || 
				Regex.IsMatch(input, pattern8);

		}
	}
}
