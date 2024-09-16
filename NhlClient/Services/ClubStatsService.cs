// This file was generated by liblab | https://liblab.com/

using System.Net.Http.Json;
using NhlClient.Http;
using NhlClient.Http.Exceptions;
using NhlClient.Http.Extensions;
using NhlClient.Http.Serialization;

namespace NhlClient.Services;

public class ClubStatsService : BaseService
{
    internal ClubStatsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>Retrieve current statistics for a specific club.</summary>
    /// <param name="team">Three-letter team code</param>
    public async Task<object> GetCurrentClubStatsAsync(
        string team,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(team, nameof(team));

        var request = new RequestBuilder(HttpMethod.Get, "v1/club-stats/{team}/now")
            .SetPathParameter("team", team)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<object>(_jsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Returns an overview of the stats for each season for a specific club.</summary>
    /// <param name="team">Three-letter team code</param>
    public async Task<object> GetTeamClubStatsSeasonAsync(
        string team,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(team, nameof(team));

        var request = new RequestBuilder(HttpMethod.Get, "v1/club-stats-season/{team}")
            .SetPathParameter("team", team)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<object>(_jsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Retrieve the stats for a specific team, season, and game type.</summary>
    /// <param name="team">Three-letter team code</param>
    /// <param name="season">Season in YYYYYYYY format</param>
    /// <param name="gameType">Game type (2 for regular season, 3 for playoffs)</param>
    public async Task<object> GetClubStatsBySeasonAsync(
        string team,
        long season,
        long gameType,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(team, nameof(team));

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/club-stats/{team}/{season}/{game-type}"
        )
            .SetPathParameter("team", team)
            .SetPathParameter("season", season)
            .SetPathParameter("game-type", gameType)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<object>(_jsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
