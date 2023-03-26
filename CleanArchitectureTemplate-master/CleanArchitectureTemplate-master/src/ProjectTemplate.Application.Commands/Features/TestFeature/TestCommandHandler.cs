
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectTemplate.Domain.Models.Aggregates;
using ProjectTemplate.Persistence.Commands.Interfaces;

namespace ProjectTemplate.Application.Commands.Features.TestFeature
{
    public class TestCommandHandler : IRequestHandler<TestCommand, Test>
    {
        private readonly IMutatableRepository<ProjectAggregate> _projectAggregate;

        public TestCommandHandler(IMutatableRepository<ProjectAggregate> projectAggregate)
        {
            _projectAggregate = projectAggregate;
        }

        public async Task<Test> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            if(request.Number == 5)
            {
                throw new TestCommandException();
            }

            var test = new Test();

            return test;
        }
    }
}
