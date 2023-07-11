using elearning.src.Shared.Domain;

namespace elearning.src.Shared.Infrastructure.Service.Hashing {
	public interface IHashing {
		HashedPassword Hash(string password);
	}
}
