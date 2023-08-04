using System.Collections.Generic;
using elearning.src.IAM.User.Application.Query.FindByCriteria;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Query.Criteria;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Query.FindUsersByCriteria
{
    [TestFixture]
    public class FindUsersByCriteriaQueryHandlerTest {

        [Test]
        public void ItShouldInvokeUseCase()
        {
            QueryCollection queryCollection = CreateQueryCollection();
            Mock <FindUsersByCriteriaQuery> query = new Mock<FindUsersByCriteriaQuery>(queryCollection);
            Mock<FindUsersByCriteriaUseCase> findUserByCriteriaUseCase = CreateAndSetupFindUsersByCriteriaUseCaseMock();

            FindUsersByCriteriaQueryHandler findUsersByCriteriaQueryHandler = new FindUsersByCriteriaQueryHandler(
                findUserByCriteriaUseCase.Object
            );

            findUsersByCriteriaQueryHandler.Handle(query.Object);

            findUserByCriteriaUseCase.Verify(
                m => m.Invoke(
                    It.IsAny<List<Criterion>>(),
                    It.IsAny<List<Order>>(),
                    It.IsAny<Limit>(),
                    It.IsAny<Offset>()
                ),
                Times.AtLeastOnce()
            );
        }

        private QueryCollection CreateQueryCollection() {
            Dictionary<string, StringValues> paramsDictionary = new Dictionary<string, StringValues>();
            paramsDictionary.Add("page[number]", "1");
            paramsDictionary.Add("page[size]", "1");
            paramsDictionary.Add("filter[id]", "049ce320-6a0d-46ed-94fa-cd5d1ac465c7");
            return new QueryCollection(paramsDictionary);
        }

        private Mock<FindUsersByCriteriaUseCase> CreateAndSetupFindUsersByCriteriaUseCaseMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<UserListResponseConverter> userListResponseConverter = new Mock<UserListResponseConverter>();
            Mock<FindUsersByCriteriaUseCase> findUserByCriteriaUseCase = new Mock<FindUsersByCriteriaUseCase>(
                userRepository.Object, userListResponseConverter.Object
            );
            findUserByCriteriaUseCase.Setup(m => m.Invoke(
                It.IsAny<List<Criterion>>(),
                It.IsAny<List<Order>>(),
                It.IsAny<Limit>(),
                It.IsAny<Offset>()
            )).Verifiable();

            return findUserByCriteriaUseCase;
        }
    }
}
