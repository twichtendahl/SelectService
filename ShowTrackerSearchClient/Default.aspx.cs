using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SelectServiceReference.SelectServiceClient sc = new SelectServiceReference.SelectServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PopulateVenueList();
            PopulateArtistList();
            PopulateShowList();
        }        
    }
    
    protected void PopulateVenueList()
    {
        string[] venues = sc.GetVenues();
        VenueList.DataSource = venues;
        VenueList.DataBind();
    }

    protected void PopulateArtistList()
    {
        string[] artists = sc.GetArtists();
        ArtistList.DataSource = artists;
        ArtistList.DataBind();
    }

    protected void PopulateShowList()
    {
        string[] shows = sc.GetShows();
        ShowList.DataSource = shows;
        ShowList.DataBind();
    }

    protected void ShowsByVenueButton_Click(object sender, EventArgs e)
    {
        string venue = VenueList.SelectedItem.ToString();
        SelectServiceReference.ShowInfo[] shows = sc.GetShowsByVenue(venue);

        // Clear Show by Artist data, if any
        ShowsByArtist.DataSource = null;
        ShowsByArtist.DataBind();

        // Populate data list with Show by Venue data
        ShowsByVenue.DataSource = shows;
        ShowsByVenue.DataBind();
    }

    protected void ShowsByArtistButton_Click(object sender, EventArgs e)
    {
        string artist = ArtistList.SelectedItem.ToString();
        SelectServiceReference.ShowDetailInfo[] shows = sc.GetShowsByArtist(artist);

        // Clear Show by Venue data, if any
        ShowsByVenue.DataSource = null;
        ShowsByVenue.DataBind();

        // Populate data list with Shows by Artist
        ShowsByArtist.DataSource = shows;
        ShowsByArtist.DataBind();
    }
}