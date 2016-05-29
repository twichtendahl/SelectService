<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Service - Show Tracker</title>
</head>
<body>
    <h1>Seattle Show Tracker</h1>

    <form id="show_artist_venue" runat="server">
        <div>
            <!--List of Venues-->
            <div id="venue_area" class="row">
                <h2>Venues</h2>
                <asp:DropDownList ID="VenueList" runat="server" CssClass="inline"></asp:DropDownList>
                <asp:Button ID="ShowsByVenueButton" runat="server" Text="Find Shows at Selected Venue" OnClick="ShowsByVenueButton_Click" CssClass="inline" />
            </div>

            <!--List of Artists-->
            <div id="artist_area" class="row">
                <h2>Artists</h2>
                <asp:DropDownList ID="ArtistList" runat="server" CssClass="inline"></asp:DropDownList>
                <asp:Button ID="ShowsByArtistButton" runat="server" Text="Find Shows of Selected Artist" OnClick="ShowsByArtistButton_Click" CssClass="inline" />
            </div>

            <!--List of Shows-->
            <div id="show_area" class="row">
                <h2>Shows</h2>
                <asp:DropDownList ID="ShowList" runat="server" CssClass="inline"></asp:DropDownList>
            </div>

            <!--Shows by Venue or by Artist-->
            <div id="shows_by_venue">                
                <asp:DataList ID="ShowsByVenue" runat="server">
                    <ItemTemplate>
                        <h3><%#Eval("ShowName") %></h3>
                        <p><%#Eval("ShowDate") %></p>
                        <p><%#Eval("ShowStartTime") %></p>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="shows_by_artist">                
                <asp:DataList ID="ShowsByArtist" runat="server">
                    <ItemTemplate>
                        <h3><%#Eval("ShowName") %></h3>
                        <p><%#Eval("ShowDate") %></p>
                        <p><%#Eval("ShowStartTime") %></p>
                        <p><%#Eval("VenueName") %></p>
                    </ItemTemplate>
                </asp:DataList>
            </div>    
        </div>
    </form>
</body>
</html>
