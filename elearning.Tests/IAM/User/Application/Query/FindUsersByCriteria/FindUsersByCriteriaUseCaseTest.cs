using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Application.Query.FindByCriteria;
using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.Tests.IAM.User.Application.Query.FindUsersByCriteria
{
    [TestFixture]
    public class FindUsersByCriteriaUseCaseTest{
        Criterion criterion;
        List<Criterion> listCriterion;
        Order order;
        List<Order> listOrder;
        Limit limit;
        Offset offset;

        [SetUp]
        public void Setup()
        {
            criterion = Criterion.Create("id", "049ce320-6a0d-46ed-94fa-cd5d1ac465c7");
            listCriterion = new List<Criterion>();
            listCriterion.Add(criterion);

            order = Order.Create("id", "ASC");
            listOrder = new List<Order>();
            listOrder.Add(order);

            limit = new Limit(1);
            offset = new Offset(1);

        }

        [Test]
        public void ItShouldFindUsers()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UserListResponseConverter> userListResponseConverter = CreateAndSetupUserResponseForTokenConverter();
            FindUsersByCriteriaUseCase findUsersByCriteriaUseCase = new FindUsersByCriteriaUseCase(
                userRepository.Object, userListResponseConverter.Object
            );

            findUsersByCriteriaUseCase.Invoke(
               listCriterion, listOrder, limit, offset
            );

            userRepository.Verify(
                m => m.Find(It.IsAny<Criteria>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldFindUsersAndConvertThem()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UserListResponseConverter> userListResponseConverter = CreateAndSetupUserResponseForTokenConverter();
            FindUsersByCriteriaUseCase findUsersByCriteriaUseCase = new FindUsersByCriteriaUseCase(
                userRepository.Object, userListResponseConverter.Object
            );

            findUsersByCriteriaUseCase.Invoke(
               listCriterion, listOrder, limit, offset
            );

            userListResponseConverter.Verify(
                m => m.Convert(It.IsAny<List<UserAggregate>>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.Find(It.IsAny<Criteria>())).Verifiable();
            return userRepository;
        }

        private Mock<UserListResponseConverter> CreateAndSetupUserResponseForTokenConverter()
        {
            Mock<UserResponseConverter> userResponseConverter = new Mock<UserResponseConverter>();
            Mock<UserListResponseConverter> userListResponseConverter = new Mock<UserListResponseConverter>(userResponseConverter.Object);
            userListResponseConverter.Setup(m => m.Convert(It.IsAny<List<UserAggregate>>())).Verifiable();
            return userListResponseConverter;
        }
    }
}
