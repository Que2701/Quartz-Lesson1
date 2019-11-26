using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzLesson1App
{
    public class HelloJob : IHelloJob , IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return (Task)Convert.ChangeType("hello from HelloJob", typeof(Task));
        }

        public void GetMessage()
        {
            Console.WriteLine("hello HelloJob class");
        }
    }
}
