using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Exortech.NetReflector;
using tw.ccnet.core.util;

namespace tw.ccnet.core.sourcecontrol.test
{
	[TestFixture]
	public class VssTest
	{
		public const string VSS_XML =
			@"<sourceControl type=""vss"">
    <executable>..\tools\vss\ss.exe</executable>
    <ssdir>..\tools\vss</ssdir>
    <project>$/fooProject</project>
    <username>Admin</username>
    <password>admin</password>
</sourceControl>";	

		private Vss _vss;
		
		[SetUp]
		protected void SetUp()
		{
			_vss = CreateVss();
		}
		
		public void TestCreateHistoryProcess()
		{	
			DateTime from = new DateTime(2001, 1, 21, 20, 0, 0);
			DateTime to = new DateTime(2002, 2, 22, 20, 0, 0);

			Process actual = _vss.CreateHistoryProcess(from, to);

			string expectedExecutable = @"..\tools\vss\ss.exe";
			string expectedArgs = @"history $/fooProject -R -Vd02-22-2002;8:00P~01-21-2001;8:00P -YAdmin,admin -I-Y";				

			Assertion.AssertNotNull("process was null", actual);
			Assertion.AssertEquals(expectedExecutable, actual.StartInfo.FileName);
			Assertion.AssertEquals(expectedArgs, actual.StartInfo.Arguments);
		}
		
		public void TestValuesSet()
		{
			Assertion.AssertEquals(@"..\tools\vss\ss.exe", _vss.Executable);
			Assertion.AssertEquals(@"admin", _vss.Password);
			Assertion.AssertEquals(@"$/fooProject", _vss.Project);
			Assertion.AssertEquals(@"..\tools\vss", _vss.SsDir);
			Assertion.AssertEquals(@"Admin", _vss.Username);
		}

		public void TestFormatDate()
		{
			DateTime date = new DateTime(2002, 2, 22, 20, 0, 0);
			string expected = "02-22-2002;8:00P";
			string actual = _vss.FormatCommandDate(date);
			Assertion.AssertEquals(expected, actual);

			date = new DateTime(2002, 2, 22, 12, 0, 0);
			expected = "02-22-2002;12:00P";
			actual = _vss.FormatCommandDate(date);
			Assertion.AssertEquals(expected, actual);
		}

		[Test]
		public void EnvironmentVariables() 
		{
			Process p = ProcessUtil.CreateProcess("cmd.exe", "/C set foo");
			p.StartInfo.EnvironmentVariables["foo"] = "bar";
		TextReader reader = ProcessUtil.ExecuteRedirected(p);
			string result = reader.ReadToEnd();
			p.WaitForExit();
			Console.WriteLine(result);
			Assertion.AssertEquals("foo=bar\r\n", result);
		}

		public void TestExecutable_default()
		{
			Assertion.AssertEquals("ss.exe", new Vss().Executable);
		}

		private Vss CreateVss()
		{
			XmlPopulator populator = new XmlPopulator();
			Vss vss = new Vss();
			populator.Populate(XmlUtil.CreateDocumentElement(VSS_XML), vss);
			return vss;
		}
	}
}
