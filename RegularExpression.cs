using System;
using System.Linq;
using System.Text.RegularExpressions;

// This Code is need a mono.

namespace RegularExpression
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var RegExp = new RegExpClass();

			RegExp.IsMatch1();

			RegExp.StartString();

			RegExp.CountMatch();

			RegExp.PerfectMatch();

			RegExp.KanaMatch();

			RegExp.SearchAndLinq();

			RegExp.ReplaceString();

			RegExp.ReplaceGroup();

			RegExp.EnglishFive();
		}
	}

	class RegExpClass
	{
		// 文字列の判定
		public void IsMatch1()
		{
			var text = "abc defg hijk lnm";
			// 空白を含めている
			bool isMatch = Regex.IsMatch(text, @"bc d");
			if (isMatch)
				Console.WriteLine("条件に合致したものが存在しています");
			else
				Console.WriteLine("条件に合致したものが存在していません");
			Console.WriteLine();
		}

		// 開始文字列の判定
		public void StartString()
		{
			var text = "using System.Text.RegularExpressions;";
			bool isMatch = Regex.IsMatch(text, @"^using");
			if (isMatch)
				Console.WriteLine("usingで開始している");
			else
				Console.WriteLine("usingで開始していない");
			Console.WriteLine();
		}

		// 合致条件のカウント
		public void CountMatch()
		{
			var strings = new[] {"Microsoft Windows", "Windows Server", "windows"};
			var regex = new Regex(@"^(W|w)indows$");
			var count = strings.Count(s => regex.IsMatch(s));
			Console.WriteLine("一致数 {0}", count);
			Console.WriteLine();
		}

		// 完全一致の抽出
		public void PerfectMatch()
		{
			var strings = new[] {"13000", "-50.6", "0.123", "+180.00", 
								"10.2.5", "320-0851", "123", "$1200", "500円", };
			var regex = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
			foreach (var s in strings)
			{
				var isMatch = regex.IsMatch(s);
				if (isMatch)
					Console.WriteLine(s);
			}
			Console.WriteLine();
		}

		// カタカナのMatch
		public void KanaMatch()
		{
			var text = "あいうえお　カキクケコ　さしすせそ";
			Match match = Regex.Match(text, @"\p{IsKatakana}+");
			// Indexと値の取得
			if (match.Success)
				Console.WriteLine("{0} {1}", match.Index, match.Value);
			Console.WriteLine();
		}

		// LINQの適用
		public void SearchAndLinq()
		{
			var text = "private List<string> results = new List<string>();";
			var matches = Regex.Matches(text, @"\b[a-z]+\b")
								.Cast<Match>().OrderBy(x => x.Length);
			foreach (Match match in matches)
			{
				Console.WriteLine("Index={0}, Length={1}, Value={2}", 
					              match.Index, match.Length, match.Value);
			}
			Console.WriteLine();
		}

		// 置換処理
		public void ReplaceString()
		{
			var text = "これは御御御付けです";
			var pattern = @"御御御付け|おみおつけ|御御お付け|お味噌汁";
			var replaced = Regex.Replace(text, pattern, "お味噌汁");
			Console.WriteLine(replaced);
			Console.WriteLine();
		}

		// 対象を絞った置換
		public void ReplaceGroup()
		{
			var text = "1024バイト、8バイト文字、バイト、キロバイト";
			var pattern = @"(\d+)バイト";
			var replaced = Regex.Replace(text, pattern, "$1byte");
			Console.WriteLine(replaced);
			Console.WriteLine();
		}

		// 英語で始まり、その後数字が5文字以上続く文字列
		public void EnglishFive()
		{
			var text = "a12345 b123 Z12345 AX98765";
			var pattern = @"\b[a-zA-Z][0-9]{5,}\b";
			var matches = Regex.Matches(text, pattern);
			foreach (Match m in matches)
				Console.WriteLine("'{0}'", m.Value);
			Console.WriteLine();
		}
	}
}

