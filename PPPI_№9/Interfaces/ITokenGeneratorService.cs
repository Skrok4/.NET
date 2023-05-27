using Fitness_Tracking.Models;

namespace Fitness_Tracking.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(UserModel user);
    }
}
