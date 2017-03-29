<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manageusers.aspx.cs" Inherits="Web.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<main>
	<div id="mainContent">
		<div id="manageUsersSection">
			<h3>Hantera kunder</h3>
					
			<div id="userListBox">
				<div class="userListItems" id="userListHeaders">
					<div class="userFirstname">
						<p>Förnamn</p>
					</div>
					<div class="userLastname">
						<p>Efternamn</p>
					</div>
					<div class="userEmail">
						<p>E-post</p>
					</div>
					<div class="userPhone">
						<p>Telefon</p>
					</div>
					<div class="userPlacedOrders">
						<p>Ordrar</p>
					</div>
					<div class="userRemove">
						<p>Ta bort</p>
					</div>
				</div>
				<div class="userListItems">
					<div class="userFirstname">
						<p>Bosse</p>
					</div>
					<div class="userLastname">
						<p>Karlsson</p>
					</div>
					<div class="userEmail">
						<p>bo@karlsson.se</p>
					</div>
					<div class="userPhone">
						<p>026-228297</p>
					</div>
					<div class="userPlacedOrders">
						<p>0</p>
					</div>
					<div class="userRemove">
						<span class="userRemoveAction"></span>
					</div>
				</div>
				<div class="userListItems">
					<div class="userFirstname">
						<p>Mona-Lisa</p>
					</div>
					<div class="userLastname">
						<p>da Vinci</p>
					</div>
					<div class="userEmail">
						<p>lagioconda@art.com</p>
					</div>
					<div class="userPhone">
						<p>+25024-122727</p>
					</div>
					<div class="userPlacedOrders">
						<p>24</p>
					</div>
					<div class="userRemove">
						<span class="userRemoveAction"></span>
					</div>
				</div>
				<div class="userListItems">
					<div class="userFirstname">
						<p>Tor</p>
					</div>
					<div class="userLastname">
						<p>Seldén</p>
					</div>
					<div class="userEmail">
						<p>torssa@swipnet.se</p>
					</div>
					<div class="userPhone">
						<p>08-22227565</p>
					</div>
					<div class="userPlacedOrders">
						<p>7</p>
					</div>
					<div class="userRemove">
						<span class="userRemoveAction"></span>
					</div>
				</div>
			</div>
		</div>
	</div>
</main>
</asp:Content>
