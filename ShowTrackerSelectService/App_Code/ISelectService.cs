using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISelectService" in both code and config file together.
[ServiceContract]
public interface ISelectService
{
    [OperationContract]
    List<string> GetVenues();

    [OperationContract]
    List<string> GetArtists();

    [OperationContract]
    List<string> GetShows();

    [OperationContract]
    List<ShowInfo> GetShowsByVenue(string venueName);

    [OperationContract]
    List<ShowDetailInfo> GetShowsByArtist(string artistName);
}

[DataContract]
public class ShowInfo
{
    [DataMember]
    public string ShowName { get; set; }

    [DataMember]
    public DateTime ShowDate { get; set; }

    [DataMember]
    public TimeSpan ShowStartTime { get; set; }
}

[DataContract]
public class ShowDetailInfo
{
    [DataMember]
    public string ShowName { get; set; }

    [DataMember]
    public DateTime ShowDate { get; set; }

    [DataMember]
    public TimeSpan ShowStartTime { get; set; }

    [DataMember]
    public string VenueName { get; set; }
}
