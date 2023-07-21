using elearning.src.IAM.Token.Domain;

namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class TokenHashStub
    {
		public static TokenHash ByDefault()
		{
			return new TokenHash("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiMDQ5Y2UzMjAtNmEwZC00NmVkLTk0ZmEtY2Q1ZDFhYzQ2NWM3IiwiZW1haWwiOiJidXRvZXNrb3JAZ21haWwuY29tIiwiZmlyc3RfbmFtZSI6Ik1pZ3VlbCIsImxhc3RfbmFtZSI6Ik1hcnTDrW5leiIsInJvbGUiOiJhZG1pbmlzdHJhdG9yIiwibmJmIjoxNjg5ODcwODUzLCJleHAiOjE2OTA0NzU2NTMsImlhdCI6MTY4OTg3MDg1M30.MdFbAolePlNYs_UqmIR13L7cF0gh-uFIO-tOwK2QHoc");
		}

		public static TokenHash FromValue(string value)
		{
			return new TokenHash(value);
		}
	}
}
