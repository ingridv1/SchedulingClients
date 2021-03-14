using BaseClients.Architecture;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.Collections.Generic;

namespace SchedulingClients.Core
{
    /// <summary>
    /// For obtaining map data and applying occupying mandates. 
    /// </summary>
    public interface IMapClient : ICallbackClient
    {
        /// <summary>
        /// Gets all moves in the roadmap.
        /// </summary>
        /// <returns>Array of move dtos.</returns>
        IServiceCallResult<MoveDto[]> GetAllMoves();

        /// <summary>
        /// Gets all nodes in the roadmap.
        /// </summary>
        /// <returns>Array of node dtos.</returns>
        IServiceCallResult<NodeDto[]> GetAllNodes();

        /// <summary>
        /// Gets all Kingpin parameters in the roadmap.
        /// </summary>
        /// <returns>An array of parameter dtos.</returns>
        IServiceCallResult<ParameterDto[]> GetAllParameters();

        /// <summary>
        /// Gets an individual moevs trajectory. 
        /// </summary>
        /// <param name="moveId">Target move Id.</param>
        /// <returns>Waypoint dto for given move.</returns>
        IServiceCallResult<WaypointDto[]> GetTrajectory(int moveId);

        /// <summary>
        /// Gets the state of the current occupying mandate.
        /// </summary>
        /// <returns>Occupying mandate progress dto of current mandate.</returns>
        IServiceCallResult<OccupyingMandateProgressDto> GetOccupyingMandateProgress();

        /// <summary>
        /// Sets a new occupying mandate.
        /// </summary>
        /// <param name="mapItemIds">Hash set of map items to occupy.</param>
        /// <param name="timeout">Allotted time to successfully apply the mandate.</param>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult SetOccupyingMandate(HashSet<int> mapItemIds, TimeSpan timeout);

        /// <summary>
        /// Clears any occupying mandate.
        /// </summary>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult ClearOccupyingMandate();

        /// <summary>
        /// Current progress of the current occupying mandate.
        /// </summary>
        OccupyingMandateProgressDto OccupyingMandateProgress { get; }

        /// <summary>
        /// Fired whenever occupying mandate progress is updated.
        /// </summary>
        event Action<OccupyingMandateProgressDto> OccupyingMandateProgressUpdated;
    }
}