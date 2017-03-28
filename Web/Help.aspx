<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<main>
	<div id="mainContent">
		<div id="helpSection">
			<h2>Hjälp</h2>
			<p>Vi på Kontorsprylar AB arbetar ständig för att göra din upplevelse här så smidig som möjligt. 
			Har du en fråga som du inte hittar svar på här nedan så tveka inte att kontakta oss.</p>
					
			<h3>FAQ</h3>
			<ul>
				<li>
					<a href="#q1">Hur lägger jag varor i kundvagnen?</a>
				</li>
				<li>
					<a href="#q2">Varför är frakten alltid 49 kronor?</a>
				</li>
				<li>
					<a href="#q3">Hur kan jag se mina tidigare ordrar?</a>
				</li>
				<li>
					<a href="#q4">Hur får jag tag på ett registerutdrag om den data ni lagrat om mig?</a>
				</li>
				<li>
					<a href="#q5">Varför finns det så få blåbär i skogarna under mars månad?</a>
				</li>
				<li>
					<a href="#q6">Hur många bultar finns det i Ölandsbron?</a>
				</li>
			</ul>
					
			<div class="questionBox" id="q1">
				<p class="questionHeader">Hur lägger jag varor i kundvagnen?</p>
				<p class="questionAnswer">Klicka på kundkorgen brevid respektive produkt. Vill du lägga fler varor 
				av samma typ i kundkorgen, tryck flera gånger eller gå in i kundvagnen längst upp till höger på sidan 
				och använd kontrollerna där för att ändra antal.</p>
			</div>
					
			<div class="questionBox" id="q2">
				<p class="questionHeader">Varför är frakten alltid 49 kronor?</p>
				<p class="questionAnswer">Vi har en nära samarbete med företaget Frakt & Fjärran, som erbjuder oss en fast 
				fraktavgift oavsett orderns storlek.</p>
			</div>
					
			<div class="questionBox" id="q3">
				<p class="questionHeader">Hur kan jag se mina tidigare ordrar?</p>
				<p class="questionAnswer">Logga in på ditt konto och klicka på ikonen för profil högst upp, ute på högra kanten.</p>
			</div>
					
			<div class="questionBox" id="q4">
				<p class="questionHeader">Hur får jag tag på ett registerutdrag om den data ni lagrat om mig?</p>
				<p class="questionAnswer">Kontakta oss så skickar vi vidare information. Bl.a. så kommer vi att behöva en skriftlig begäran utfärdad och stryrkt av dig personligen.</p>
			</div>
					
			<div class="questionBox" id="q5">
				<p class="questionHeader">Varför finns det så få blåbär i skogarna under mars månad?</p>
				<p class="questionAnswer">Blåbärssäsongen har tyvärr inte kommit igång under mars månad.</p>
			</div>
					
			<div class="questionBox" id="q6">
				<p class="questionHeader">Hur många bultar finns det i Ölandsbron?</p>
				<p class="questionAnswer">7 428 954, om du litar på NileCity 105,6 som referens. Annars cirka 20 000.</p>
			</div>
		</div>
	</div>
</main>
</asp:Content>