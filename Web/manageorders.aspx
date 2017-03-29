<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manageorders.aspx.cs" Inherits="Web.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<main>
	<div id="mainContent">
		<div id="manageOrdersSection">
			<h3>Hantera ordrar</h3>
					
			<hr class="overlayLine" />
			<div id="orders">
				<div class="orderBox" id="orderHeader">
					<div class="orderNumber">
						<p>Ordernr.</p>
					</div>
					<div class="orderDate">
						<p>Datum</p>
					</div>
					<div class="orderItems">
						<p>Artiklar</p>
					</div>
					<div class="orderTotal">
						<p>Belopp</p>
					</div>
					<div class="orderStatus">
						<p>Status</p>
					</div>
				</div>
				<hr class="overlayLine" />
					<div class="orderBox">
					<div class="orderNumber oNAdmin">
						<p>1337</p>
					</div>
					<div class="orderDate">
						<p>2017-01-22</p>
					</div>
					<div class="orderItems">
						<p>5</p>
					</div>
					<div class="orderTotal">
						<p>423,00</p>
					</div>
					<div class="orderStatus">
						<p>Ej levererad</p>
					</div>
				</div>
				<hr class="overlayLine" />
				<div class="orderBox">
					<div class="orderNumber oNAdmin">
						<p>1338</p>
					</div>
					<div class="orderDate">
						<p>2017-01-22</p>
					</div>
					<div class="orderItems">
						<p>22</p>
					</div>
					<div class="orderTotal">
						<p>2408,00</p>
					</div>
					<div class="orderStatus">
						<p>Inväntar transport</p>
					</div>
				</div>
				<hr class="overlayLine" />
			</div>
		</div>
	</div>
</main>
</asp:Content>
