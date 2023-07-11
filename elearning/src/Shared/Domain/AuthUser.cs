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

		public string id { get; }
		public string email { get; }
		public string firstName { get; }
		public string lastName { get; }
		public string role { get; }

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

		public static bool IsStudent(string role)
		{
			return role == ROLE_STUDENT;
		}

		public static bool IsTeacher(string role)
		{

			return role == ROLE_TEACHER;
		}

		public static bool IsAdministrator(string role)
		{
			return role == ROLE_ADMINISTRATOR;
		}

		public static bool Contains(string role)
		{
			return ROLES.Contains(role);
		}
	}
}
