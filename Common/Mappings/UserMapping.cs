using Common.Models;
using DAL.Models;

namespace Common.Mappings
{
	public static class UserMapping
	{
		public static User ToUserEntity(this UserModel model)
		{
			return new User
			{
				Login = model.Login,
				FirstName = model.FirstName,
				LastName = model.LastName,
				IsAdmin = model.IsAdmin,
				UserName = model.Login,
				Email = model.Login
			};
		}

		public static UserModel ToUserModel(this User entity)
		{
			return new UserModel
			{
				Id = entity.Id,
				Login = entity.Login,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				IsAdmin = entity.IsAdmin
			};
		}

		public static User ToUserEntity(this RegisterModel model)
		{
			return new User
			{
				Login = model.Login,
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Login,
				Email = model.Login
			};
		}

		public static User ToUserEntity(this LoginModel model)
		{
			return new User
			{
				Login = model.Login,
				UserName = model.Login,
				Email = model.Login
			};
		}
	}
}
