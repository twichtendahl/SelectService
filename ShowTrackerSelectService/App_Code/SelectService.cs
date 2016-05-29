using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SelectService" in code, svc and config file together.
public class SelectService : ISelectService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<string> GetArtists()
    {
        List<string> artists = new List<string>();
        var aNames = from a in ste.Artists select new { a.ArtistName };
        foreach(var v in aNames)
        {
            artists.Add(v.ArtistName.ToString());
        }
        return artists;
    }

    public List<string> GetShows()
    {
        List<string> shows = new List<string>();
        var sNames = from s in ste.Shows select new { s.ShowName };
        foreach (var v in sNames)
        {
            shows.Add(v.ShowName.ToString());
        }
        return shows;
    }

    public List<ShowDetailInfo> GetShowsByArtist(string artistName)
    {
        List<ShowDetailInfo> showDetailInfos = new List<ShowDetailInfo>();

        var sd_table = from s in ste.Shows
                       join sd in ste.ShowDetails on s.ShowKey equals sd.ShowKey
                       join a in ste.Artists on sd.ArtistKey equals a.ArtistKey
                       where a.ArtistName.Equals(artistName)
                       select new
                       {
                           s.ShowName,
                           s.ShowDate,
                           s.ShowTime,
                           s.Venue.VenueName
                       };

        foreach(var row in sd_table)
        {
            ShowDetailInfo sdi = new ShowDetailInfo();
            sdi.ShowName = row.ShowName;
            sdi.ShowDate = row.ShowDate;
            sdi.ShowStartTime = row.ShowTime;
            sdi.VenueName = row.VenueName;
            showDetailInfos.Add(sdi);
        }

        return showDetailInfos;
    }

    public List<ShowInfo> GetShowsByVenue(string venueName)
    {
        List<ShowInfo> showInfos = new List<ShowInfo>();

        var s_table = from s in ste.Shows
                      join v in ste.Venues on s.VenueKey equals v.VenueKey
                      where v.VenueName.Equals(venueName)
                      select new
                       {
                           s.ShowName,
                           s.ShowDate,
                           s.ShowTime
                       };

        foreach (var row in s_table)
        {
            ShowInfo si = new ShowInfo();
            si.ShowName = row.ShowName;
            si.ShowDate = row.ShowDate;
            si.ShowStartTime = row.ShowTime;
            showInfos.Add(si);
        }

        return showInfos;
    }

    public List<string> GetVenues()
    {
        List<string> venues = new List<string>();
        var vNames = from v in ste.Venues select new { v.VenueName };
        foreach (var i in vNames)
        {
            venues.Add(i.VenueName.ToString());
        }
        return venues;
    }
}
