<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<main>
	<div id="mainContent">
		<div id="aboutSection">
			<h3>Om oss</h3>
			<p>Vi är det där medelstora lilla företaget med hjärtat på rätt ställe i halsgropen.</p>
					
			<div class="staffBox">
				<div class="staffImg">
					<img src="img/staff/madeleine.png" alt="Madeleine" />
				</div>
				<div class="staffInfo">
					<h4>Madeleine Ingemarsson</h4>
					<p class="staffWorkDesc">VD</p>
					<p class="staffDesc">Har arbetat på företaget sedan dess start. Har deltagit med sin expertis i allt från tabellknackande till att författa metoder.</p>
				</div>
			</div>
			<div class="staffBox">
				<div class="staffImg">
					<img src="img/staff/tor.png" alt="Tor" />
				</div>
				<div class="staffInfo">
					<h4>Tor Seldén</h4>
					<p class="staffWorkDesc">CEO</p>
					<p class="staffDesc">Har liksom Madeleine varit inblandad i stora delar av utvecklingen av företaget, men föredrar en mer internationell titel.</p>
				</div>
			</div>
			<div class="staffBox">
				<div class="staffImg">
					<img src="img/staff/viktor.png" alt="Viktor" />
				</div>
				<div class="staffInfo">
					<h4>Viktor Warg</h4>
					<p class="staffWorkDesc">Kodtrollkarl</p>
					<p class="staffDesc">while(fantaLemonIsFull){ awesomeCode(viktorsPerformance); }</p>
				</div>
			</div>
			<div class="staffBox">
				<div class="staffImg">
					<img src="img/staff/jonas.png" alt="Jonas" />
				</div>
				<div class="staffInfo">
					<h4>Jonas Jilmefors</h4>
					<p class="staffWorkDesc">Snickare</p>
					<p class="staffDesc">Bor i en frontend-värld.</p>
				</div>
			</div>
		</div>
	</div>
</main>
</asp:Content>
