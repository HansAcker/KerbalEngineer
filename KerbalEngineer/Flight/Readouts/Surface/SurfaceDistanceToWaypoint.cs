﻿﻿//
//     Kerbal Engineer Redux
//
//     Copyright (C) 2017 fat-lobyte
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

#region Using Directives

using KerbalEngineer.Extensions;
using KerbalEngineer.Flight.Readouts.Surface;

#endregion

namespace KerbalEngineer.Flight.Readouts.Rendezvous
{
    public class SurfaceDistanceToWaypoint : ReadoutModule
    {
        #region Constructors

        public SurfaceDistanceToWaypoint()
        {
            this.Name = "Distance to Waypoint (Surface)";
            this.Category = ReadoutCategory.GetCategory("Surface");
            this.HelpString = "Great-circle distance from the current vessel to the waypoint on the surface";
            this.IsDefault = false;
        }

        #endregion

        #region Methods: public

        public override void Draw(Unity.Flight.ISectionModule section)
        {
            if (SurfaceDistanceProcessor.ShowWaypointDetails)
            {
                this.DrawLine(SurfaceDistanceProcessor.SurfaceDistanceToWaypoint.ToDistance(section.IsHud ? HudDecimalPlaces : DecimalPlaces), section);
            }
        }

        public override void Reset()
        {
            FlightEngineerCore.Instance.AddUpdatable(SurfaceDistanceProcessor.Instance);
        }

        public override void Update()
        {
            SurfaceDistanceProcessor.RequestUpdate();
        }

        #endregion
    }
}