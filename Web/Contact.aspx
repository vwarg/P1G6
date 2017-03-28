<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<main>
	<div id="mainContent">
		<div id="contactSection">
			<h3>Kontakt</h3>
			<p>Du kontaktar inte oss, vi kontaktar dig.</p>
					
			<form>
				<textarea placeholder="Här skulle du kunna skriva ditt meddelande om det gick att kontakta oss."></textarea>
				<input type="submit" name="contactRequest" value="Skicka fråga" disabled />
			</form>
					
		</div>
	</div>
</main>
</asp:Content>
