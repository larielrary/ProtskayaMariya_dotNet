using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }
        public void DoAction(string name)
        {
            _logger.LogDebug(name);
        }
    }
}
