using System;
using tw.ccnet.remote;

namespace tw.ccnet.core.test
{
	public class IntegrationResultMother
	{
		public static IntegrationResult Create(bool succeeded)
		{
			return Create(succeeded, DateTime.Now);
		}

		public static IntegrationResult Create(bool succeeded, DateTime date)
		{
			IntegrationResult result = new IntegrationResult();
			result.Status = (succeeded) ? IntegrationStatus.Success : IntegrationStatus.Failure;
			result.StartTime = date;
			result.EndTime = date;
			return result;
		}

		public static IntegrationResult CreateSuccessful()
		{
			return Create(true, DateTime.Now);
		}

		public static IntegrationResult CreateSuccessful(DateTime startDate)
		{
			return Create(true, startDate);
		}

		public static IntegrationResult CreateFailed()
		{
			return Create(false, DateTime.Now);
		}
	}
}
