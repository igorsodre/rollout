using System.Runtime.CompilerServices;
using Rollout.Lib.Interfaces;
using Rollout.Lib.Models;

[assembly: InternalsVisibleTo("Rollout.Lib.UnitTests")]

namespace Rollout.Lib.Implementations;

internal class FeatureManager : IFeatureManager
{
    private readonly IFeatureStorage _featureStorage;

    public FeatureManager(IFeatureStorage featureStorage)
    {
        _featureStorage = featureStorage;
    }

    public async Task SetPercentage(string featureName, decimal percentage)
    {
        if (string.IsNullOrEmpty(featureName))
        {
            return;
        }

        var feature = await _featureStorage.GetFeature(featureName) ?? new Feature(featureName);
        feature.Percentage = Math.Max(Math.Min(percentage, 100), 0);
        await _featureStorage.StoreFeature(feature);
    }

    public Task SetGroups(string featureName, IList<string> groups)
    {
        throw new NotImplementedException();
    }

    public Task RemoveGroups(string featureName, IList<string> groups)
    {
        throw new NotImplementedException();
    }

    public Task SetUsers(string featureName, IList<string> users)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUsers(string featureName, IList<string> users)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsActiveFor(string featureName, string? user = null, string? group = null)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetAllFeatures()
    {
        throw new NotImplementedException();
    }

    public Task Deactivate(string featureName)
    {
        throw new NotImplementedException();
    }
}
