using DUI.DataModel.Common;

namespace DUI.DataModel.Model {
    public interface IRealtorWorldUnitOfWork : IUnitOfWork {
        IHomeRepository Homes { get; }
        IHomePhotoRepository HomePhotos { get; }
        IAgentRepository Agents { get; }
        IHomeLayoutRepository HomeLayouts { get; }
        IMortgageRateRepository MortgageRates { get; }
        IHomePopularityRatingRepository HomePopularityRatings { get; }
        IHomePriceStatisticDataRepository HomePriceStatisticData { get; }
        ISimilarHousesStatisticDataRepository SimilarHousesStatisticData { get; }
        IAgentStatisticDataRepository AgentStatisticData { get; }
    }
}
