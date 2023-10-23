using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectRecommendedArtworkDataCommand: IRequest<IEnumerable<ArtistArtworkRecommendation>>
    {

    }
}
