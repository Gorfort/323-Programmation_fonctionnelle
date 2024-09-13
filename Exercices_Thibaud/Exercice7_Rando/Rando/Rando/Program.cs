using Gpx;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Rando
{
    internal class Program
    {
        class Trackpoint
        {
            private double _latitude;
            private double _longitude;
            private double _elevation;
        }

        static void Main(string[] args)
        {
            using (var stream = new FileStream(@"C:\Users\po44oov\Documents\GitHub\323-Programmation_fonctionnelle\Exercices_Thibaud\Exercice7_Rando\loechegemmi.gpx", FileMode.Open))
            using (var output = new FileStream(@"C:\Users\po44oov\Documents\GitHub\323-Programmation_fonctionnelle\Exercices_Thibaud\Exercice7_Rando\fichier.gpx", FileMode.Open))
            {

                using (GpxReader reader = new GpxReader(stream))
                {
                    using (GpxWriter writer = new GpxWriter(output))
                    {

                        while (reader.Read())
                        {
                            switch (reader.ObjectType)
                            {
                                case GpxObjectType.Metadata:
                                    //writer.WriteMetadata(reader.Metadata);
                                    break;
                                case GpxObjectType.WayPoint:
                                    //writer.WriteWayPoint(reader.WayPoint);
                                    break;
                                case GpxObjectType.Route:
                                    //writer.WriteRoute(reader.Route);
                                    break;
                                case GpxObjectType.Track:
                                    //writer.WriteTrack(reader.Track);
                                    //reader.Track.Segments.First()

                                    //TODO convertir les points en trackpoints avec un SELECT+TrackPoint... reader.Track.ToGpxPoints()
                                    break;
                            }
                        }

                        //fini la lecture (elements convertis)

                        var tr = new List<Trackpoint>();

                        var gpsTrack = new GpxTrack();
                        var segment = new GpxTrackSegment();

                        tr.ToList().ForEach(tr => {
                            segment.TrackPoints.AddPoint(
                            new GpxTrackPoint() { Latitude = 32, Longitude = 44, Elevation = 14 }
                            );
                        });

                        gpsTrack.Segments.Add(segment);
                        writer.WriteTrack(gpsTrack);

                    }
                }
                Console.Read();
            }
        }
    }
}
