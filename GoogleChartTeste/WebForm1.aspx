<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GoogleChartTeste.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="//www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'WebForm1.aspx/GetData',
                data: '{}',
                success:
                    function (response) {
                        drawVisualization(response.d);
                    }

            });
        })

        function drawVisualization(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].descricao, dataValues[i].densidade]);
            }

            new google.visualization.PieChart(document.getElementById('chart')).
                draw(data, { title: "Google Charts Example" });
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Button ID="btnGerar" runat="server" Text="Gerar Banco" OnClick="btnGerar_Click" />


<div id="chart" style="width: 900px; height: 500px;">
</div>
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
