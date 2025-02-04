using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAssignment.Commands
{
    class TestCommand : BaseCommand
    {
        private readonly Func<Task> testFunc;

        public TestCommand(Func<Task> testFunc)
        {
            this.testFunc = testFunc;
        }

        public override async void Execute(object? param)
        {
            if (testFunc != null)
            {
                await testFunc();
            }
        }
    }
}
