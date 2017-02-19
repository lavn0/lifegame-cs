using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		[DeploymentItem(@"Resource\blinkerOutResult.txt", @"Resource")]
		public void Blinkerの出力結果のテスト()
		{
			using (var ms = new MemoryStream())
			using (var sw = new StreamWriter(ms))
			{
				sw.AutoFlush = true;

				Console.SetOut(sw);
				MainClass.Main();
				var position = ms.Position;
				ms.Seek(0, SeekOrigin.Begin);

				using (var sr = new StreamReader(ms))
				{
					var actual = sr.ReadToEnd();
					var expected = File.ReadAllText(@"Resource\blinkerOutResult.txt");
					Assert.AreEqual(expected, actual);
				}
			}
		}
	}
}
