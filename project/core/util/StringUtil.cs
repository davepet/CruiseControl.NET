using System;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace tw.ccnet.core.util
{
	public class StringUtil
	{
		public static bool StringContains(string text, string fragment)
		{
			return text.IndexOf(fragment) > -1;
		}

		public static bool EqualsIngnoreCase(string a, string b)
		{
			return CaseInsensitiveComparer.Default.Compare(a, b) == 0;
		}

		public static string JoinUnique(string delimiter, params string[][] fragmentArrays)
		{
			SortedList list = new SortedList();
			foreach (string[] fragmentArray in fragmentArrays)
			{
				foreach (string fragment in fragmentArray)
				{
					if (! list.Contains(fragment))
						list.Add(fragment, fragment);
				}
			}
			StringBuilder buffer = new StringBuilder();
			foreach (string value in list.Values)
			{
				if (buffer.Length > 0)
				{
					buffer.Append(delimiter);
				}
				buffer.Append(value);
			}
			return buffer.ToString();
		}

		public static int GenerateHashCode(params string[] values)
		{
			int hashcode = 0;
			foreach (string value in values)
			{
				if (value != null)
				{
					hashcode += value.GetHashCode();
				}
			}
			return hashcode;
		}

		public static string LastWord(string input)
		{
			return LastWord(input, " .,;!?:");
		}

		public static string LastWord(string input, string separators)
		{
			if (input == null)
			{
				return null;
			}
			string[] tokens = input.Split(separators.ToCharArray());
			for(int i=tokens.Length - 1; i >= 0; i--)
			{
				if (IsWhitespace(tokens[i]) == false)
				{
					return tokens[i].Trim();
				}
			}
			return String.Empty;
		}

		public static bool IsBlank(string input)
		{
			return (input == null || input.Length == 0);
		}

		public static bool IsWhitespace(string input)
		{
			return (input == null || input.Trim().Length == 0);
		}

		public static string Strip(string input, params string[] removals)
		{
			string revised = input;			
			foreach(string removal in removals)
			{			
				int i = 0;
				while ((i = revised.IndexOf(removal)) > -1)
				{
					revised = revised.Remove(i, removal.Length);
				}				
			}			
			return revised;
		}

		public static string[] Insert(string[] input, string insert, int index)
		{
			ArrayList list = new ArrayList(input);
			list.Insert(index, insert);
			return (string[])list.ToArray(typeof(string));
		}
	}
}
