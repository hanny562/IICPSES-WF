<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Statistic of Lecturer</title>
	<link href="/Content/css/style.css" media="screen" rel="stylesheet">
	<script type="text/javascript" src="../../Assets/js/Chart.min.js"></script>
</head>
<body>
	<div class="container" runat="server">
		<div style="text-align: center;">
			<h2>Evaluation Result</h2>
		</div>
		<br />
		<canvas id="canvas" height="450" width="600"></canvas>
		<br />
		<div>
			<br />
			<asp:Label ID="lbProgram" runat="server" Text="Program : "></asp:Label><br />
			<br />
			<asp:Label ID="lbSubject" runat="server" Text="Subject : "></asp:Label><br />
			<br />
			<asp:Label ID="lbSemester" runat="server" Text="Semester : "></asp:Label><br />
			<br />
			<asp:Label ID="lbLecturerName" runat="server" Text="Lecturer's Name : "></asp:Label><br />
			<br />
			<asp:Label ID="lbFeedback" runat="server" Text="Feedback : "></asp:Label><br />
			<br />
			<br />
		</div>
		<form runat="server">
			<asp:Button ID="btnExport" runat="server" Text="Export" />
		</form>

	</div>
	<script>
		var BarChart = {
			labels: ["Worst", "Poor", "Average", "Good", "Excellent"],
			datasets: [
				{
					fillColor: "rgba(151,249,190,0.5)",
					strokeColor: "rgba(255,255,255,1)",
					data: [13, 20, 30, 40, 50]
				}
			]

		}
		var myBarChart = new Chart(document.getElementById("canvas").getContext("2d")).Bar(BarChart, { scaleFontSize: 13, scaleFontColor: "#ffa45e" });

	</script>
</body>
</html>

