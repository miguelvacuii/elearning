using System.Collections.Generic;

namespace elearning.src.Shared.Domain
{
	public class AuthUser
	{
		public const string ROLE_STUDENT = "student";
		public const string ROLE_TEACHER = "teacher";
		public const string ROLE_ADMINISTRATOR = "administrator";
		public static readonly List<string> ROLES = new List<string> {
			ROLE_STUDENT,
			ROLE_TEACHER,
			ROLE_ADMINISTRATOR
		};

		public string id { get; private set; }
		public string email { get; private set; }
		public string firstName { get; private set; }
		public string lastName { get; private set; }
		public string role { get; private set; }

		public AuthUser(
			string id,
			string email,
			string firstName,
			string lastName,
			string role
		)
		{
			this.id = id;
			this.email = email;
			this.firstName = firstName;
			this.lastName = lastName;
			this.role = role;
		}

		public bool IsStudent()
		{
			return role == ROLE_STUDENT;
		}

		public bool IsTeacher()
		{

			return role == ROLE_TEACHER;
		}

		public bool IsAdministrator()
		{
			return role == ROLE_ADMINISTRATOR;
		}

		public static bool Contains(string role)
		{
			return ROLES.Contains(role);
		}
	}
}
