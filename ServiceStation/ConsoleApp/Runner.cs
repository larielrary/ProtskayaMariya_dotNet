using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class Runner
    {
        private readonly ILogger<Runner> logger;

        public Runner(ILogger<Runner> logger)
        {
            this.logger = logger;
        }
        public void DoAction(string name)
        {
            logger.LogDebug(name);
        }
    }
}
