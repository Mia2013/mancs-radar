using NetTopologySuite.Geometries;

namespace mancs_radar_server.Services
{
    public static class GeoHelper
    {
        public static Point CreatePoint(double latitude, double longitude)
        {
            return new Point(longitude, latitude) { SRID = 4326 };
        }
    }
}
